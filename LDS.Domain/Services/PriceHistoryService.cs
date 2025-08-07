using LDS.Domain.Repositories;
using LDS.Domain.Services.Interfaces;
using LDS.Domain.Models;
using LDS.Contracts.DTO;

namespace LDS.Domain.Services
{
	public class PriceHistoryService : IPriceHistoryService
	{
		private readonly IPriceHistoryRepository _PriceHistoryRepository;

		public PriceHistoryService(IPriceHistoryRepository PriceHistoryRepository)
		{
			_PriceHistoryRepository = PriceHistoryRepository;
		}

		public async Task<List<PriceHistoryDTO>> GetAllAsync()
		{
			var priceHistories = await _PriceHistoryRepository.GetAllAsync();

			return priceHistories.Select(ph => new PriceHistoryDTO
			{
				Id = ph.Id,
				ProductId = ph.ProductId,
				Price = ph.Price,
				StartDate = ph.StartDate
			}).ToList();
		}

		public async Task<PriceHistoryDTO?> GetByIdAsync(int id)
		{
			var priceHistory = await _PriceHistoryRepository.GetByIdAsync(id);

			if (priceHistory == null) return null;

			return new PriceHistoryDTO
			{
				Id = priceHistory.Id,
				ProductId = priceHistory.ProductId,
				Price = priceHistory.Price,
				StartDate = priceHistory.StartDate
			};
		}

		public async Task<PriceHistoryDTO> CreateAsync(PriceHistoryDTO dto)
		{
			var newPriceHistory = new LdsPriceHistory
			{
				ProductId = dto.ProductId,
				Price = dto.Price,
				StartDate = dto.StartDate
			};

			await _PriceHistoryRepository.CreateAsync(newPriceHistory);

			dto.Id = newPriceHistory.Id;
			dto.ProductId = newPriceHistory.ProductId;
			dto.Price = newPriceHistory.Price;
			dto.StartDate = newPriceHistory.StartDate;

			return dto;
		}

		public async Task<PriceHistoryDTO?> UpdateAsync(PriceHistoryDTO dto)
		{
			var existing = await _PriceHistoryRepository.GetByIdAsync(dto.Id);
			if (existing == null) return null;

			existing.ProductId = dto.ProductId;
			existing.Price = dto.Price;
			existing.StartDate = dto.StartDate;

			await _PriceHistoryRepository.UpdateAsync(existing);

			return new PriceHistoryDTO
			{
				Id = existing.Id,
				ProductId = existing.ProductId,
				Price = existing.Price,
				StartDate = existing.StartDate
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _PriceHistoryRepository.GetByIdAsync(id);
			if (existing == null) return false;

			await _PriceHistoryRepository.DeleteAsync(id);
			return true;
		}
	}
}
