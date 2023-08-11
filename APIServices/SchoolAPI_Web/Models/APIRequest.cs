using System;
using System.Security.AccessControl;
using static SchoolAPI_Web.Utility.SD;

namespace SchoolAPI_Web.Models
{
    public class APIRequest
	{
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }

        public APIRequest()
		{
		}
	}
}

