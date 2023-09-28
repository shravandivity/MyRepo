using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManagerMvc.Data;

namespace TaskManagerMvc.Identity
{
	public class ApplicationRoleStore:RoleStore<ApplicationRole,ApplicationDbContext>
	{
		public ApplicationRoleStore(ApplicationDbContext dbContext,IdentityErrorDescriber identityErrorDescriber):base(dbContext,identityErrorDescriber)
		{
		}
	}
}

