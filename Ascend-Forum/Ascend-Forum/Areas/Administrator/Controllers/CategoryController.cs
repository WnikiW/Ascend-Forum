using Ascend_Forum.Areas.Administrator.ViewModels;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Areas.Administrator.Controllers
{
    public class CategoryController(AscendForumDbContext context) : BaseAdminController
    {

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var exists = context.Categories.Any(x => x.Name.ToLower() == model.Name.ToLower());

            if (exists)
            {
                ModelState.AddModelError(string.Empty, "Category with the same name already exists.");

                return View();
            }

            var dbCategory = new Category()
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
            };

            context.Categories.Add(dbCategory);

            context.SaveChanges();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
