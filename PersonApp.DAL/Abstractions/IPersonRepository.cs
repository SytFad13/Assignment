using System.Collections.Generic;
using System.Threading.Tasks;
using PersonApp.Domain.POCO;

namespace PersonApp.DAL.Abstractions
{
	public interface IPersonRepository : IRepository<Person>
	{
		Task<Person> GetByNameAsync(string firstName);
		Task<ICollection<Person>> GetByTextAsync(string text);
	}
}
