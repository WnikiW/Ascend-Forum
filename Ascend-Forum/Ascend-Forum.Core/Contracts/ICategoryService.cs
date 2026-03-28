using Ascend_Forum.Core.Models.Category;

namespace Ascend_Forum.Core.Contracts
{
     public interface ICategoryService
     {
         CategoryModel? GetCategoryById(int id);
         CategoryDetailsModel GetDetailsById(int id);
         IEnumerable<CategoryModel> GetAllCategories();
         void CreateCategory(string name, string description, string imageUrl);
         void EditCategory(int id, string name, string description, string imageUrl);
         void DeleteCategory(int id);
     }
}
