using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync orderServiceAsync;
        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            this.orderServiceAsync = orderServiceAsync;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await orderServiceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await orderServiceAsync.GetByIdAsync(id);
            if (result == null)
                return NotFound($"Order with Id = {id} is not available");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            var result = await orderServiceAsync.AddOrderAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrderRequestModel model)
        {
            var result = await orderServiceAsync.UpdateOrderAsync(model);
            if (result > 0)
                return Ok(model);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await orderServiceAsync.DeleteOrderAsync(id);
            if (result > 0)
                return Ok("Order Deleted successfully");
            return BadRequest();
        }
    }
}
