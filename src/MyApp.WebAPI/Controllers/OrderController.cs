using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.Order;

namespace MyApp.WebAPI.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.Get(id);

            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDTO orderDTO)
        {
            var order = _orderService.Create(orderDTO);

            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateOrderDTO orderDTO)
        {
            var updated = _orderService.Update(id, orderDTO);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);

            return Ok();
        }
    }
}
