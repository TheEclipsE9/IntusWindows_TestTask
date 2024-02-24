using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Services;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.SubElement;
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
        public IActionResult Create([FromBody] CreateSubElementDTO subElementDTO)
        {
            _subElementService.Create(subElementDTO);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSubElementDTO subElementDTO)
        {
            _subElementService.Update(id, subElementDTO);

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
