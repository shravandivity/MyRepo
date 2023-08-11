using System;
namespace SchoolAPI_Web.Dto
{
	public class RegisterationRequestDto
	{
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public RegisterationRequestDto()
		{
		}
	}
}

