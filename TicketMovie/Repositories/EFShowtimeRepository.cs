using TicketMovie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace TicketMovie.Repositories
{
    public class EFShowtimeRepository : IShowtimeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFShowtimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Showtime>> GetAllAsync()
        {
            return await _context.Showtimes.ToListAsync();
        }

        public async Task<Showtime> GetByIdAsync(int id)
        {
            return await _context.Showtimes.FindAsync(id);
        }

        public async Task AddAsync(Showtime showtime)
        {
            _context.Showtimes.Add(showtime);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Showtime showtime)
        {
            _context.Entry(showtime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var showtime = await _context.Showtimes.FindAsync(id);
            if (showtime != null)
            {
                _context.Showtimes.Remove(showtime);
                await _context.SaveChangesAsync();
            }
        }
    }
}
