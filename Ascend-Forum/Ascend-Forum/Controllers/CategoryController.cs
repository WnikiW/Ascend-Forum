using System.Globalization;
using Ascend_Forum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public IActionResult Details(int categoryId)
        {
            var model = categoryService
                .GetDetailsById(categoryId);

            return View(model);
        }
    }
}
