using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure;
using Ascend_Forum.Infrastructure.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    [Authorize]
    public class CommentReactionController(IReactionService reactionService) : Controller
    {
        [HttpPost]
        public IActionResult React(int commentId, ReactionType reactionType, int postId)
        {
            var userId = this.User.GetId();

            try
            {
                reactionService.React(commentId, userId, reactionType);

                return RedirectToAction("Details", "Post", new { postId = postId });
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
