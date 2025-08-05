using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;

namespace LDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _BrandService;

        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Use _BrandService to retrieve data
            return Ok();
        }
    }
}
