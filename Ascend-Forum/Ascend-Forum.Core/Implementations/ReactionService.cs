using Ascend_Forum.Core.Common;
using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Enums;
using Ascend_Forum.Infrastructure.Data.Models;

namespace Ascend_Forum.Core.Implementations;

public class ReactionService(AscendForumDbContext context) : IReactionService
{
    public void React(int commentId, string userId, ReactionType reactionType)
    {
        var commentExists = context.Comments.Any(c => c.Id == commentId);

        if (!commentExists)
            throw new EntityNotFoundException(commentId, nameof(Comment));

        if (reactionType < ReactionType.ThumbsUp || reactionType > ReactionType.Crying)
            throw new ArgumentException("Invalid reaction type.");

        var existingReaction = context.CommentReactions
            .FirstOrDefault(cr => cr.CommentId == commentId && cr.UserId == userId);

        if (existingReaction == null)
        {
            var reaction = new CommentReaction
            {
                CommentId = commentId,
                UserId = userId,
                ReactionType = reactionType,
                CreatedOn = DateTime.UtcNow
            };

            context.CommentReactions.Add(reaction);
        }
        else if (existingReaction.ReactionType == reactionType)
        {
            context.CommentReactions.Remove(existingReaction);
        }
        else
        {
            existingReaction.ReactionType = reactionType;
        }

        context.SaveChanges();
    }
}