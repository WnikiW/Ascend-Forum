using Ascend_Forum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class MemberController(IMemberService memberService) : Controller
    {
        public IActionResult Index()
        {
            var members = memberService.GetMembers();
            return View(members);
        }
    }
}
