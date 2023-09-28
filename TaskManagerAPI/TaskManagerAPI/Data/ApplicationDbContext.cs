using System;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions options):base(options)
		{
		}

		public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectID = 1, ProjectName = "Angular", DateOfStart = Convert.ToDateTime("01/01/2002"), TeamSize = 24 },
                new Project { ProjectID = 2, ProjectName = "Java", DateOfStart = Convert.ToDateTime("02/02/2003"), TeamSize = 26 },
                new Project { ProjectID = 3, ProjectName = ".Net", DateOfStart = Convert.ToDateTime("01/05/2004"), TeamSize = 28 },
                new Project { ProjectID = 4, ProjectName = "SQL", DateOfStart = Convert.ToDateTime("04/05/2005"), TeamSize = 40 },
                new Project { ProjectID = 5, ProjectName = "Oracle", DateOfStart = Convert.ToDateTime("01/01/2007"), TeamSize = 44 }

                );
        }
    }
}

