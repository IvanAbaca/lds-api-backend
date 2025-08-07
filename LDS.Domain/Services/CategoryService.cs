using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;

namespace LDS.Domain.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _CategoryRepository;

		public CategoryService(ICategoryRepository CategoryRepository)
		{
			_CategoryRepository = CategoryRepository;
		}

		public async Task<List<CategoryDTO>> GetAllAsync()
		{
			var areas = await _CategoryRepository.GetAllAsync();

			return areas.Select(a => new CategoryDTO
			{
				Id = a.Id,
				Name = a.Name
			}).ToList();
		}

		public async Task<CategoryDTO?> GetByIdAsync(int id)
		{
			var area = await _CategoryRepository.GetByIdAsync(id);

			if (area == null) return null;

			return new CategoryDTO
			{
				Id = area.Id,
				Name = area.Name
			};
		}

		public async Task<CategoryDTO> CreateAsync(CategoryDTO dto)
		{
			var newCategory = new LdsCategory
			{
				Name = dto.Name
			};

			await _CategoryRepository.CreateAsync(newCategory);

			dto.Id = newCategory.Id;
			return dto;
		}

		public async Task<CategoryDTO?> UpdateAsync(CategoryDTO dto)
		{
			var existing = await _CategoryRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			existing.Name = dto.Name;

			await _CategoryRepository.UpdateAsync(existing);

			return new CategoryDTO
			{
				Id = existing.Id,
				Name = existing.Name
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _CategoryRepository.GetByIdAsync(id);
			if (existing == null) return false;

			await _CategoryRepository.DeleteAsync(id);
			return true;
		}
	}
}
