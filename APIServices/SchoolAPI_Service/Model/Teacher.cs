using System;
namespace SchoolAPI_Service.Model
{
	public class Teacher
	{
        public Guid TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassRoom { get; set; }

        public Guid SubjectId { get; set; }
        public Guid CorrespondenceId { get; set; }

        //Navigation Properties
        public Subject Subject { get; set; }
        public Correspondence Correspondence { get; set; }

        public Teacher()
		{
		}
	}
}

