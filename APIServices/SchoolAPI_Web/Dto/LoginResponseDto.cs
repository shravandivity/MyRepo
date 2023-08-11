using System;
namespace SchoolAPI_Web.Dto
{
	public class LoginResponseDto
	{
        public UserDto User { get; set; }
        public string jwtToken { get; set; }

        public LoginResponseDto()
		{
		}
	}
}

