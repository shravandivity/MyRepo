﻿using System;
using SchoolAPI_Web.Models;

namespace SchoolAPI_Web.Services.IServices
{
	public interface IBaseService
	{
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}

