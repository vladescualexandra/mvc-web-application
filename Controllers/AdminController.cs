using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Data;
using mvc_web_application.Models;

namespace mvc_web_application.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private ITrackingRepository repository;
		public AdminController(ITrackingRepository repo)
		{
			repository = repo;
		}
		public IActionResult Index()
		{
			return View(repository.Stories);
		}

		public IActionResult EditStory(int storyId)
		{
			var story = repository.Stories.FirstOrDefault(s => s.StoryID == storyId);
			return View(story);
		}

		public IActionResult CreateStory()
		{
			return View("Edit", new Story());
		}

		[HttpPost]
		public async Task<IActionResult> DeleteStory(int storyId)
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
