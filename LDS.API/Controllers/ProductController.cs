using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;
using LDS.Contracts.DTO;
using LDS.Contracts.Responses;
using LDS.Contracts.Requests;

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
		public async Task<IActionResult> GetAll()
		{
			var areas = await _ProductService.GetAllAsync();

			var response = areas.Select(dto => new ProductResponse
			{
				Id = dto.Id,
				Name = dto.Name,
				BrandId = dto.BrandId,
				CategoryId = dto.CategoryId,
				AreaId = dto.AreaId,
				ImageUrl = dto.ImageUrl,
				BaseName = dto.BaseName,
				Quantity = dto.Quantity,
				Unit = dto.Unit,
				CreatedAt = dto.CreatedAt
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _ProductService.GetByIdAsync(id);
			if (dto == null)
				return NotFound();

			var response = new ProductResponse
			{
				Id = dto.Id,
				Name = dto.Name,
				BrandId = dto.BrandId,
				CategoryId = dto.CategoryId,
				AreaId = dto.AreaId,
				ImageUrl = dto.ImageUrl,
				BaseName = dto.BaseName,
				Quantity = dto.Quantity,
				Unit = dto.Unit,
				CreatedAt = dto.CreatedAt
			};

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
		{
			var dto = new ProductDTO
			{
				Name = request.Name,
				BrandId = request.BrandId,
				CategoryId = request.CategoryId,
				AreaId = request.AreaId,
				ImageUrl = request.ImageUrl,
				BaseName = request.BaseName,
				Quantity = request.Quantity,
				Unit = request.Unit,
				CreatedAt = DateTime.UtcNow
			};

			var created = await _ProductService.CreateAsync(dto);

			var response = new ProductResponse
			{
				Id = created.Id,
				Name = created.Name,
				BrandId = created.BrandId,
				CategoryId = created.CategoryId,
				AreaId = created.AreaId,
				ImageUrl = created.ImageUrl,
				BaseName = created.BaseName,
				Quantity = created.Quantity,
				Unit = created.Unit,
				CreatedAt = created.CreatedAt
			};

			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request)
		{
			var dto = new ProductDTO
			{
				Id = id,
				Name = request.Name,
				BrandId = request.BrandId,
				CategoryId = request.CategoryId,
				AreaId = request.AreaId,
				ImageUrl = request.ImageUrl,
				BaseName = request.BaseName,
				Quantity = request.Quantity,
				Unit = request.Unit,
			};

			var updated = await _ProductService.UpdateAsync(dto);

			if (updated == null)
				return NotFound();

			var response = new ProductResponse
			{
				Id = updated.Id,
				Name = updated.Name
			};

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _ProductService.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}
	}
}
