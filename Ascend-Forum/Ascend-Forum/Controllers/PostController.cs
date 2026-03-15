using System.Globalization;
using Ascend_Forum.Infrastructure;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.ViewModels;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Controllers
{
    [Authorize]
    public class PostController(AscendForumDbContext context) : Controller
    {
        public IActionResult Create()
        {
            var postCreateModel = new PostCreateModel
            {
                Categories = context.Categories
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToArray()
            };

            return View(postCreateModel);
        }

        [HttpPost]
        public IActionResult Create(PostCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = context.Categories
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToArray();

                return View(model);
            }

            var dbCategory = context.Categories
                .FirstOrDefault(x => x.Id == model.SelectedCategoryId);

            if (dbCategory == null)
                throw new ArgumentException("Category does not exist.");

            var sanitizer = new HtmlSanitizer();

            var dbPost = new Post
            {
                Title = model.Title,
                Content = sanitizer.Sanitize(model.Content),
                CreatorId = this.User.GetId(),
                CategoryId = dbCategory.Id,
                CreatedOn = DateTime.Now,
            };

            context.Posts.Add(dbPost);
            context.SaveChanges();

            return RedirectToAction("Details", "Category", new { categoryId = dbCategory.Id });
        }

        public IActionResult Details(int postId)
        {
            var dbPost = context.Posts
                .Include(x => x.Creator)
                .FirstOrDefault(x => x.Id == postId);

            if (dbPost == null)
                throw new ArgumentException("Post does not exist.");

            var comments = context.Comments
                .Include(x => x.Creator)
                .Where(x => x.PostId == dbPost.Id)
                .Select(x => new CommentModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                    Content = x.Content,
                    CreatorUsername = x.Creator.UserName,
                    ParentId = x.ParentId,
                })
                .ToList();

            var projectedComments = comments
                .Select(x => new CommentModel
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Content = x.Content,
                    CreatorUsername = x.CreatorUsername,
                    ParentId = x.ParentId,
                    Parent = comments.FirstOrDefault(y => y.Id == x.ParentId),
                })
                .ToArray();

            var model = new PostDetailsModel
            {
                Id = dbPost.Id,
                Title = dbPost.Title,
                Content = dbPost.Content,
                CreatorUsername = dbPost.Creator.AscendName,
                CreatedOn = dbPost.CreatedOn.ToString(CultureInfo.InvariantCulture),
                Comments = projectedComments,
            };

            return View(model);
        }
    }
}
