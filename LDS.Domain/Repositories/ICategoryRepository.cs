using LDS.Domain.Models;

namespace LDS.Domain.Repositories
{
	public interface ICategoryRepository
	{
		Task<List<LdsCategory>> GetAllAsync();
		Task<LdsCategory?> GetByIdAsync(int id);
		Task<LdsCategory> CreateAsync(LdsCategory entity);
		Task<LdsCategory> UpdateAsync(LdsCategory entity);
		Task<bool> DeleteAsync(int id);
	}
}
