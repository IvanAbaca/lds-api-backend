using LDS.Domain.Models;
using LDS.Domain.Repositories;
using LDS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LDS.Infrastructure.Repositories
{
	public class PriceHistoryRepository : IPriceHistoryRepository
	{
		private readonly LDSContext _context;

		public PriceHistoryRepository(LDSContext context)
		{
			_context = context;
		}

		public async Task<List<LdsPriceHistory>> GetAllAsync()
		{
			return await _context.LdsPriceHistories.ToListAsync();
		}

		public async Task<LdsPriceHistory?> GetByIdAsync(int id)
		{
			return await _context.LdsPriceHistories.FindAsync(id);
		}

		public async Task<LdsPriceHistory> CreateAsync(LdsPriceHistory entity)
		{
			_context.LdsPriceHistories.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<LdsPriceHistory> UpdateAsync(LdsPriceHistory entity)
		{
			_context.LdsPriceHistories.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _context.LdsPriceHistories.FindAsync(id);
			if (entity == null) return false;

			_context.LdsPriceHistories.Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
