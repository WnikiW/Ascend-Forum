using System.Globalization;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Controllers
{
    public class CategoryController(AscendForumDbContext context) : Controller
    {
        public IActionResult Details(int categoryId)
        {
            var category = context.Categories
                .FirstOrDefault(x => x.Id == categoryId);

            if (category == null)
                throw new ArgumentException("Category with such id does not exist");

            var posts = context.Posts
                .Include(x => x.Creator)
                .Where(x => x.CategoryId == category.Id)
                .Select(x => new PostListViewModel
                {
                    Id = x.Id,
                    CreatorAscendName = x.Creator.AscendName,
                    DateCreated = x.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    Title = x.Title,
                    CommentsCount = x.Comments.Count
                })
                .ToArray();

            var model = new CategoryDetailsViewModel
            {
                Id = category.Id,
                Title = category.Name,
                Description = category.Description,
                Posts = posts,
            };

            return View(model);
        }
    }
}
