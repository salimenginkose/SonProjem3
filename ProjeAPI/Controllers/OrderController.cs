using Microsoft.AspNetCore.Mvc;
using ProjeAPI.Core.API;
using ProjeAPI.Core.Entities;
using ProjeAPI.Core.Enums.Errors;
using ProjeAPI.Core.RepositoryConcrete;
using ProjeAPI.Core.Services;


namespace ProjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerProcess
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddNewOrder")]
        [ProducesResponseType(typeof(Order), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(Order), (int)HttpCodes.NotFound)]
        [ProducesResponseType(typeof(Order), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> MakeNewOrder(AddOrderService newOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _orderService.MakeNewOrder(newOrder);
            return this.ProccessResult(res);
        }

        [HttpPost("GetAllOrders")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpCodes.Succeded)]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpCodes.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpCodes.ServerError)]
        public async Task<IActionResult> GetAllOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _orderService.GetAllOrders();
            return this.ProccessResult(res);
        }
    }
}
