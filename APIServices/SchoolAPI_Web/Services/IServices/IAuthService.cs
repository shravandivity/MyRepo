using System;
using SchoolAPI_Web.Dto;

namespace SchoolAPI_Web.Services.IServices
{
	public interface IAuthService
	{
        Task<T> LoginAsync<T>(LoginRequestDto objToCreate);
        Task<T> RegisterAsync<T>(RegisterationRequestDto objToCreate);
    }
}

