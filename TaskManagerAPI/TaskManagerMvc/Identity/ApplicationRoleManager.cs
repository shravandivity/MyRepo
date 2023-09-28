using System;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerMvc.Identity
{
	public class ApplicationRoleManager:RoleManager<ApplicationRole>
	{
		public ApplicationRoleManager(ApplicationRoleStore applicationRoleStore , IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
			ILookupNormalizer lookupNormalizer, IdentityErrorDescriber identityErrorDescriber, ILogger<ApplicationRoleManager> logger):base(applicationRoleStore,roleValidators,lookupNormalizer,identityErrorDescriber,logger)
		{
		}
	}
}

