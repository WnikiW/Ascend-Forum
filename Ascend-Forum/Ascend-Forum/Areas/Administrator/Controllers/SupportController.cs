using Ascend_Forum.Areas.Administrator.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Areas.Administrator.Controllers
{
    public class SupportController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
