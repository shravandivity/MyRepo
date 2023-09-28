using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManagerMvc.Data;

namespace TaskManagerMvc.Identity
{
	public class ApplicationUserStore:UserStore<ApplicationUser>
	{
		public ApplicationUserStore(ApplicationDbContext options):base(options)
		{
		}
	}
}

