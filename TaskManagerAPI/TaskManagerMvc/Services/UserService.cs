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
using TaskManagerMvc.Data;
using TaskManagerMvc.Models;

namespace TaskManagerMvc.Services
{
	public class UserService : IUserService
	{
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationRoleManager _roleManager;
        private readonly AppSettings _appSettings;

        public UserService(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager, IOptions<AppSettings> appSettings, ApplicationDbContext dbContext,ApplicationRoleManager roleManager)
		{
            this._applicationUserManager = applicationUserManager;
            this._applicationSignInManager = applicationSignInManager;
            this._dbContext = dbContext;
            this._roleManager = roleManager;
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

        public async Task<ApplicationUser> GetUserByEmail(string Email)
        {
            return await _applicationUserManager.FindByEmailAsync(Email);
        }

        public async Task<ApplicationUser> Register(SignUpViewModel signUpViewModel)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser.FirstName = signUpViewModel.PersonName.FirstName;
            appUser.LastName = signUpViewModel.PersonName.LastName;
            appUser.Email = signUpViewModel.Email;
            appUser.DateOfBirth = Convert.ToDateTime(signUpViewModel.DateOfBirth);
            appUser.PhoneNumber = signUpViewModel.Mobile;
            appUser.RecieveNewsLetters = signUpViewModel.RecieveNewsLetters;
            appUser.Gender = signUpViewModel.Gender;
            appUser.CountryID = signUpViewModel.CountryID;
            appUser.Role = "Employee";
            appUser.UserName = signUpViewModel.Email;
            appUser.Id = Guid.NewGuid().ToString();

            var result = await _applicationUserManager.CreateAsync(appUser, signUpViewModel.Password);
            if (result.Succeeded)
            {
                if (!await _applicationUserManager.IsInRoleAsync(appUser, "Employee"))
                {
                    var result3 = await _applicationUserManager.AddToRoleAsync(appUser, "Employee");
                }

                var result2 = await _applicationSignInManager.PasswordSignInAsync(signUpViewModel.Email, signUpViewModel.Password, false, false);
                if (result2.Succeeded)
                {
                    appUser.PasswordHash = null;

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, appUser.Id),
                        new Claim(ClaimTypes.Email, appUser.Email),
                        new Claim(ClaimTypes.Role, appUser.Role)
                        }),
                        Expires = DateTime.UtcNow.AddHours(9),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    appUser.Token = tokenHandler.WriteToken(token);

                    List<Skill> lstSkill = new List<Skill>();
                    foreach (var skill in signUpViewModel.Skills)
                    {
                        //Skill sk = new Skill { ApplicationUser = appUser, Id = appUser.Id, SkillLevel = signUpViewModel.Skills[i - 1].SkillLevel, SkillName = signUpViewModel.Skills[i - 1].SkillName };
                        lstSkill.Add(new Skill { ApplicationUser = appUser, Id = appUser.Id, SkillLevel = skill.SkillLevel, SkillName = skill.SkillName });
                        //await _dbContext.AddAsync(sk);
                        //await _dbContext.SaveChangesAsync();
                    }
                    if (lstSkill.Count() > 0)
                    {
                        _dbContext.AddRangeAsync(lstSkill);
                        _dbContext.SaveChangesAsync();
                    }
                    return appUser;
                }
                else
                    return null;
            }
            else
                return null;

        }
    }
}

