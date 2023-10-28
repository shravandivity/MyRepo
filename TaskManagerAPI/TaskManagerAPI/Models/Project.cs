using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerAPI.Models
{
	public class Project
	{
        
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int? TeamSize { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }

       
        public virtual ClientLocation ClientLocation { get; set; }

        public Project()
		{
		}
	}

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
    }

    public class ClientLocation
    {
        [Key]
        public int ClientLocationId { get; set; }
        public string ClientLocationName { get; set; }


        public ClientLocation()
        {
        }
    }
}

