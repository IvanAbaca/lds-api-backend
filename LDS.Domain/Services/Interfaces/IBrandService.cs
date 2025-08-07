using LDS.Contracts.DTO;

namespace LDS.Domain.Services.Interfaces
{
	public interface IBrandService
	{
		Task<List<BrandDTO>> GetAllAsync();
		Task<BrandDTO?> GetByIdAsync(int id);
		Task<BrandDTO> CreateAsync(BrandDTO dto);
		Task<BrandDTO?> UpdateAsync(BrandDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
