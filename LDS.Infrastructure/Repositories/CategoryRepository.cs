using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly LDSContext _context;

		public CategoryRepository(LDSContext context)
		{
			_context = context;
		}

		public async Task<List<LdsCategory>> GetAllAsync()
		{
			return await _context.LdsCategories.ToListAsync();
		}

		public async Task<LdsCategory?> GetByIdAsync(int id)
		{
			return await _context.LdsCategories.FindAsync(id);
		}

		public async Task<LdsCategory> CreateAsync(LdsCategory entity)
		{
			_context.LdsCategories.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<LdsCategory> UpdateAsync(LdsCategory entity)
		{
			_context.LdsCategories.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.LdsCategories.FindAsync(id);
			if (entity == null) return false;

			_context.LdsCategories.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
