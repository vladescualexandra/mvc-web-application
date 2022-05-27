using Microsoft.EntityFrameworkCore;
using mvc_web_application.Models;

namespace mvc_web_application.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Story> Stories { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
	}
}
