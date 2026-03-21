using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Enums;
using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ascend_Forum.Controllers
{
    [Authorize]
    public class CommentReactionController(AscendForumDbContext context, UserManager<User> userManager) : Controller
    {

        [HttpPost]
        public async Task<IActionResult> React(int commentId, ReactionType reactionType, int postId)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            var commentExists = await context.Comments.AnyAsync(c => c.Id == commentId);

            if (!commentExists)
            {
                return NotFound();
            }

            var existingReaction = await context.CommentReactions
                .FirstOrDefaultAsync(cr => cr.CommentId == commentId && cr.UserId == user.Id);

            if (existingReaction == null)
            {
                var reaction = new CommentReaction
                {
                    CommentId = commentId,
                    UserId = user.Id,
                    ReactionType = reactionType,
                    CreatedOn = DateTime.UtcNow
                };

                await context.CommentReactions.AddAsync(reaction);
            }
            else if (existingReaction.ReactionType == reactionType)
            {
                context.CommentReactions.Remove(existingReaction);
            }
            else
            {
                existingReaction.ReactionType = reactionType;
            }

            await context.SaveChangesAsync();

            return RedirectToAction("Details", "Post", new { id = postId });
        }
    }
}
