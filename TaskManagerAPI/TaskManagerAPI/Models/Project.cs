using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
	public class Project
	{
		[Key]
		public int ProjectID { get; set; }
		public string ProjectName { get; set; }
		public DateTime DateOfStart { get; set; }
		public int TeamSize { get; set; }

		public Project()
		{
		}
	}

    public class ProjectView
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string DateOfStart { get; set; }
        public int TeamSize { get; set; }
    }
}

