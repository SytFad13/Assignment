using System;
using System.ComponentModel.DataAnnotations;

namespace PersonApp.Domain.POCO
{
	public class Person
	{
		[Key]
		public int PersonId { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string PersonalNumber { get; set; }
		[Required]
		public PersonGender Gender { get; set; }
		[Required]
		public bool Status { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
