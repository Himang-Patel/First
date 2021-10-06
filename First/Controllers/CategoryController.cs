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
