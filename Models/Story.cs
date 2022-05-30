namespace mvc_web_application.Models
{
    public class Story
    {
        public int StoryID { get; set; }

        public string? Title { get; set; }
        public List<Ticket>? Tickets { get; set; }

    }
}
