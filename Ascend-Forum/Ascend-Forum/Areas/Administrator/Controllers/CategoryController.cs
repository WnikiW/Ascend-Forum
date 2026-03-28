using Ascend_Forum.Areas.Administrator.ViewModels;
using Ascend_Forum.Core.Common;
using Ascend_Forum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Areas.Administrator.Controllers
{
    public class CategoryController(ICategoryService categoryService) : BaseAdminController
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

            try
            {
                categoryService.CreateCategory(model.Name, model.Description, model.ImageUrl);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        public IActionResult Edit(int categoryId)
        {
            var dbCategory = categoryService.GetCategoryById(categoryId);

            if (dbCategory == null)
                return NotFound();

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

            try
            {
                categoryService.EditCategory(categoryId, model.Name, model.Description, model.ImageUrl);
                return RedirectToAction("Index", "Home", new { area = "", isCategorySuccessfullyEdited = true });
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(int categoryId)
        {
            try
            {
                categoryService.DeleteCategory(categoryId);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
