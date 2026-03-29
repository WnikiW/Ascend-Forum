using Ascend_Forum.Infrastructure.Data.Models;
using Ascend_Forum.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend_Forum.Infrastructure.Data.Configuration;

public class CommentReactionConfiguration : IEntityTypeConfiguration<CommentReaction>
{
    public void Configure(EntityTypeBuilder<CommentReaction> builder)
    {
        builder.HasData(SeedReactions());
    }

    private IEnumerable<CommentReaction> SeedReactions()
    {
        var reactions = new List<CommentReaction>();
        string[] userIds = { "user1-id-guid", "user2-id-guid", "user3-id-guid", "user4-id-guid", "user5-id-guid" };

        for (int commentId = 1; commentId <= 50; commentId++)
        {
            reactions.Add(new CommentReaction
            {
                Id = commentId,
                CommentId = commentId,
                UserId = userIds[commentId % 5],
                ReactionType = (ReactionType)((commentId % 2) + 1), 
                CreatedOn = new DateTime(2026, 3, 3, 16, 30, 00)
            });
        }

        return reactions;
    }
}
