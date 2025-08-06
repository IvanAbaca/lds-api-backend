using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;

namespace LDS.Domain.Services
{
	public class AreaService : IAreaService
	{
		private readonly IAreaRepository _areaRepository;

		public AreaService(IAreaRepository areaRepository)
		{
			_areaRepository = areaRepository;
		}

		public async Task<List<LdsArea>> GetAllAsync()
		{
			return await _areaRepository.GetAllAsync();
		}
	}
}
