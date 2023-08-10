using System;
namespace SchoolAPI_Service.DTOs
{
	public class StudentDto
	{
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }
        public string Grade { get; set; }

        
        public CorrespondenceDto Correspondence { get; set; }

        public StudentDto()
		{
		}
	}
}

