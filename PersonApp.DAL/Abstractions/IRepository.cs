using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonApp.DAL.Abstractions
{
	public interface IRepository<T>
	{
		Task<ICollection<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> CreateAsync(T model);
		Task<T> UpdateAsync(T model);
		Task DeleteAsync(T model);
	}
}
