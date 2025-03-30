using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Camps.Data;
using T_Camps.Models;
using System.Linq;
using System.Threading.Tasks;

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
                .Where(e => e.StartDate > DateTime.Now)
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
