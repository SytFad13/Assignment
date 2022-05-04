using System.ComponentModel.DataAnnotations;

namespace PersonApp.Domain.POCO
{
	public class BankAccount
	{
		[Key]
		public int BankAccountId { get; set; }
		public Bank Bank { get; set; }
		public string AccountNumber { get; set; }
	}
}
