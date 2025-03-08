using Microsoft.AspNetCore.Mvc;
using T_Camps.Data;
using T_Camps.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace T_Camps.ViewComponents
{
    public class ContactsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ContactsViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var company = await _context.Companies.FirstOrDefaultAsync();

            if (company == null)
            {
                return Content("No company information available.");
            }

            var contactViewModel = new ContactViewModel
            {
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                Instagram = company.Instagram,
                Facebook = company.Facebook,
                X = company.X,
                LinkedIn = company.LinkedIn,
                YouTube = company.YouTube
            };

            return View(contactViewModel);
        }
    }
}
