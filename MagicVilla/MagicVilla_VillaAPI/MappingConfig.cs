﻿using System;
using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<Villa, VillaDto>().ReverseMap();
			CreateMap<Villa, VillaCreateDto>().ReverseMap();
			CreateMap<Villa, VillaUpdateDto>().ReverseMap();
		}
	}
}

