using LDS.Domain.Models;

namespace LDS.Domain.Repositories
{
	public interface IBrandRepository
	{
		Task<List<LdsBrand>> GetAllAsync();
		Task<LdsBrand?> GetByIdAsync(int id);
		Task<LdsBrand> CreateAsync(LdsBrand entity);
		Task<LdsBrand> UpdateAsync(LdsBrand entity);
		Task<bool> DeleteAsync(int id);
	}
}
