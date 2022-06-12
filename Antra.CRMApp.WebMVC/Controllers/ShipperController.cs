using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ShipperController : Controller
    {
         private readonly IShipperServiceAsync shipperServiceAsync;
        public ShipperController(IShipperServiceAsync shipperServiceAsync)
        {
            this.shipperServiceAsync = shipperServiceAsync;
        }

        public async Task<IActionResult> Index()
        {
            var shipperCollection = await shipperServiceAsync.GetAllAsync();
            if(shipperCollection != null)
            {
                return View(shipperCollection);
            }
            List<ShipperResponseModel> model = new List<ShipperResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ShipperRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await shipperServiceAsync.AddShipperAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var shipperModel = await shipperServiceAsync.GetShipperForEditAsync(id);
            return View(shipperModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ShipperRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await shipperServiceAsync.UpdateShipperAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await shipperServiceAsync.DeleteShipperAsync(id);
            return RedirectToAction("Index");
        }
    }
}
