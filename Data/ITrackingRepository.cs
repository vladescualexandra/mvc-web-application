using mvc_web_application.Models;

namespace mvc_web_application.Data
{
    public interface ITrackingRepository
    {
        IQueryable<Story> Stories { get; }
        IQueryable<Ticket> Tickets { get; }

        Task SaveStoryAsync(Story story);
        Task SaveTicketAsync(Ticket ticket);

        Task<Story> DeleteStoryAsync(int storyID);
        Task<Ticket> DeleteTicketAsync(int ticketID);
    }
}
