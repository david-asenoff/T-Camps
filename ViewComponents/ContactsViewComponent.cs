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
                Facebook = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "Facebook")?.Url,
                Instagram = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "Instagram")?.Url,
                X = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "X")?.Url,
                LinkedIn = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "LinkedIn")?.Url,
                YouTube = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "YouTube")?.Url,
                TikTok = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "TikTok")?.Url,
                Threads = company.SocialMediaLinks
        .FirstOrDefault(s => s.Platform == "Threads")?.Url,
            };


            return View(contactViewModel);
        }
    }
}
