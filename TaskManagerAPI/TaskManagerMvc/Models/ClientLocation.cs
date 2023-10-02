using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerMvc.Models
{
	public class ClientLocation
	{
		[Key]
		public int ClientLocationId { get; set; }
		public string ClientLocationName { get; set; }


		public ClientLocation()
		{
		}
	}
}

