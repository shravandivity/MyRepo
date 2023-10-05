using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerMvc.Models
{
	public class Country
	{
		[Key]
		public int CountryID { get; set; }
		public string CountryName { get; set; }

		public Country()
		{
		}
	}
}

