using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPI_Service.Data
{
	public class AuthDbContext : IdentityDbContext
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "e99342e0-f8fd-4d7d-873f-91f0329d23f2";
            var writerRoleId = "87a71fb7-d9ce-4e6a-b460-7ca73c58f3c3";
            var roles = new List<IdentityRole>
            {
                new IdentityRole(){ Id = readerRoleId, ConcurrencyStamp=readerRoleId,Name="Reader",NormalizedName="Reader".ToUpper()},
                new IdentityRole(){ Id = writerRoleId, ConcurrencyStamp=writerRoleId,Name="Writer",NormalizedName="Writer".ToUpper() }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

