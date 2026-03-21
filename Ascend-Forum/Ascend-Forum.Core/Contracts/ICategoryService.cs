using Ascend_Forum.Core.Models.Category;

namespace Ascend_Forum.Core.Contracts
{
     public interface ICategoryService
     {
         CategoryModel? GetCategoryById(int id);
         CategoryDetailsModel GetDetailsById(int id);
     }
}
