using System;
using AutoMapper;
using SchoolAPI_Service.DTOs;
using SchoolAPI_Service.Model;

namespace SchoolAPI_Service.Mapping
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Correspondence, CorrespondenceDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
	}
}

