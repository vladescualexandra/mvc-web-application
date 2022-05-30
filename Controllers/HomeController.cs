using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Data;
using mvc_web_application.ViewModels;

namespace mvc_web_application.Controllers
{
	[AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private ITrackingRepository repository;
        public HomeController(ITrackingRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View();
        }

    }
}

