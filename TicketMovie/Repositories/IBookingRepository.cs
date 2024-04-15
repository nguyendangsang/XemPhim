using TicketMovie.Models;
namespace TicketMovie.Repositories
{
    public interface IBookingRepository
    {
        void BookSeats(List<int> seatIds, int showtimeId);
    }
}
