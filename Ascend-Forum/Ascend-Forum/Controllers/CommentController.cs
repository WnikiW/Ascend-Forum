using Ascend_Forum.Infrastructure;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.ViewModels;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascend_Forum.Controllers
{
    public class CommentController(AscendForumDbContext context) : Controller
    {
        [Authorize]
        [HttpPost]
        public IActionResult Create(CommentCreateModel model)
        {
            int? parentId = model.ParentId == 0 ? null : model.ParentId;

            var userId = this.User.GetId();
            var sanitizer = new HtmlSanitizer();

            var comment = new Comment
            {
                Content = sanitizer.Sanitize(model.Content),
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                ParentId = parentId,
                PostId = model.PostId, // todo first check if exists
            };

            context.Comments.Add(comment);
            context.SaveChanges();

            return RedirectToAction("Details", "Post", new { postId = model.PostId });
        }
    }
}
