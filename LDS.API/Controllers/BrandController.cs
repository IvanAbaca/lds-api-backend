using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;
using LDS.Contracts.DTO;
using LDS.Contracts.Responses;
using LDS.Contracts.Requests;

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
		public async Task<IActionResult> GetAll()
		{
			var areas = await _BrandService.GetAllAsync();

			var response = areas.Select(dto => new BrandResponse
			{
				Id = dto.Id,
				Name = dto.Name
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _BrandService.GetByIdAsync(id);
			if (dto == null)
				return NotFound();

			var response = new BrandResponse
			{
				Id = dto.Id,
				Name = dto.Name
			};

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateBrandRequest request)
		{
			var dto = new BrandDTO
			{
				Name = request.Name
			};

			var created = await _BrandService.CreateAsync(dto);

			var response = new BrandResponse
			{
				Id = created.Id,
				Name = created.Name
			};

			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateBrandRequest request)
		{
			var dto = new BrandDTO
			{
				Id = id,
				Name = request.Name
			};

			var updated = await _BrandService.UpdateAsync(dto);

			if (updated == null)
				return NotFound();

			var response = new BrandResponse
			{
				Id = updated.Id,
				Name = updated.Name
			};

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _BrandService.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}
	}
}
