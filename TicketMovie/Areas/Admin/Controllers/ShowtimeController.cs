using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketMovie.Models;
using TicketMovie.Repositories;
namespace TicketMovie.Areas.Admin.Controllers
{   
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    [Route("admin/[controller]/[action]")]
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
        //[HttpPost]
        public async Task<IActionResult> Create()
        {
            var showtime = await _showtimeRepository.GetAllAsync();
            ViewBag.Showtime = new SelectList(showtime,"Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                // Thêm lịch chiếu phim vào cơ sở dữ liệu
                await _showtimeRepository.AddAsync(showtime);
                // Chuyển hướng đến action Index để hiển thị danh sách cập nhật
                return RedirectToAction("Index");
            }
            return View(showtime);
        }


        public async Task<IActionResult> Display(int id)
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
