using Microsoft.AspNetCore.Mvc;

namespace mvc_web_application.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
