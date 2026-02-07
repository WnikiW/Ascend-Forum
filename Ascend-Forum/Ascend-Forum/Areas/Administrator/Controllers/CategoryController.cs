using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Areas.Administrator.Controllers
{
    public class CategoryController : BaseAdminController
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
