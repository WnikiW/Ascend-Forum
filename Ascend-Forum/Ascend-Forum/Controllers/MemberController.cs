using Ascend_Forum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class MemberController(IMemberService memberService) : Controller
    {
        public IActionResult Index(int? minPostCount, int? minReactionCount, int pageNumber = 1)
        {
            var members = memberService.GetMembers(minPostCount, minReactionCount, pageNumber);
            return View(members);
        }
    }
}
