using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc_web_application.Areas.Identity.Data;
using mvc_web_application.Models;

namespace mvc_web_application.Data
{
	public class ApplicationDbContext : IdentityDbContext<CustomUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Story> Stories { get; set; }
		public DbSet<Ticket> Tickets { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

	}
}
