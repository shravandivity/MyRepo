using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerMvc.Identity
{
	public class ApplicationUser:IdentityUser<String>
	{
		[NotMapped]
		public string Token { get; set; }

		[NotMapped]
		public string Role { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public int CountryID { get; set; }
		public bool RecieveNewsLetters { get; set; }

		public ApplicationUser()
		{
		}
	}
}

