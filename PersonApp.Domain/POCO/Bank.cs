using System.ComponentModel.DataAnnotations;

namespace PersonApp.Domain.POCO
{
	public class Bank
	{
		[Key]
		public int BankId { get; set; }
		public string Name { get; set; }
		public string SwiftCode { get; set; }
	}
}
