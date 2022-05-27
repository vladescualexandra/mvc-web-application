using Microsoft.AspNetCore.Mvc;
using mvc_web_application.Data;
using mvc_web_application.ViewModels;

namespace mvc_web_application.Controllers
{
    public class HomeController : Controller
    {
        private ITrackingRepository repository;
        public HomeController(ITrackingRepository repository)
        {
            this.repository = repository;
        }

        

        public int PageSize = 2;
        public ViewResult Index(int storiesPage = 1)
        {
            var viewModel = new StoriesListViewModel
            {
                Stories = repository.Stories
                    .OrderBy(p => p.StoryID)
                    .Skip((storiesPage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = storiesPage,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Stories.Count()
                    }
            };

            return View(viewModel);
        }

    }
}

