using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;

namespace LDS.Domain.Services
{
	public class BrandService : IBrandService
	{
		private readonly IBrandRepository _BrandRepository;

		public BrandService(IBrandRepository BrandRepository)
		{
			_BrandRepository = BrandRepository;
		}

		public async Task<List<BrandDTO>> GetAllAsync()
		{
			var areas = await _BrandRepository.GetAllAsync();

			return areas.Select(a => new BrandDTO
			{
				Id = a.Id,
				Name = a.Name
			}).ToList();
		}

		public async Task<BrandDTO?> GetByIdAsync(int id)
		{
			var area = await _BrandRepository.GetByIdAsync(id);

			if (area == null) return null;

			return new BrandDTO
			{
				Id = area.Id,
				Name = area.Name
			};
		}

		public async Task<BrandDTO> CreateAsync(BrandDTO dto)
		{
			var newBrand = new LdsBrand
			{
				Name = dto.Name
			};

			await _BrandRepository.CreateAsync(newBrand);

			dto.Id = newBrand.Id;
			return dto;
		}

		public async Task<BrandDTO?> UpdateAsync(BrandDTO dto)
		{
			var existing = await _BrandRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			existing.Name = dto.Name;

			await _BrandRepository.UpdateAsync(existing);

			return new BrandDTO
			{
				Id = existing.Id,
				Name = existing.Name
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _BrandRepository.GetByIdAsync(id);
			if (existing == null) return false;

			await _BrandRepository.DeleteAsync(id);
			return true;
		}
	}
}
