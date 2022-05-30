using mvc_web_application.Models;

namespace mvc_web_application.Data
{
    public class EFTrackingRepository : ITrackingRepository
    {
        private ApplicationDbContext context;

        public EFTrackingRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Story> Stories
        {
            get
            {
                return context.Stories;
            }
        }

        public IQueryable<Ticket> Tickets
        {
            get
            {
                return context.Tickets;
            }
        }

        public async Task SaveStoryAsync(Story story)
        {
            if (story.StoryID == 0)
            {
                context.Stories.Add(story);
            }
            else
            {
                Story? dbEntry = context.Stories
                    .FirstOrDefault(s => s.StoryID == story.StoryID);

                if (dbEntry != null)
                {
                    dbEntry.Title = story.Title;
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task SaveTicketAsync(Ticket ticket)
        {
            if (ticket.TicketID == 0)
            {
                context.Tickets.Add(ticket);
            }
            else
            {
                Ticket? dbEntry = context.Tickets
                    .FirstOrDefault(t => t.TicketID == ticket.TicketID);
                if (dbEntry != null)
                {
                    dbEntry.TicketID = ticket.TicketID;
                    dbEntry.StoryID = ticket.StoryID;
                    dbEntry.Summary = ticket.Summary;
                    dbEntry.Description = ticket.Description;
                    dbEntry.Asignee = ticket.Asignee;
                    dbEntry.Reporter = ticket.Reporter;
                    dbEntry.IsCompleted = ticket.IsCompleted;
                }
            }
            await context.SaveChangesAsync();
        }

        public async Task<Story> DeleteStoryAsync(int storyID)
        {
            Story? dbEntry = context.Stories
                    .FirstOrDefault(s => s.StoryID == storyID);

            if (dbEntry != null)
            {
                context.Stories.Remove(dbEntry);
                await context.SaveChangesAsync();
            }

			return dbEntry;
        }

		public async Task<Ticket> DeleteTicketAsync(int ticketID)
		{
            Ticket? dbEntry = context.Tickets
                    .FirstOrDefault(s => s.TicketID == ticketID);

            if (dbEntry != null)
            {
                context.Tickets.Remove(dbEntry);
                await context.SaveChangesAsync();
            }

            return dbEntry;
        }
	}
}
