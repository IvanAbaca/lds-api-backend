using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;
using LDS.Contracts.DTO;
using LDS.Contracts.Responses;
using LDS.Contracts.Requests;

namespace LDS.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _CategoryService;

		public CategoryController(ICategoryService CategoryService)
		{
			_CategoryService = CategoryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var areas = await _CategoryService.GetAllAsync();

			var response = areas.Select(dto => new CategoryResponse
			{
				Id = dto.Id,
				Name = dto.Name
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _CategoryService.GetByIdAsync(id);
			if (dto == null)
				return NotFound();

			var response = new CategoryResponse
			{
				Id = dto.Id,
				Name = dto.Name
			};

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
		{
			var dto = new CategoryDTO
			{
				Name = request.Name
			};

			var created = await _CategoryService.CreateAsync(dto);

			var response = new CategoryResponse
			{
				Id = created.Id,
				Name = created.Name
			};

			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequest request)
		{
			var dto = new CategoryDTO
			{
				Id = id,
				Name = request.Name
			};

			var updated = await _CategoryService.UpdateAsync(dto);

			if (updated == null)
				return NotFound();

			var response = new CategoryResponse
			{
				Id = updated.Id,
				Name = updated.Name
			};

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _CategoryService.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}
	}
}
