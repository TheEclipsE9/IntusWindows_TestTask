using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.Window;
using MyApp.Domain.Entities;

namespace MyApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;

        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var window = _windowService.Get(id);

            return Ok(window);
        }

        [HttpGet]
        [Route(("by-order/{orderId}"))]
        public IActionResult GetAllByOrderId(int orderId)
        {
            var window = _windowService.GetAllByOrderId(orderId);

            return Ok(window);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateWindowDTO windowDTO)
        {
            var created = _windowService.Create(windowDTO);

            return Ok(created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateWindowDTO windowDTO)
        {
            var updated = _windowService.Update(id, windowDTO);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _windowService.Delete(id);

            return Ok();
        }
    }
}
