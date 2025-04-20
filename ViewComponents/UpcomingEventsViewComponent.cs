using Microsoft.AspNetCore.Mvc;
using T_Camps.Data;
using T_Camps.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace T_Camps.ViewComponents
{
    public class UpcomingEventsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public UpcomingEventsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var events = await _context.Events.Select(e => new EventViewModel
            {
                Date = e.StartDate.ToString("dd MMMM yyyy"),
                Title = e.Name,
                Url = Url.Action("Details", "Events", new { id = e.Id })
            }).ToListAsync();

            return View(events);
        }
    }
}
