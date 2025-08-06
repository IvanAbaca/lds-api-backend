using LDS.Domain.Models;

namespace LDS.Domain.Services.Interfaces
{
    public interface IAreaService
    {
		public Task<List<LdsArea>> GetAllAsync();
	}
}
