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
        public async Task<IActionResult> Delete(int storyId)
        {
            Story deletedStory = await repository.DeleteStoryAsync(storyId);
            if (deletedStory != null)
            {
                TempData["message"] = $"{deletedStory.Title} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
