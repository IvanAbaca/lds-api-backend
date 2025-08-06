using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
	public class AreaRepository : IAreaRepository
	{
		private readonly LDSContext _context;

		public AreaRepository(LDSContext context)
		{
			_context = context;
		}

		public async Task<List<LdsArea>> GetAllAsync()
		{
			return await _context.LdsAreas.ToListAsync();
		}

		public async Task<LdsArea?> GetByIdAsync(int id)
		{
			return await _context.LdsAreas.FindAsync(id);
		}

		public async Task<LdsArea> CreateAsync(LdsArea entity)
		{
			_context.LdsAreas.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<LdsArea> UpdateAsync(LdsArea entity)
		{
			_context.LdsAreas.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.LdsAreas.FindAsync(id);
			if (entity == null) return false;

			_context.LdsAreas.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
