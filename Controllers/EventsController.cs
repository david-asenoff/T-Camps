using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Camps.Data;

namespace T_Camps.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataSeeder _dataSeeder;

        public EventsController(ApplicationDbContext context, DataSeeder dataSeeder)
        {
            _context = context;
            _dataSeeder = dataSeeder;
        }

        public async Task<IActionResult> Index()
        {
            //Seed initial data if necessary
            await SeedDataAsync();

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

        public async Task<IActionResult> SeedDataAsync()
        {
            await _dataSeeder.SeedCompaniesAsync();
            await _dataSeeder.SeedMissionsAsync();
            await _dataSeeder.SeedServicesAsync();
            await _dataSeeder.SeedMembersAsync();
            await _dataSeeder.SeedTermsAndConditionsAsync();
            await _dataSeeder.SeedEventsAsync();
            await _dataSeeder.SeedClientsAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
