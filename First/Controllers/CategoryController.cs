using CL.Interface;
using CL.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryModel> result = await _category.GetCategory();
            return View(result);
        }
        public async Task<IActionResult> Create(int id)
        {
            IEnumerable<CategoryModel> result = await _category.GetCategory();
            return View(result.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryModel categoryModel)
        {
            //string isEmailExists = await _personService.CheckEmailExists(addPersonModel.EmailAddress);
            //if (!string.IsNullOrEmpty(isEmailExists))
            //{
            //    response.ResponseMessage = Constant.EmailAlreadyExists;
            //    return Conflict(response);
            //}
            var personId = await _category.AddCategory(categoryModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            IEnumerable<CategoryModel> result = await _category.GetCategory();
            return View(result.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await _category.DeleteCategory(id);
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }
    }
}
