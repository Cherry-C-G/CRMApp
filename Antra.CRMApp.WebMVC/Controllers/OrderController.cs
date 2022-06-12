using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServiceAsync orderServiceAsync;
        public OrderController(IOrderServiceAsync orderservice)
        {
            orderServiceAsync = orderservice;
        }
        public async Task<IActionResult> Index()
        {
            var ordCollection = await orderServiceAsync.GetAllAsync();
            if (ordCollection != null)
                return View(ordCollection);

            List<OrderResponseModel> model = new List<OrderResponseModel>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderRequestModel model)
        {
            if (ModelState.IsValid)
            {
                await orderServiceAsync.AddOrderAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var ordModel = await orderServiceAsync.GetOrderForEditAsync(id);
            return View(ordModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OrderRequestModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await orderServiceAsync.UpdateOrderAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await orderServiceAsync.DeleteOrderAsync(id);
            return RedirectToAction("Index");
        }
    }
}
