namespace TicketMovie.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }
        public DateTime? ShowTime { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> products { get; set; }
    }
}
