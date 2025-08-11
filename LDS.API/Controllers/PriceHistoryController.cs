using Microsoft.AspNetCore.Mvc;
using LDS.Domain.Services.Interfaces;
using LDS.Contracts.DTO;
using LDS.Contracts.Responses;
using LDS.Contracts.Requests;

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
		public async Task<IActionResult> GetAll()
		{
			var areas = await _PriceHistoryService.GetAllAsync();

			var response = areas.Select(dto => new PriceHistoryResponse
			{
				Id = dto.Id,
				ProductId = dto.ProductId,
				Price = dto.Price,
				StartDate = dto.StartDate
			});

			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var dto = await _PriceHistoryService.GetByIdAsync(id);
			if (dto == null)
				return NotFound();

			var response = new PriceHistoryResponse
			{
				Id = dto.Id,
				ProductId = dto.ProductId,
				Price = dto.Price,
				StartDate = dto.StartDate
			};

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _PriceHistoryService.DeleteAsync(id);
			if (!deleted)
				return NotFound();

			return NoContent();
		}

		// Creation of price history records is typically handled internally when a product's price changes.
		/*
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePriceHistoryRequest request)
		{
			var dto = new PriceHistoryDTO
			{
				ProductId = request.ProductId,
				Price = request.Price,
				StartDate = DateOnly.FromDateTime(DateTime.UtcNow)
			};

			var created = await _PriceHistoryService.CreateAsync(dto);

			var response = new PriceHistoryResponse
			{
				Id = created.Id,
				ProductId = created.ProductId,
				Price = created.Price,
				StartDate = created.StartDate
			};

			return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
		}
		*/

		// Update is not typically needed for price history, as records are usually immutable after creation.
		/*
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdatePriceHistoryRequest request)
		{
			var dto = new PriceHistoryDTO
			{
				Id = id,
				ProductId = request.ProductId,
				Price = request.Price
			};

			var updated = await _PriceHistoryService.UpdateAsync(dto);

			if (updated == null)
				return NotFound();

			var response = new PriceHistoryResponse
			{
				Id = updated.Id,
				ProductId = updated.ProductId,
				Price = updated.Price,
				StartDate = updated.StartDate
			};

			return Ok(response);
		}
		*/
	}
}
