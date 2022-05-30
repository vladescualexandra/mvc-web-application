using Microsoft.EntityFrameworkCore;
using mvc_web_application.Data;
using mvc_web_application.Models;

namespace mvc_web_application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddScoped<ITrackingRepository, EFTrackingRepository>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute("pagination",
                "Stories/Page{storiesPage}",
                new { Controller = "Home", action = "Index" });

            app.MapControllerRoute("ticketsPerStory",
                      "Tickets/StoryID={storyId}",
                new { Controller = "Tickets", action = "Index" }
                );

            app.MapDefaultControllerRoute();

            SeedData.EnsurePopulated(app);

            app.Run();
        }
    }
}