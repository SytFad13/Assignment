using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonApp.DAL.Abstractions;
using PersonApp.Domain.POCO;
using PersonApp.PersistenceDB;

namespace PersonApp.DAL.Implementations
{
	public class PersonRepository : IPersonRepository
	{
		private readonly AppDbContext _dbContext;

		public PersonRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Person> CreateAsync(Person person)
		{
			await _dbContext.Persons.AddAsync(person);
			await _dbContext.SaveChangesAsync();
			return person;
		}

		public async Task DeleteAsync(Person person)
		{
			_dbContext.Persons.Remove(person);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<ICollection<Person>> GetAllAsync()
		{
			return await _dbContext.Persons.AsNoTracking().ToListAsync();
		}

		public async Task<Person> GetByIdAsync(int id)
		{
			return await _dbContext.Persons.AsNoTracking().FirstOrDefaultAsync(c => c.PersonId == id);
		}

		public async Task<Person> GetByNameAsync(string firstName)
		{
			var person = await _dbContext.Persons.FirstOrDefaultAsync(a => a.FirstName == firstName);

			return person;
		}

		public async Task<ICollection<Person>> GetByTextAsync(string text)
		{
			var persons = await _dbContext.Persons.Where(p => (p.FirstName + " " + p.LastName).Contains(text)).ToListAsync();

			return persons;
		}

		public async Task<Person> UpdateAsync(Person person)
		{
			_dbContext.Persons.Update(person);
			await _dbContext.SaveChangesAsync();

			return person;
		}
	}
}
