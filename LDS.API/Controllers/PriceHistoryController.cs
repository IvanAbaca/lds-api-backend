using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;

namespace LDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceHistoryController : ControllerBase
    {
        private readonly IPriceHistoryService _PriceHistoryService;

        public PriceHistoryController(IPriceHistoryService PriceHistoryService)
        {
            _PriceHistoryService = PriceHistoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Use _PriceHistoryService to retrieve data
            return Ok();
        }
    }
}
