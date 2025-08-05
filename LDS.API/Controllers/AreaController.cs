using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;

namespace LDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _AreaService;

        public AreaController(IAreaService AreaService)
        {
            _AreaService = AreaService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Use _AreaService to retrieve data
            return Ok();
        }
    }
}
