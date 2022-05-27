using mvc_web_application.Models;

namespace mvc_web_application.Data
{
    public interface ITrackingRepository
    {
        IQueryable<Story> Stories { get; }
        IQueryable<Ticket> Tickets { get; }
    }
}
