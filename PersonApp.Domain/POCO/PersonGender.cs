using System.ComponentModel.DataAnnotations;

namespace PersonApp.Domain.POCO
{
	public class PersonGender
	{
		[Key]
		public int GenderId { get; set; }
		[Required]
		public bool Gender { get; set; }
	}
}
