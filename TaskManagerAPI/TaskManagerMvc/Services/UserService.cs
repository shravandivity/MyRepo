using System;
using TaskManagerMvc.Identity;
using TaskManagerMvc.ServiceContracts;
using TaskManagerMvc.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TaskManagerMvc.Services
{
	public class UserService : IUserService
	{
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly AppSettings _appSettings;

        public UserService(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager, IOptions<AppSettings> appSettings)
		{
            this._applicationUserManager = applicationUserManager;
            this._applicationSignInManager = applicationSignInManager;
            this._appSettings = appSettings.Value;
        }

        public async Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel)
        {
            var result = await _applicationSignInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            if(result.Succeeded)
            {
                var applicationUser = await _applicationUserManager.FindByNameAsync(loginViewModel.UserName);
                applicationUser.PasswordHash = null;
                if (await this._applicationUserManager.IsInRoleAsync(applicationUser, "Admin"))
                    applicationUser.Role = "Admin";
                if (await this._applicationUserManager.IsInRoleAsync(applicationUser, "Employee"))
                    applicationUser.Role = "Employee";
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, applicationUser.Id),
                        new Claim(ClaimTypes.Email, applicationUser.Email),
                        new Claim(ClaimTypes.Role, applicationUser.Role)
                    }),
                    Expires = DateTime.UtcNow.AddHours(9),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                applicationUser.Token = tokenHandler.WriteToken(token);
                return applicationUser;
            }
            else
            {
                return null;
            }
        }
    }
}

