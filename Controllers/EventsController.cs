using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Camps.Data;

namespace T_Camps.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var upcomingEvents = await _context.Events
                .ToListAsync();

            return View(upcomingEvents);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventDetail = await _context.Events
                .Include(e => e.Company)
                .Include(e => e.Schedules)
                .Include(e => e.Speakers) // Optional, if you're also showing speakers
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventDetail == null)
            {
                return NotFound();
            }

            return View(eventDetail);
        }
    }
}
