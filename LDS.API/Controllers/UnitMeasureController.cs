using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;
using LDS.Contracts.DTO;
using LDS.Contracts.Responses;
using LDS.Contracts.Requests;

namespace LDS.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UnitMeasureController : ControllerBase
	{
		private readonly IUnitMeasureService _UnitMeasureService;

		public UnitMeasureController(IUnitMeasureService UnitMeasureService)
		{
			_UnitMeasureService = UnitMeasureService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var unitMeasures = await _UnitMeasureService.GetAllAsync();

			var response = unitMeasures.Select(dto => new UnitMeasureResponse
			{
				Id = dto.Id,
				Name = dto.Name
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _UnitMeasureService.GetByIdAsync(id);
			if (dto == null)
				return NotFound();

			var response = new UnitMeasureResponse
			{
				Id = dto.Id,
				Name = dto.Name
			};

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUnitMeasureRequest request)
		{
			var dto = new UnitMeasureDTO
			{
				Name = request.Name
			};

			var created = await _UnitMeasureService.CreateAsync(dto);

			var response = new UnitMeasureResponse
			{
				Id = created.Id,
				Name = created.Name
			};

			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateUnitMeasureRequest request)
		{
			var dto = new UnitMeasureDTO
			{
				Id = id,
				Name = request.Name
			};

			var updated = await _UnitMeasureService.UpdateAsync(dto);

			if (updated == null)
				return NotFound();

			var response = new UnitMeasureResponse
			{
				Id = updated.Id,
				Name = updated.Name
			};

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _UnitMeasureService.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}
	}
}
