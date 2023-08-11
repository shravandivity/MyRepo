using System;
namespace SchoolAPI_Service.DTOs
{
	public class LoginResponseDto
	{
        public UserDto User { get; set; }
        public string JwtToken { get; set; }

		public LoginResponseDto()
		{
		}
	}
}

