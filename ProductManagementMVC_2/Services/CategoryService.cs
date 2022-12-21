
using Microsoft.EntityFrameworkCore;
using ProductManagementMVC.Interfaces;
using ProductManagementMVC_2.Data;
using ProductManagementMVC_2.Entities;
using ProductManagementMVC_2.Interfaces;
using ProductManagementMVC_2.Mapping;
using ProductManagementMVC_2.Models;

namespace ProductManagementMVC_2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductManagementMVC_2Context _context;
        private readonly IMapper<Category, CategoryModel> _categoryMapper;

        public CategoryService(ProductManagementMVC_2Context context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }
        
        public IEnumerable<Category> GetCategories(string searchString)
        {
            return _context.Categories.Where(c => string.IsNullOrEmpty(searchString) || c.Name.Contains(searchString));
        }

        public CategoryModel CreateCategory(CategoryModel category)
        {
            var categoryAlreadyExists = _context.Categories.Any(p => p.Name == category.Name);

            if (categoryAlreadyExists)
            {
                throw new DbUpdateException($"Category with name '{category.Name}' already exist.");
            }

            var categoryEntity = _categoryMapper.MapFromModelToEntity(category);

            var newCategory = _context.Categories.Add(categoryEntity);

            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = _context.Categories.Find(id);
            if (categoryToDelete == null)
            {
                throw new DbUpdateException($"Category with id '{id}' doesn't exist.");
            }

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();

        }

        public CategoryModel GetCategory(int id)
        {
            var category = _context.Categories.Find(id); // get from base, we have entity type object
            if (category == null)
            {
                throw new DbUpdateException($"Category with id {id} doesn't exist.");
            }
            var categoryModel = _categoryMapper.MapFromEntityToModel(category); // using mapper to get category Model

            return categoryModel;
        }

        public CategoryModel UpdateCategory(CategoryModel updateCategory)
        {
            var existingCategoryToUpdate = _context.Categories.Find(updateCategory.Id);

            if (existingCategoryToUpdate == null)
            {
                throw new DbUpdateException($"Category with Id {updateCategory.Id} does not exist ");
            }

            _categoryMapper.MapFromModelToEntity(updateCategory, existingCategoryToUpdate);
            _context.SaveChanges();


            return updateCategory;
        }
    }
}
