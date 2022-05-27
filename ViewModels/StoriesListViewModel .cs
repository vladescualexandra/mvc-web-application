using mvc_web_application.Models;

namespace mvc_web_application.ViewModels
{
    public class StoriesListViewModel
    {
        public IEnumerable<Story> Stories { get; set; } = Enumerable.Empty<Story>();
        public PagingInfo PagingInfo { get; set; } = new();
    }
}
