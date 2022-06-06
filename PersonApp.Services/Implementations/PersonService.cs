using System.Collections.Generic;
using System.Threading.Tasks;
using PersonApp.DAL.Abstractions;
using PersonApp.Domain.POCO;
using PersonApp.Services.Abstractions;

namespace PersonApp.Services.Implementations
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepo;

		public PersonService(IPersonRepository personRepo)
		{
			_personRepo = personRepo;
		}

		public async Task<ICollection<Person>> GetAllAsync()
		{
			var person = await _personRepo.GetAllAsync();

			return person;
		}

		public async Task<Person> GetByIdAsync(int id)
		{
			var person = await _personRepo.GetByIdAsync(id);

			return person;
		}

		public async Task<Person> GetByName(string firstName)
		{
			var person = await _personRepo.GetByNameAsync(firstName);

			return person;
		}

		public async Task<ICollection<Person>> GetByText(string text)
		{
			var persons = await _personRepo.GetByTextAsync(text);

			return persons;
		}

		public async Task<Person> CreateAsync(Person person)
		{
			var personInDb = await _personRepo.GetByNameAsync(person.FirstName);

			if (personInDb != null)
			{
				return null;
			}

			await _personRepo.CreateAsync(person);

			return person;
		}

		public async Task<Person> UpdateAsync(Person person)
		{
			var personInDb = await _personRepo.GetByIdAsync(person.PersonId);

			if (personInDb == null)
			{
				return null;
			}

			await _personRepo.UpdateAsync(person);

			return person;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var person = await _personRepo.GetByIdAsync(id);

			if (person == null)
			{
				return false;
			}

			await _personRepo.DeleteAsync(person);

			return true;
		}
	}
}
