﻿using System;
namespace SchoolAPI_Service.DTOs
{
	public class UserDto
	{
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public UserDto()
		{
		}
	}
}

