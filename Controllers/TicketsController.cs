using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Data;
using mvc_web_application.Models;

namespace mvc_web_application.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
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
