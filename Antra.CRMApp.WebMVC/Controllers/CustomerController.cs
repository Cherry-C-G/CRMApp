using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServiceAsync customerServiceAsync;
        private readonly IRegionServiceAsync regionServiceAsync;
        public CustomerController(ICustomerServiceAsync customerServiceAsync, IRegionServiceAsync regionServiceAsync)
        {
            this.customerServiceAsync = customerServiceAsync;
            this.regionServiceAsync = regionServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var customerCollection = await customerServiceAsync.GetAllAsync();
            if (customerCollection != null)
                return View(customerCollection);

            List<CustomerResponseModel> model = new List<CustomerResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await customerServiceAsync.AddCustomerAsync(model);
                return RedirectToAction("Index");
            }
            ViewBag.message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)); //to check the errors

            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var customerModel = await customerServiceAsync.GetCustomerForEditAsync(id);
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            return View(customerModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerRequestModel model)
        {
            ViewBag.IsEdit = false;
            var collection = await regionServiceAsync.GetAllAsync();
            ViewBag.Regions = new SelectList(collection, "Id", "Name");
            if (ModelState.IsValid)
            {
                await customerServiceAsync.UpdateCustomerAsync(model);
                ViewBag.IsEdit = true;

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await customerServiceAsync.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }

    }
}
