using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
	public class BrandRepository : IBrandRepository
	{
		private readonly LDSContext _context;

		public BrandRepository(LDSContext context)
		{
			_context = context;
		}

		public async Task<List<LdsBrand>> GetAllAsync()
		{
			return await _context.LdsBrands.ToListAsync();
		}

		public async Task<LdsBrand?> GetByIdAsync(int id)
		{
			return await _context.LdsBrands.FindAsync(id);
		}

		public async Task<LdsBrand> CreateAsync(LdsBrand entity)
		{
			_context.LdsBrands.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<LdsBrand> UpdateAsync(LdsBrand entity)
		{
			_context.LdsBrands.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.LdsBrands.FindAsync(id);
			if (entity == null) return false;

			_context.LdsBrands.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
