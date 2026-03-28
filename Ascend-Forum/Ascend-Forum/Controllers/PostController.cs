using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure;
using Ascend_Forum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ascend_Forum.Controllers
{
    [Authorize]
    public class PostController(IPostService postService, ICategoryService categoryService) : Controller
    {
        public IActionResult Create()
        {
            var postCreateModel = new PostCreateModel
            {
                Categories = categoryService.GetAllCategories()
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
                model.Categories = categoryService.GetAllCategories()
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToArray();

                return View(model);
            }

            try
            {
                var postId = postService.CreatePost(
                    model.Title,
                    model.Content,
                    model.SelectedCategoryId,
                    this.User.GetId());

                return RedirectToAction("Details", "Category", new { categoryId = model.SelectedCategoryId });
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                model.Categories = categoryService.GetAllCategories()
                    .Select(x => new CategoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToArray();
                return View(model);
            }
        }

        [AllowAnonymous]
        public IActionResult Details(int postId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var model = postService.GetPostDetails(postId, userId);
                return View(model);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
