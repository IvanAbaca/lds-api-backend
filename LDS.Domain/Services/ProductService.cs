using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;

namespace LDS.Domain.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _ProductRepository;

		public ProductService(IProductRepository ProductRepository)
		{
			_ProductRepository = ProductRepository;
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
				ImageUrl = p.ImageUrl,
				BaseName = p.BaseName,
				Quantity = p.Quantity,
				Unit = p.Unit,
				CreatedAt = p.CreatedAt
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
				ImageUrl = product.ImageUrl,
				BaseName = product.BaseName,
				Quantity = product.Quantity,
				Unit = product.Unit,
				CreatedAt = product.CreatedAt
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
				ImageUrl = dto.ImageUrl,
				BaseName = dto.BaseName,
				Quantity = dto.Quantity,
				Unit = dto.Unit,
				CreatedAt = dto.CreatedAt
			};

			await _ProductRepository.CreateAsync(newProduct);

			dto.Id = newProduct.Id;
			dto.Name = newProduct.Name;
			dto.BrandId = newProduct.BrandId;
			dto.CategoryId = newProduct.CategoryId;
			dto.AreaId = newProduct.AreaId;
			dto.ImageUrl = newProduct.ImageUrl;
			dto.BaseName = newProduct.BaseName;
			dto.Quantity = newProduct.Quantity;
			dto.Unit = newProduct.Unit;
			dto.CreatedAt = newProduct.CreatedAt;

			return dto;
		}

		public async Task<ProductDTO?> UpdateAsync(ProductDTO dto)
		{
			var existing = await _ProductRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			existing.Name = dto.Name;
			existing.BrandId = dto.BrandId;
			existing.CategoryId = dto.CategoryId;
			existing.AreaId = dto.AreaId;
			existing.ImageUrl = dto.ImageUrl;
			existing.BaseName = dto.BaseName;
			existing.Quantity = dto.Quantity;
			existing.Unit = dto.Unit;

			await _ProductRepository.UpdateAsync(existing);

			return new ProductDTO
			{
				Id = existing.Id,
				Name = existing.Name,
				BrandId = existing.BrandId,
				CategoryId = existing.CategoryId,
				AreaId = existing.AreaId,
				ImageUrl = existing.ImageUrl,
				BaseName = existing.BaseName,
				Quantity = existing.Quantity,
				Unit = existing.Unit,
				CreatedAt = existing.CreatedAt
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
