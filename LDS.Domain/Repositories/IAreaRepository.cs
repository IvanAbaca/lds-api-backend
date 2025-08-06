using LDS.Domain.Models;

namespace LDS.Domain.Repositories
{
    public interface IAreaRepository
    {
		Task<List<LdsArea>> GetAllAsync();
		Task<LdsArea?> GetByIdAsync(int id);
		Task<LdsArea> CreateAsync(LdsArea entity);
		Task<LdsArea> UpdateAsync(LdsArea entity);
		Task<bool> DeleteAsync(int id);
	}
}
