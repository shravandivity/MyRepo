using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TaskManagerMvc.Models
{
	public class Project
	{
		[Key]
		public int ProjectID { get; set; }
		public string ProjectName { get; set; }
		public DateTime DateOfStart { get; set; }
		public int? TeamSize { get; set; }
		public bool Active { get; set; }
		public string Status { get; set; }

		public int ClientLocationId { get; set; }

        [ForeignKey("ClientLocationId")]
		[ValidateNever]
        public virtual ClientLocation ClientLocation { get; set; }


        public Project()
		{
		}
	}

	
}

