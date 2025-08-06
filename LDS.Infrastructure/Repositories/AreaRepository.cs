using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
		private readonly LDSContext _LDSContext;

		public AreaRepository(LDSContext context)
		{
			_LDSContext = context;
		}

		public async Task<List<LdsArea>> GetAllAsync()
		{
			return await _LDSContext.LdsAreas.ToListAsync();
		}
	}
}
