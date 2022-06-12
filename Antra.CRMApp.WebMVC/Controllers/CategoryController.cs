using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public CategoryController(ICategoryServiceAsync categoryServiceAsync)
        {
            this.categoryServiceAsync = categoryServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var catCollection = await categoryServiceAsync.GetAllAsync();
            if (catCollection != null)
            {
                return View(catCollection);
            }
            List<CategoryResponseModel> model = new List<CategoryResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.AddCategoryAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var catModel = await categoryServiceAsync.GetCategoryForEditAsync(id);
            return View(catModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await categoryServiceAsync.UpdateCategoryAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryServiceAsync.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

    }
}
