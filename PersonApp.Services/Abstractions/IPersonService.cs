using System.Collections.Generic;
using System.Threading.Tasks;
using PersonApp.Domain.POCO;

namespace PersonApp.Services.Abstractions
{
	public interface IPersonService : IService<Person>
	{
		Task<Person> GetByName(string firstName);
		Task<ICollection<Person>> GetByText(string text);
	}
}
