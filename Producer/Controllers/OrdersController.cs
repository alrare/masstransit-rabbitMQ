using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Producer.DTO;
using Producer.Service;
using SharedModels;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            await _orderService.SaveOrder(orderDto);

            return StatusCode(201);
        }
    }
}
