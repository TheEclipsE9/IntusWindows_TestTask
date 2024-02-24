using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Services;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Entities;

namespace MyApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementService _subElementService;

        public SubElementController(ISubElementService subElementService)
        {
            _subElementService = subElementService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var subElement = _subElementService.Get(id);

            return Ok(subElement);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SubElement subElement)
        {
            _subElementService.Create(subElement);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SubElement subElement)
        {
            _subElementService.Update(id, subElement);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subElementService.Delete(id);

            return Ok();
        }
    }
}
