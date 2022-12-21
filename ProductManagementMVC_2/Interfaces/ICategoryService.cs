using ProductManagementMVC_2.Entities;
using ProductManagementMVC_2.Models;

namespace ProductManagementMVC_2.Interfaces
{
    public interface ICategoryService
    {
        CategoryModel GetCategory(int id);
        CategoryModel CreateCategory(CategoryModel category);
        void DeleteCategory(int id);
        CategoryModel UpdateCategory(CategoryModel updateCategory);
        IEnumerable<Category> GetCategories(string name);
    }
}






