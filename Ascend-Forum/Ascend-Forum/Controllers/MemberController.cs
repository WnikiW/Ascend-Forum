using Ascend_Forum.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class MemberController(IMemberService memberService) : Controller
    {
        public IActionResult Index(int? minPostCount, int? minReactionCount)
        {
            var members = memberService.GetMembers(minPostCount, minReactionCount);
            return View(members);
        }
    }
}
