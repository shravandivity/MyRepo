using System;
namespace SchoolAPI_Service.Model
{
	public class Student
	{
		public Guid StudentId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int RollNo { get; set; }
		public string Grade { get; set; }

		
		public Guid CorrespondenceId { get; set; }

		//Navigation Property
		
		public Correspondence Correspondence { get; set; }

		public Student()
		{
		}
	}
}

