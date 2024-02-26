using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.SubElement;

namespace MyApp.WebAPI.Controllers
{
    public class SubElementController : BaseController
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

        [HttpGet]
        [Route(("by-window/{windowId}"))]
        public IActionResult GetAllByOrderId(int windowId)
        {
            var subElements = _subElementService.GetAllByWindowId(windowId);

            return Ok(subElements);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateSubElementDTO subElementDTO)
        {
            var created = _subElementService.Create(subElementDTO);

            return Ok(created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSubElementDTO subElementDTO)
        {
            var updated = _subElementService.Update(id, subElementDTO);

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subElementService.Delete(id);

            return Ok();
        }
    }
}
