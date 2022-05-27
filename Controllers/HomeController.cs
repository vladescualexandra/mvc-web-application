using Microsoft.AspNetCore.Mvc;

namespace mvc_web_application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
