using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly LDSContext _context;

		public ProductRepository(LDSContext context)
		{
			_context = context;
		}

		public async Task<List<LdsProduct>> GetAllAsync()
		{
			return await _context.LdsProducts.ToListAsync();
		}

		public async Task<LdsProduct?> GetByIdAsync(int id)
		{
			return await _context.LdsProducts.FindAsync(id);
		}

		public async Task<LdsProduct> CreateAsync(LdsProduct entity)
		{
			_context.LdsProducts.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<LdsProduct> UpdateAsync(LdsProduct entity)
		{
			_context.LdsProducts.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.LdsProducts.FindAsync(id);
			if (entity == null) return false;

			_context.LdsProducts.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
