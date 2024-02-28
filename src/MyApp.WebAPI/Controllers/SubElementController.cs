using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Contracts.Application;
using MyApp.Domain.Contracts.DTOs.SubElement;
using MyApp.Domain.Contracts.Infrastructure;

namespace MyApp.WebAPI.Controllers
{
    public class SubElementController : BaseController
    {
        private readonly ISubElementService _subElementService;
        private readonly IAppDbContext _dbContext;

        public SubElementController(
            ISubElementService subElementService, 
            IAppDbContext dbContext)
        {
            _subElementService = subElementService;
            _dbContext = dbContext;
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

        [HttpGet("unique")]
        public IActionResult GetUnique()
        {
            var unique = _dbContext.SubElements.ToList();

            var res = unique.DistinctBy(x => new { x.Width, x.Height, x.Type });
            //for{for{}}

            return Ok(res);
        }
    }
}
