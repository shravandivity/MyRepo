﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerMvc.Identity
{
	public class ApplicationUser:IdentityUser<String>
	{
		[NotMapped]
		public string Token { get; set; }

		public ApplicationUser()
		{
		}
	}
}
