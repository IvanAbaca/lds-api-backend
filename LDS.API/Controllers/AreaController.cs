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
		public async Task<IActionResult> GetAll()
		{
            var areas = await _AreaService.GetAllAsync();
			return Ok(areas);
		}
	}
}
