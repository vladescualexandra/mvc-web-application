using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc_web_application.Areas.Identity.Data;
using mvc_web_application.Data;

namespace mvc_web_application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            {
                opts.UseSqlServer(
                builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddIdentity<CustomUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })

                            .AddRoleManager<RoleManager<IdentityRole>>()
                            .AddDefaultUI()
                            // TODO
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ITrackingRepository, EFTrackingRepository>();

            var app = builder.Build();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllerRoute("pagination",
                            "Stories/Page{storiesPage}",
                            new { Controller = "Home", action = "Index" });

            app.MapControllerRoute("ticketsPerStory",
                      "Tickets/StoryID={storyId}",
                new { Controller = "Tickets", action = "Index" }
                );

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.UseHsts();

            app.UseHttpsRedirection();

            SeedData.EnsurePopulated(app);
            Task.Run(async () =>
            {
                await SeedDataIdentity.EnsurePopulatedAsync(app);
            }).Wait();

            app.Run();

        }
    }
}
