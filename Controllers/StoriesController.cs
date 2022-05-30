using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Data;
using mvc_web_application.Models;

namespace mvc_web_application.Controllers
{
    [Authorize]
    public class StoriesController : Controller
    {
        private ITrackingRepository repository;

        private static int currentStoryId;

        public StoriesController(ITrackingRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Stories);
        }

        public IActionResult Create()
        {
            return View("Edit", new Story());
        }

        public IActionResult Edit(int storyId)
        {
            var story = repository.Stories.FirstOrDefault(s => s.StoryID == storyId);
            return View(story);
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> Edit(Story story)
        {
            if (ModelState.IsValid)
            {
                await repository.SaveStoryAsync(story);
                TempData["message"] = $"{story.Title} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(story);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int storyId)
        {
            Story deletedStory = await repository.DeleteStoryAsync(storyId);
            if (deletedStory != null)
            {
                TempData["message"] = $"{deletedStory.Title} was deleted";
            }
            return RedirectToAction("Index");
        }


        public IActionResult ViewTickets(int storyId)
        {
            currentStoryId = storyId;
            var tickets = repository.Tickets.Where(t => t.StoryID == storyId);
            return View(tickets);
        }

        public IActionResult CreateTicket()
        {
            return View("EditTicket", new Ticket());
        }

        public IActionResult EditTicket(int ticketId)
        {
            var ticket = repository.Tickets.FirstOrDefault(t => t.TicketID == ticketId);
            return View(ticket);
        }

        [HttpPost]
        [Authorize(Roles = "manager")]
        public async Task<IActionResult> EditTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                if (ticket.StoryID == 0)
                {
                    ticket.StoryID = currentStoryId;
                }

                await repository.SaveTicketAsync(ticket);
                TempData["message"] = $"{ticket.Summary} has been saved";
                return RedirectToAction("ViewTickets", ticket.StoryID);
            }
            else
            {
                return View(ticket);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTicket(int ticketId)
        {
            Ticket deletedTicket = await repository.DeleteTicketAsync(ticketId);
            if (deletedTicket != null)
            {
                TempData["message"] = $"{deletedTicket.Summary} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
