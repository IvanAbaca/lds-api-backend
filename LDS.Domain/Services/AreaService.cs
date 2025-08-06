using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;

namespace LDS.Domain.Services
{
	public class AreaService : IAreaService
	{
		private readonly IAreaRepository _AreaRepository;

		public AreaService(IAreaRepository AreaRepository)
		{
			_AreaRepository = AreaRepository;
		}

		public async Task<List<AreaDTO>> GetAllAsync()
		{
			var areas = await _AreaRepository.GetAllAsync();

			return areas.Select(a => new AreaDTO
			{
				Id = a.Id,
				Name = a.Name
			}).ToList();
		}

		public async Task<AreaDTO?> GetByIdAsync(int id)
		{
			var area = await _AreaRepository.GetByIdAsync(id);

			if (area == null) return null;

			return new AreaDTO
			{
				Id = area.Id,
				Name = area.Name
			};
		}

		public async Task<AreaDTO> CreateAsync(AreaDTO dto)
		{
			var newArea = new LdsArea
			{
				Name = dto.Name
			};

			await _AreaRepository.CreateAsync(newArea);

			dto.Id = newArea.Id;
			return dto;
		}

		public async Task<AreaDTO?> UpdateAsync(AreaDTO dto)
		{
			var existing = await _AreaRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			existing.Name = dto.Name;

			await _AreaRepository.UpdateAsync(existing);

			return new AreaDTO
			{
				Id = existing.Id,
				Name = existing.Name
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _AreaRepository.GetByIdAsync(id);
			if (existing == null) return false;

			await _AreaRepository.DeleteAsync(id);
			return true;
		}
	}
}
