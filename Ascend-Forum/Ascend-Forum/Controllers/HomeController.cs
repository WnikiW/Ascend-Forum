using Ascend_Forum.Areas.Administrator.ViewModels;
using Ascend_Forum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class HomeController(ICategoryService categoryService) : Controller
    {
        public IActionResult Index(bool isCategorySuccessfullyEdited = false)
        {
            var categories = categoryService.GetAllCategories()
                .Select(x => new CategoryListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                }).ToArray();

            ViewBag.IsCategorySuccessfullyEdited = isCategorySuccessfullyEdited;

            return View(categories);
        }
    }
}
