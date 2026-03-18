using System.Diagnostics;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode = 0)
        {
            if (statusCode == StatusCodes.Status400BadRequest)
                return View("BadRequest");

            if (statusCode == StatusCodes.Status404NotFound)
                return View("NotFound");

            if (statusCode == StatusCodes.Status500InternalServerError)
                return View("ServerError");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
