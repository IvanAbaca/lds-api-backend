using LDS.Contracts.DTO;

namespace LDS.Domain.Services.Interfaces
{
	public interface IPriceHistoryService
	{
		Task<List<PriceHistoryDTO>> GetAllAsync();
		Task<PriceHistoryDTO?> GetByIdAsync(int id);
		Task<PriceHistoryDTO> CreateAsync(PriceHistoryDTO dto);
		Task<PriceHistoryDTO?> UpdateAsync(PriceHistoryDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
