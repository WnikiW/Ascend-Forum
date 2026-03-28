using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure;
using Ascend_Forum.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class CommentController(ICommentService commentService) : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult Create(CommentCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Post", new { postId = model.PostId });
            }

            commentService.CreateComment(
                model.Content,
                model.PostId,
                this.User.GetId(),
                model.ParentId);

            return RedirectToAction("Details", "Post", new { postId = model.PostId });
        }
    }
}
