using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
	public class UnitMeasureRepository : IUnitMeasureRepository
	{
		private readonly LDSContext _context;

		public UnitMeasureRepository(LDSContext context)
		{
			_context = context;
		}

		public async Task<List<LdsUnitMeasure>> GetAllAsync()
		{
			return await _context.LdsUnitMeasures.ToListAsync();
		}

		public async Task<LdsUnitMeasure?> GetByIdAsync(int id)
		{
			return await _context.LdsUnitMeasures.FindAsync(id);
		}

		public async Task<LdsUnitMeasure> CreateAsync(LdsUnitMeasure entity)
		{
			_context.LdsUnitMeasures.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<LdsUnitMeasure> UpdateAsync(LdsUnitMeasure entity)
		{
			_context.LdsUnitMeasures.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.LdsUnitMeasures.FindAsync(id);
			if (entity == null) return false;

			_context.LdsUnitMeasures.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
