﻿using System;
using Microsoft.AspNetCore.Identity;

namespace SchoolAPI_Service.Repository.IRepository
{
	public interface ITokenRepository
	{
		string CreateJwtToken(IdentityUser identityUser, List<string> roles);
	}
}

