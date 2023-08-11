using System;
using SchoolAPI_Web.Dto;
using SchoolAPI_Web.Models;
using SchoolAPI_Web.Services.IServices;
using SchoolAPI_Web.Utility;

namespace SchoolAPI_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string schoolAPIUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            schoolAPIUrl = configuration.GetValue<string>("ServiceUrls:SchoolAPI");

        }

        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = schoolAPIUrl + "/api/Auth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDto obj)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = schoolAPIUrl + "/api/Auth/register"
            });
        }
    }
}

