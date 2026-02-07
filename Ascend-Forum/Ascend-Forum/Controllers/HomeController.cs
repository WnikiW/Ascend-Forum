using System.Diagnostics;
using Ascend_Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // load all categories

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
