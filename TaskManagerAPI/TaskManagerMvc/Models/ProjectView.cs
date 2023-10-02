using System;
namespace TaskManagerMvc.Models
{
	public class ProjectView
	{
        
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int? TeamSize { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }
        public int ClientLocationId { get; set; }
        public ClientLocation ClientLocation { get; set; }


        public ProjectView()
		{
		}
	}
}

