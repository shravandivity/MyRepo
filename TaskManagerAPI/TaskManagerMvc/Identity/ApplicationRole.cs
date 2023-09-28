using System;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerMvc.Identity
{
	public class ApplicationRole:IdentityRole<String> 
	{
		public ApplicationRole()
		{
		}
	}
}

