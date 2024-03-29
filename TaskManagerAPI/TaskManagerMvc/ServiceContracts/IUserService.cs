﻿using System;
using TaskManagerMvc.Identity;
using TaskManagerMvc.ViewModels;

namespace TaskManagerMvc.ServiceContracts
{
	public interface IUserService
	{
		Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel);
		Task<ApplicationUser> Register(SignUpViewModel signUpViewModel);
        Task<ApplicationUser> GetUserByEmail(string Email);
    }
}

