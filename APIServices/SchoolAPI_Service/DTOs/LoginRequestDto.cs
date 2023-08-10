using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI_Service.DTOs
{
	public class LoginRequestDto
	{
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginRequestDto()
		{
		}
	}
}

