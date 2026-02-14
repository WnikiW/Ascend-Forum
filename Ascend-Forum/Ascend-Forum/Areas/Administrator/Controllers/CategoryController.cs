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


        public IActionResult Edit(int categoryId)
        {
            var dbCategory = context.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (dbCategory == null)
                throw new ArgumentException("Category does not exist.");

            var model = new CategoryCreateModel
            {
                CategoryId = categoryId,
                Name = dbCategory.Name,
                Description = dbCategory.Description,
                ImageUrl = dbCategory.ImageUrl,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int categoryId, CategoryCreateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dbCategory = context.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (dbCategory == null)
                throw new ArgumentException("Category does not exist.");
            
            dbCategory.Name = model.Name;
            dbCategory.Description = model.Description;
            dbCategory.ImageUrl = model.ImageUrl;

            context.SaveChanges();

            return RedirectToAction("Index", "Home", new { area = "", isCategorySuccessfullyEdited = true }); // might redirect to category details
        }

        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            var dbCategory = context.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (dbCategory == null)
                throw new ArgumentException("Category does not exist.");

            context.Remove(dbCategory);

            context.SaveChanges();

            return RedirectToAction("Index", "Home", new { area = "" }); // might redirect to category details
        }
    }
}
