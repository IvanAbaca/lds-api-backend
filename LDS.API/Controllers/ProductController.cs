using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;

namespace LDS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO: Use _ProductService to retrieve data
            return Ok();
        }
    }
}
