using Microsoft.AspNetCore.Mvc;
using ProductManagementMVC_2.Interfaces;
using ProductManagementMVC_2.Models;

namespace ProductManagementMVC_2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult GetCategories(string searchString)
        {
            var objCategoryList = _categoryService.GetCategories(searchString);
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {

            if (ModelState.IsValid)
            {
                _categoryService.CreateCategory(category);
                return RedirectToAction("GetCategories");
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var categoryToDelete = _categoryService.GetCategory(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            return View(categoryToDelete);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteCategory(int id)
        {
            var getCategory = _categoryService.GetCategory(id);
            if (getCategory == null)
            {
                return NotFound();
            }
            _categoryService.DeleteCategory(id);
            return RedirectToAction("GetCategories");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var categoryToUpdate = _categoryService.GetCategory(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            return View(categoryToUpdate);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryModel updatedCategory)
        {
            var getCategory = _categoryService.GetCategory(updatedCategory.Id);
            if (getCategory == null)
            {
                return NotFound();
            }
            _categoryService.UpdateCategory(updatedCategory);
            return RedirectToAction("GetCategories");
        }





    }
}
