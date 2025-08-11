using LDS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDS.Domain.Repositories
{
	public interface IUnitMeasureRepository
	{
		Task<List<LdsUnitMeasure>> GetAllAsync();
		Task<LdsUnitMeasure?> GetByIdAsync(int id);
		Task<LdsUnitMeasure> CreateAsync(LdsUnitMeasure entity);
		Task<LdsUnitMeasure> UpdateAsync(LdsUnitMeasure entity);
		Task<bool> DeleteAsync(int id);
	}
}
