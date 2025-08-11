using LDS.Contracts.DTO;

namespace LDS.Domain.Services.Interfaces
{
	public interface IUnitMeasureService
	{
		Task<List<UnitMeasureDTO>> GetAllAsync();
		Task<UnitMeasureDTO?> GetByIdAsync(int id);
		Task<UnitMeasureDTO> CreateAsync(UnitMeasureDTO dto);
		Task<UnitMeasureDTO?> UpdateAsync(UnitMeasureDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}