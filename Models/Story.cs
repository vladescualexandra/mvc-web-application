using System.ComponentModel.DataAnnotations;

namespace mvc_web_application.Models
{
    public class Story
    {
        public int StoryID { get; set; }

        [Required(ErrorMessage = "Please enter a Story Title")]
        public string? Title { get; set; }
        public List<Ticket>? Tickets { get; set; }

    }
}
