using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;
using LDS.Contracts.DTO;
using LDS.Contracts.Responses;
using LDS.Contracts.Requests;

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

			var response = areas.Select(dto => new AreaResponse
			{
				Id = dto.Id,
				Name = dto.Name
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _AreaService.GetByIdAsync(id);
			if (dto == null)
				return NotFound();

			var response = new AreaResponse
			{
				Id = dto.Id,
				Name = dto.Name
			};

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateAreaRequest request)
		{
			var dto = new AreaDTO
			{
				Name = request.Name
			};

			var created = await _AreaService.CreateAsync(dto);

			var response = new AreaResponse
			{
				Id = created.Id,
				Name = created.Name
			};

			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateAreaRequest request)
		{
			var dto = new AreaDTO
			{
				Id = id,
				Name = request.Name
			};

			var updated = await _AreaService.UpdateAsync(dto);

			if (updated == null)
				return NotFound();

			var response = new AreaResponse
			{
				Id = updated.Id,
				Name = updated.Name
			};

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _AreaService.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}
	}
}
