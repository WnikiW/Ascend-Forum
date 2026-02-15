using System.Diagnostics;
using Ascend_Forum.Areas.Administrator.ViewModels;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class HomeController(AscendForumDbContext context) : Controller
    {
        public IActionResult Index(bool isCategorySuccessfullyEdited = false)
        {
            var categories = context.Categories
                .Select(x => new CategoryListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                }).ToArray();

            ViewBag.IsCategorySuccessfullyEdited = isCategorySuccessfullyEdited;

            return View(categories);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
