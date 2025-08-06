using LDS.Contracts.DTO;

namespace LDS.Domain.Services.Interfaces
{
	public interface IAreaService
	{
		Task<List<AreaDTO>> GetAllAsync();
		Task<AreaDTO?> GetByIdAsync(int id);
		Task<AreaDTO> CreateAsync(AreaDTO dto);
		Task<AreaDTO?> UpdateAsync(AreaDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
