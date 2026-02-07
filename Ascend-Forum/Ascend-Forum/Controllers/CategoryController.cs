using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
