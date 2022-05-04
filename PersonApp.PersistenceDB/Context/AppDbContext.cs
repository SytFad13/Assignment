using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonApp.Domain.POCO;

namespace PersonApp.PersistenceDB
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Person> Persons { get; set; }

		public DbSet<Bank> Banks { get; set; }

		public DbSet<BankAccount> BankAccounts { get; set; }
	}
}
