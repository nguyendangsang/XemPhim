using Microsoft.EntityFrameworkCore;
using TicketMovie.Models;

namespace TicketMovie.Repositories
{
    public class EFBookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public void BookSeats(List<int> seatIds, int showtimeId)
        {
            var showtime = _context.Showtimes.Include(s => s.Id).FirstOrDefault(s => s.Id == showtimeId);
            if (showtime == null)
            {
                throw new InvalidOperationException("Invalid showtime ID");
            }

            var seatsToBook = _context.Seats.Where(seat => seatIds.Contains(seat.Id)).ToList();
            if (seatsToBook.Count != seatIds.Count)
            {
                throw new InvalidOperationException("One or more seats are invalid");
            }

            foreach (var seat in seatsToBook)
            {
                if (seat.IsBooked)
                {
                    throw new InvalidOperationException($"Seat {seat.Name} is already booked");
                }
                seat.IsBooked = true;
            }

            _context.SaveChanges();
        }
    }

    

}
