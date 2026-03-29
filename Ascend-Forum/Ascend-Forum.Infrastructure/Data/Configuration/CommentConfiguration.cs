using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend_Forum.Infrastructure.Data.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasData(SeedComments());
    }

    private IEnumerable<Comment> SeedComments()
    {
        var comments = new List<Comment>();
        int commentId = 1;
        string[] userIds = { "user1-id-guid", "user2-id-guid", "user3-id-guid", "user4-id-guid", "user5-id-guid" };

        for (int postId = 1; postId <= 25; postId++)
        {
            for (int i = 1; i <= 2; i++)
            {
                comments.Add(new Comment
                {
                    Id = commentId,
                    PostId = postId,
                    Content = $"Comment {i} for post {postId}. Nice post!",
                    CreatorId = userIds[(commentId - 1) % 5],
                    CreatedOn = new DateTime(2026, 3, 3, 16, 30, 00)
                });
                commentId++;
            }
        }

        return comments;
    }
}
