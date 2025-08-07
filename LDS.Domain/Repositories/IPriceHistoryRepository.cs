using LDS.Domain.Models;

namespace LDS.Domain.Repositories
{
	public interface IPriceHistoryRepository
	{
		Task<List<LdsPriceHistory>> GetAllAsync();
		Task<LdsPriceHistory?> GetByIdAsync(int id);
		Task<LdsPriceHistory> CreateAsync(LdsPriceHistory entity);
		Task<LdsPriceHistory> UpdateAsync(LdsPriceHistory entity);
		Task<bool> DeleteAsync(int id);
	}
}
