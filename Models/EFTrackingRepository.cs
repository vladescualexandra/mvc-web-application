using mvc_web_application.Data;

namespace mvc_web_application.Models
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
                return this.context.Stories;
            }
        }

        public IQueryable<Ticket> Tickets
        {
            get
            {
                return this.context.Tickets;
            }
        }
    }
}
