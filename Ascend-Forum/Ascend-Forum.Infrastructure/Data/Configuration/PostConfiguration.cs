using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend_Forum.Infrastructure.Data.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(SeedPosts());
    }

    private IEnumerable<Post> SeedPosts()
    {

        var posts = new List<Post>();
        int postId = 1;
        string[] userIds = { "user1-id-guid", "user2-id-guid", "user3-id-guid", "user4-id-guid", "user5-id-guid" };

        for (int categoryId = 1; categoryId <= 5; categoryId++)
        {
            for (int j = 1; j <= 5; j++)
            {
                posts.Add(new Post
                {
                    Id = postId,
                    Title = $"Post {j} in Category {categoryId}",
                    Content = $"This is the content for post {j} in category {categoryId}. It contains some useful information.",
                    CreatorId = userIds[(postId - 1) % 5],
                    CategoryId = categoryId,
                    CreatedOn = new DateTime(2026, 3, 3, 16, 30, 00)
                });
                postId++;
            }
        }

        return posts;
    }
}
