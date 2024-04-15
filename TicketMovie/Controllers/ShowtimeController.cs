using TicketMovie.Models;
using TicketMovie.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace TicketMovie.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ShowtimeController : Controller
    {
        private readonly IShowtimeRepository _showtimeRepository;
        public ShowtimeController(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var showtimes = await _showtimeRepository.GetAllAsync();
            return View(showtimes);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                await _showtimeRepository.AddAsync(showtime);
                return RedirectToAction("Index");
            }
            return View(showtime);
        }
        public async Task<IActionResult> Details(int id)
        {
            var showtime = await _showtimeRepository.GetByIdAsync(id);
            if (showtime == null)
            {
                return NotFound();
            }
            return View(showtime);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateShowtime(Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                await _showtimeRepository.UpdateAsync(showtime);
                return RedirectToAction("Index");
            }
            return View(showtime);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShowtime(int id)
        {
            await _showtimeRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}