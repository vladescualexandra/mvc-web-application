using Microsoft.EntityFrameworkCore;
using mvc_web_application.Models;

namespace mvc_web_application.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            Ticket ticket01_story01 = new Ticket
            {
                Summary = "Summary Ticket 01 / Story 01",
                Description = "Description Ticket 01 / Story 01",
                Reporter = "vladescualexandra",
                Asignee = "vladescualexandra",
                IsCompleted = true
            };

            Ticket ticket02_story01 = new Ticket
            {
                Summary = "Summary Ticket 02 / Story 01",
                Description = "Description Ticket 02 / Story 01",
                Reporter = "vladescualexandra",
                Asignee = "vladescualexandra",
                IsCompleted = false
            };

            Ticket ticket01_story02 = new Ticket
            {
                Summary = "Summary Ticket 01 / Story 02",
                Description = "Description Ticket 01 / Story 02",
                Reporter = "vladescualexandra",
                Asignee = "vladescualexandra",
                IsCompleted = true
            };

            List<Ticket> tickets_story01 = new List<Ticket>();
            tickets_story01.Add(ticket01_story01);
            tickets_story01.Add(ticket02_story01);

            List<Ticket> tickets_story02 = new List<Ticket>();
            tickets_story02.Add(ticket01_story02);

            Story story01 = new Story
            {
                Title = "Title Stoy 01",
                Tickets = tickets_story01
            };

            Story story02 = new Story
            {
                Title = "Title Stoy 02",
                Tickets = tickets_story02
            };

            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(ticket01_story01,
                                         ticket02_story01,
                                         ticket01_story02);
            }

            if (!context.Stories.Any())
            {
                context.Stories.AddRange(story01,
                                         story02);
            }
        }

    }
}
