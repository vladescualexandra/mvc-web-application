using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Data;
using mvc_web_application.Models;
using mvc_web_application.ViewModels;

namespace mvc_web_application.Controllers
{
    public class TicketsController : Controller
    {
        private ITrackingRepository repository;
        public TicketsController(ITrackingRepository repository)
        {
            this.repository = repository;
        }

        //public ViewResult Index(int storyId = 1)
        //{
        //    var viewModel = new TicketsListViewModel
        //    {
        //        Tickets = repository.Tickets
        //            .OrderBy(p => p.TicketID)
        //            .Where(t => t.StoryID == storyId)
        //    };

        //    return View(viewModel);
        //}

        public IActionResult CreateTicket()
        {
            return View("EditTicket", new Ticket());
        }
    }
}
