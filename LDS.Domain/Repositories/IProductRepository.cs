using LDS.Domain.Models;

namespace LDS.Domain.Repositories
{
	public interface IProductRepository
	{
		Task<List<LdsProduct>> GetAllAsync();
		Task<LdsProduct?> GetByIdAsync(int id);
		Task<LdsProduct> CreateAsync(LdsProduct entity);
		Task<LdsProduct> UpdateAsync(LdsProduct entity);
		Task<bool> DeleteAsync(int id);
	}
}
