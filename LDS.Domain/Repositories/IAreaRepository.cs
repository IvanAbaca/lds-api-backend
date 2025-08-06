using LDS.Domain.Models;

namespace LDS.Domain.Repositories
{
    public interface IAreaRepository
    {
		public Task<List<LdsArea>> GetAllAsync();
	}
}
