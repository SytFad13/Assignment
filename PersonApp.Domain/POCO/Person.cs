using System.ComponentModel.DataAnnotations;

namespace PersonApp.Domain.POCO
{
	public class Person
	{
		[Key]
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public BankAccount BankAccount { get; set; }
	}
}
