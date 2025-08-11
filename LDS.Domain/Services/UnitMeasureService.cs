using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;

namespace LDS.Domain.Services
{
	public class UnitMeasureService : IUnitMeasureService
	{
		private readonly IUnitMeasureRepository _UnitMeasureRepository;

		public UnitMeasureService(IUnitMeasureRepository UnitMeasureRepository)
		{
			_UnitMeasureRepository = UnitMeasureRepository;
		}

		public async Task<List<UnitMeasureDTO>> GetAllAsync()
		{
			var unitMeasures = await _UnitMeasureRepository.GetAllAsync();

			return unitMeasures.Select(um => new UnitMeasureDTO
			{
				Id = um.Id,
				Name = um.Name
			}).ToList();
		}

		public async Task<UnitMeasureDTO?> GetByIdAsync(int id)
		{
			var unitMeasure = await _UnitMeasureRepository.GetByIdAsync(id);

			if (unitMeasure == null) return null;

			return new UnitMeasureDTO
			{
				Id = unitMeasure.Id,
				Name = unitMeasure.Name
			};
		}

		public async Task<UnitMeasureDTO> CreateAsync(UnitMeasureDTO dto)
		{
			var newUnitMeasure = new LdsUnitMeasure
			{
				Name = dto.Name
			};

			await _UnitMeasureRepository.CreateAsync(newUnitMeasure);

			dto.Id = newUnitMeasure.Id;
			return dto;
		}

		public async Task<UnitMeasureDTO?> UpdateAsync(UnitMeasureDTO dto)
		{
			var existing = await _UnitMeasureRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			existing.Name = dto.Name;

			await _UnitMeasureRepository.UpdateAsync(existing);

			return new UnitMeasureDTO
			{
				Id = existing.Id,
				Name = existing.Name
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _UnitMeasureRepository.GetByIdAsync(id);
			if (existing == null) return false;

			await _UnitMeasureRepository.DeleteAsync(id);
			return true;
		}
	}
}
