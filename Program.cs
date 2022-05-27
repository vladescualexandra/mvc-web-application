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
            builder.Services.AddDbContext<ApplicationDbContext>(opts => {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddScoped<ITrackingRepository, EFTrackingRepository>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapDefaultControllerRoute();

            SeedData.EnsurePopulated(app);

            app.Run();
        }
    }
}