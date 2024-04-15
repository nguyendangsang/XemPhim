namespace TicketMovie.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBooked { get; set; } // Đánh dấu ghế đã được đặt vé hay chưa
        public List<Product> Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Showtime> Showtimes { get; set; }
        // Các thuộc tính khác nếu cần
    }

}
