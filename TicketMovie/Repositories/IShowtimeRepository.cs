using TicketMovie.Models;

namespace TicketMovie.Repositories
{
    public interface IShowtimeRepository
    {
        Task<IEnumerable<Showtime>> GetAllAsync();
        Task<Showtime> GetByIdAsync(int id);
        Task AddAsync(Showtime showtime);
        Task UpdateAsync(Showtime showtime);
        Task DeleteAsync(int id);
    }
}
