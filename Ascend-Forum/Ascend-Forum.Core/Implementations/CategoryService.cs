using Ascend_Forum.Core.Contracts;
using Ascend_Forum.Core.Models.Category;
using Ascend_Forum.Infrastructure.Data;
using Ascend_Forum.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Ascend_Forum.Core.Common;

namespace Ascend_Forum.Core.Implementations
{
    public class CategoryService(AscendForumDbContext context) : ICategoryService
    {
        public CategoryModel? GetCategoryById(int id)
        {
            return context.Categories
                .Select(x => new CategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public CategoryDetailsModel GetDetailsById(int id)
        {
            var category = context.Categories
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
                throw new EntityNotFoundException(id, nameof(Category));

            var posts = context.Posts
                .Include(x => x.Creator)
                .Where(x => x.CategoryId == category.Id)
                .Select(x => new PostListModel
                {
                    Id = x.Id,
                    CreatorAscendName = x.Creator.AscendName,
                    DateCreated = x.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    Title = x.Title,
                    CommentsCount = x.Comments.Count
                })
                .ToArray();

            return new CategoryDetailsModel
            {
                Id = category.Id,
                Title = category.Name,
                Description = category.Description,
                Posts = posts,
            };
        }
    }
}
