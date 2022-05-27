namespace mvc_web_application.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int StoryID { get; set; }
        
        public string Summary { get; set; }
        public string Description { get; set; }

        public string Asignee { get; set; }
        public string Reporter { get; set; }

        public bool IsCompleted { get; set; } 
    }
}
