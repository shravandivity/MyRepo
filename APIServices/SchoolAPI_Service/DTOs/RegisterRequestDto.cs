using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI_Service.DTOs
{
	public class RegisterRequestDto
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string UserName { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string[] Roles { get; set; }
		public RegisterRequestDto()
		{
		}
	}
}

