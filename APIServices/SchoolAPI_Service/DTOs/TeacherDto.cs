using System;
namespace SchoolAPI_Service.DTOs
{
	public class TeacherDto
	{
        public Guid TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassRoom { get; set; }

        public SubjectDto Subject { get; set; }
        public CorrespondenceDto Correspondence { get; set; }

        public TeacherDto()
		{
		}
	}
}

