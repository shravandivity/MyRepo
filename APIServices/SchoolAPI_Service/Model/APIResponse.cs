using System;
using System.Net;

namespace SchoolAPI_Service.Model
{
	public class APIResponse
	{
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

        public APIResponse()
		{
		}
	}
}

