using Microsoft.AspNetCore.Mvc;

namespace mvc_web_application.Controllers
{
	[AutoValidateAntiforgeryToken]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
