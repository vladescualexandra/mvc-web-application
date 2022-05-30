using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Areas.Identity.Data;

namespace mvc_web_application.Data
{
    public static class SeedDataIdentity
    {
        // Admin
        private const string adminRoleName = "admin";
        private const string adminEmail = "admin@tracker.com";
        private const string adminPassword = "123Admin!";

        // Manager 
        private const string managerRoleName = "manager";
        private const string managerEmail = "manager@tracker.com";
        private const string managerPassword = "123Manager!";

        // Developer 
        private const string developerRoleName = "developer";
        private const string developerEmail = "developer@tracker.com";
        private const string developerPassword = "123Developer!";

        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices
         .CreateScope().ServiceProvider;

            using (var userManager = serviceProvider
                .GetRequiredService<UserManager<CustomUser>>())
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Admin.
                if (!await roleManager.RoleExistsAsync(adminRoleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRoleName));
                }

                CustomUser admin = await userManager.FindByEmailAsync(adminEmail);
                if (admin == null)
                {
                    admin = new CustomUser { UserName = adminEmail, Email = adminEmail, Team = "Administrative" };
                    await userManager.CreateAsync(admin, adminPassword);
					await userManager.AddToRoleAsync(admin, adminRoleName);
				}

				// Manager.
				if (!await roleManager.RoleExistsAsync(managerRoleName))
				{
					await roleManager.CreateAsync(new IdentityRole(managerRoleName));
				}
				CustomUser manager = await userManager.FindByEmailAsync(managerEmail);
				if (manager == null)
				{
					manager = new CustomUser { UserName = managerEmail, Email = managerEmail, Team = "Management" };
					await userManager.CreateAsync(manager, managerPassword);
					await userManager.AddToRoleAsync(manager, managerRoleName);

				}

				// Developer.
				if (!await roleManager.RoleExistsAsync(developerRoleName))
				{
					await roleManager.CreateAsync(new IdentityRole(developerRoleName));
				}

				CustomUser developer = await userManager.FindByEmailAsync(developerEmail);
				if (developer == null)
				{
					developer = new CustomUser { UserName = developerEmail, Email = developerEmail, Team = "Development" };
					await userManager.CreateAsync(developer, developerPassword);
					await userManager.AddToRoleAsync(developer, developerRoleName);
				}
			}
		}
    }
}
