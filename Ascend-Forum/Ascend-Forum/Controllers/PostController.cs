using Ascend_Forum.Infrastructure;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Enums;
using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.ViewModels;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dbComments = context.Comments
                .Include(x => x.Creator)
                .Where(x => x.PostId == dbPost.Id)
                .ToList();

            var commentIds = dbComments
                .Select(x => x.Id)
                .ToList();

            var reactions = context.CommentReactions
                .Where(x => commentIds.Contains(x.CommentId))
                .ToList();

            var comments = dbComments
                .Select(x =>
                {
                    var commentReactions = reactions
                        .Where(r => r.CommentId == x.Id)
                        .ToList();

                    return new CommentModel
                    {
                        Id = x.Id,
                        CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                        Content = x.Content,
                        CreatorUsername = x.Creator.UserName,
                        ParentId = x.ParentId,
                        ReactionCounts = commentReactions
                            .GroupBy(r => r.ReactionType)
                            .ToDictionary(g => g.Key, g => g.Count()),
                        CurrentUserReaction = commentReactions
                            .Where(r => r.UserId == userId)
                            .Select(r => (ReactionType?)r.ReactionType)
                            .FirstOrDefault()
                    };
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
                    ReactionCounts = x.ReactionCounts,
                    CurrentUserReaction = x.CurrentUserReaction
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
