using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend_Forum.Infrastructure.Data.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(SeedCategories());
    }

    private IEnumerable<Category> SeedCategories()
    {
        return new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Technology",
                Description = "Latest trends in technology and software development.",
                ImageUrl = "https://picsum.photos/id/1/200/300"
            },
            new Category
            {
                Id = 2,
                Name = "Gaming",
                Description = "Discuss everything about video games and consoles.",
                ImageUrl = "https://picsum.photos/id/2/200/300"
            },
            new Category
            {
                Id = 3,
                Name = "Science",
                Description = "Space, Biology, Physics and more.",
                ImageUrl = "https://picsum.photos/id/3/200/300"
            },
            new Category
            {
                Id = 4,
                Name = "Programming",
                Description = "Coding challenges, best practices and career advice.",
                ImageUrl = "https://picsum.photos/id/4/200/300"
            },
            new Category
            {
                Id = 5,
                Name = "Lifestyle",
                Description = "Health, travel and general discussion.",
                ImageUrl = "https://picsum.photos/id/5/200/300"
            }
        };
    }
}
