using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
