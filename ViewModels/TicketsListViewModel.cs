using mvc_web_application.Models;

namespace mvc_web_application.ViewModels
{
    public class TicketsListViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; } = Enumerable.Empty<Ticket>();
        public PagingInfoViewModel PagingInfo { get; set; } = new();
    }
}
