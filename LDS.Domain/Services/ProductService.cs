using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;
using System.Transactions;

namespace LDS.Domain.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _ProductRepository;
		private readonly IPriceHistoryRepository _PriceHistoryRepository;
		private readonly IPriceHistoryService _PriceHistoryService;

		public ProductService(
			IProductRepository ProductRepository, 
			IPriceHistoryRepository priceHistoryRepository,
			IPriceHistoryService priceHistoryService)
		{
			_ProductRepository = ProductRepository;
			_PriceHistoryRepository = priceHistoryRepository;
			_PriceHistoryService = priceHistoryService;
		}

		public async Task<List<ProductDTO>> GetAllAsync()
		{
			var products = await _ProductRepository.GetAllAsync();

			return products.Select(p => new ProductDTO
			{
				Id = p.Id,
				Name = p.Name,
				BrandId = p.BrandId,
				CategoryId = p.CategoryId,
				AreaId = p.AreaId,
				UnitMeasureId = p.UnitMeasureId,
				Quantity = p.Quantity,
				CurrentPrice = p.CurrentPrice,
				ImageUrl = p.ImageUrl,
				CreatedAt = p.CreatedAt,
				UpdatedAt = p.UpdatedAt,
			}).ToList();
		}

		public async Task<ProductDTO?> GetByIdAsync(int id)
		{
			var product = await _ProductRepository.GetByIdAsync(id);

			if (product == null) return null;

			return new ProductDTO
			{
				Id = product.Id,
				Name = product.Name,
				BrandId = product.BrandId,
				CategoryId = product.CategoryId,
				AreaId = product.AreaId,
				UnitMeasureId = product.UnitMeasureId,
				Quantity = product.Quantity,
				CurrentPrice = product.CurrentPrice,
				ImageUrl = product.ImageUrl,
				CreatedAt = product.CreatedAt,
				UpdatedAt = product.UpdatedAt,
			};
		}

		public async Task<ProductDTO> CreateAsync(ProductDTO dto)
		{
			var newProduct = new LdsProduct
			{
				Name = dto.Name,
				BrandId = dto.BrandId,
				CategoryId = dto.CategoryId,
				AreaId = dto.AreaId,
				UnitMeasureId = dto.UnitMeasureId,
				Quantity = dto.Quantity,
				CurrentPrice = dto.CurrentPrice,
				ImageUrl = dto.ImageUrl,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow,
			};

			using (var scope = new TransactionScope(TransactionScopeOption.Required, 
				new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
				TransactionScopeAsyncFlowOption.Enabled))
			{
				await _ProductRepository.CreateAsync(newProduct);

				var priceHistory = new LdsPriceHistory
				{
					ProductId = newProduct.Id,
					Price = dto.CurrentPrice,
					StartDate = DateOnly.FromDateTime(DateTime.UtcNow),
				};

				await _PriceHistoryRepository.CreateAsync(priceHistory);

				scope.Complete();
			}

			dto.Id = newProduct.Id;
			dto.Name = newProduct.Name;
			dto.BrandId = newProduct.BrandId;
			dto.CategoryId = newProduct.CategoryId;
			dto.AreaId = newProduct.AreaId;
			dto.UnitMeasureId = newProduct.UnitMeasureId;
			dto.Quantity = newProduct.Quantity;
			dto.CurrentPrice = newProduct.CurrentPrice;
			dto.ImageUrl = newProduct.ImageUrl;
			dto.CreatedAt = newProduct.CreatedAt;
			dto.UpdatedAt = newProduct.UpdatedAt;

			return dto;
		}

		public async Task<ProductDTO?> UpdateAsync(ProductDTO dto)
		{
			var existing = await _ProductRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			decimal previousPrice = existing.CurrentPrice;

			existing.Id = dto.Id;
			existing.Name = dto.Name;
			existing.BrandId = dto.BrandId;
			existing.CategoryId = dto.CategoryId;
			existing.AreaId = dto.AreaId;
			existing.UnitMeasureId = dto.UnitMeasureId;
			existing.Quantity = dto.Quantity;
			existing.CurrentPrice = dto.CurrentPrice;
			existing.ImageUrl = dto.ImageUrl;
			existing.UpdatedAt = DateTime.UtcNow;

			using (var scope = new TransactionScope(TransactionScopeOption.Required,
				new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted },
				TransactionScopeAsyncFlowOption.Enabled))
			{
				// If the price has changed, add a new price history record
				if (existing.CurrentPrice != previousPrice)
				{
					var priceHistory = new PriceHistoryDTO
					{
						ProductId = existing.Id,
						Price = dto.CurrentPrice,
						StartDate = DateOnly.FromDateTime(DateTime.UtcNow),
					};

					await _PriceHistoryService.UpsertAsync(priceHistory);
				}

				await _ProductRepository.UpdateAsync(existing);

				scope.Complete();
			}

			return new ProductDTO
			{
				Id = existing.Id,
				Name = existing.Name,
				BrandId = existing.BrandId,
				CategoryId = existing.CategoryId,
				AreaId = existing.AreaId,
				UnitMeasureId = existing.UnitMeasureId,
				Quantity = existing.Quantity,
				CurrentPrice = existing.CurrentPrice,
				ImageUrl = existing.ImageUrl,
				CreatedAt = existing.CreatedAt,
				UpdatedAt = existing.UpdatedAt,
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _ProductRepository.GetByIdAsync(id);
			if (existing == null) return false;

			await _ProductRepository.DeleteAsync(id);
			return true;
		}
	}
}
