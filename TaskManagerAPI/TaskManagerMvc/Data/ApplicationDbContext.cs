using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManagerMvc.Models;
using Microsoft.AspNetCore.Identity;
using TaskManagerMvc.Identity;

namespace TaskManagerMvc.Data
{
	public class ApplicationDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,String>
	{
		public ApplicationDbContext(DbContextOptions options):base(options)
		{
		}

		public DbSet<Project> Projects { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityRole> ApplicationRoles { get; set; }
        public DbSet<ClientLocation> ClientLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //SeedRoles(modelBuilder);

			

            modelBuilder.Entity<ClientLocation>().HasData(
                new ClientLocation { ClientLocationId = 1, ClientLocationName = "Boston" },
                new ClientLocation { ClientLocationId = 2, ClientLocationName = "New Delhi" },
                new ClientLocation { ClientLocationId = 3, ClientLocationName = "New Jersey" },
                new ClientLocation { ClientLocationId = 4, ClientLocationName = "New York" },
                new ClientLocation { ClientLocationId = 5, ClientLocationName = "London" },
                new ClientLocation { ClientLocationId = 6, ClientLocationName = "Tokyo" }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectID = 1, ProjectName = "Angular", DateOfStart = Convert.ToDateTime("01/01/2002"), TeamSize = 24, Status = "In Force", Active=true, ClientLocationId = 1 },
                new Project { ProjectID = 2, ProjectName = "Java", DateOfStart = Convert.ToDateTime("02/02/2003"), TeamSize = 26, Active = true, Status = "In Force", ClientLocationId = 2 },
                new Project { ProjectID = 3, ProjectName = ".Net", DateOfStart = Convert.ToDateTime("01/05/2004"), TeamSize = 28 , Active = true, Status = "In Force", ClientLocationId = 3 },
                new Project { ProjectID = 4, ProjectName = "SQL", DateOfStart = Convert.ToDateTime("04/05/2005"), TeamSize = 40 , Active = true, Status = "Support", ClientLocationId = 4 },
                new Project { ProjectID = 5, ProjectName = "Oracle", DateOfStart = Convert.ToDateTime("01/01/2007"), TeamSize = 44 , Active = true, Status = "Support", ClientLocationId = 5 }

                );
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN"},
                new ApplicationRole() { Id = Guid.NewGuid().ToString(), Name = "Employee", NormalizedName = "EMPLOYEE"}
                );
               
        }


    }
}

