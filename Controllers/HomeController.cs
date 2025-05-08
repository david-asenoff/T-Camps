using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Camps.Data;
using T_Camps.Models;
using T_Camps.ViewModels;

namespace T_Camps.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly DataSeeder _dataSeeder;

    public HomeController(ILogger<HomeController> logger
        , ApplicationDbContext context, DataSeeder dataSeeder)
    {
        _logger = logger;
        _context = context;
        _dataSeeder = dataSeeder;
    }

    public async Task<IActionResult> Index()
    {
        // Seed initial data if necessary
        //await SeedDataAsync();

        // Fetch the first company with its related Missions and Services
        var company = await _context.Companies
            .Include(c => c.Missions)
            .Include(c => c.Services)
            .Include(c => c.Members)
            .FirstOrDefaultAsync();

        // Return 404 if no company is found
        if (company == null)
        {
            return NotFound();
        }

        // Map the company data to the CompanyViewModel
        var model = new CompanyViewModel
        {
            Id = company.Id,
            Name = company.Name,
            Moto = company.Moto,
            WelcomeMessage = company.WelcomeMessage,
            About = company.About,
            JoinInformation = company.JoinInformation,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            SocialMediaLinks = company.SocialMediaLinks,
            Missions = company.Missions,
            Services = company.Services,
            Members = company.Members,
        };

        return View(model);
    }



    public async Task<IActionResult> Privacy()
    {
        var model =  await _context.TermsAndConditions
            .Include(tc => tc.Company)
            .OrderBy(tc => tc.Id)
            .Select(tc => new TermsAndConditionsViewModel
            {
                CompanyName = tc.Company.Name,
                Content = tc.Content,
                SectionTitle = tc.SectionTitle,
            })
            .ToListAsync();
        ViewData["Title"] = "Privacy";
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Contact()
    {
        return View();
    }

    // POST: /Home/Contact
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact(ContactFormSubmission model)
    {
        if (ModelState.IsValid)
        {
            model.SubmittedAt = DateTime.UtcNow;

            _context.ContactFormSubmissions.Add(model);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Благодарим ви! Вашето съобщение беше изпратено успешно.";
            return RedirectToAction("Contact"); // This is key for TempData to persist
        }

        // If there are validation errors, just return the same view with the model
        return View(model);
    }


    public async Task<IActionResult> About()
    {
        var model = await _context.Members
            .Include(m => m.Company)
            .OrderBy(m => m.Id)
            .Select(m => new MembersViewModel
            {
                Name = m.Name,
                Email = m.Email,
                CompanyName = m.Company.Name,
                CompanyEmail = m.Company.Email,
                Role = m.Role,
                About = m.About,
                Picture = m.Picture
            })
            .ToListAsync();

        return View(model);
    }

    public IActionResult Events()
    {
        return View();
    }

    public IActionResult JoinIn()
    {
        return View();
    }

    public IActionResult Gallery()
    {
        return View();
    }

    public async Task<IActionResult> InfoNpo()
    {
        // Fetch the first company with its related Missions and Services
        var company = await _context.Companies
            .Include(c => c.Missions)
            .Include(c => c.Services)
            .Include(c => c.Members)
            .FirstOrDefaultAsync();

        // Return 404 if no company is found
        if (company == null)
        {
            return NotFound();
        }

        // Map the company data to the CompanyViewModel
        var model = new CompanyViewModel
        {
            Id = company.Id,
            Name = company.Name,
            Moto = company.Moto,
            WelcomeMessage = company.WelcomeMessage,
            About = company.About,
            JoinInformation = company.JoinInformation,
            PhoneNumber = company.PhoneNumber,
            Email = company.Email,
            SocialMediaLinks = company.SocialMediaLinks,
            Missions = company.Missions,
            Services = company.Services,
            Members = company.Members,
        };

        return View(model);
    }

    public async Task<IActionResult> Terms()
    {
        var company = await _context.Companies
            .Include(c => c.Missions)
            .Include(c => c.Services)
            .FirstOrDefaultAsync();

        return View(company);
    }

    public async Task<IActionResult> BecomeSponsor()
    {
        var company = await _context.Companies
            .Include(c => c.Missions)
            .Include(c => c.Services)
            .FirstOrDefaultAsync();

        if (company == null)
        {
            return NotFound();
        }

        return View(company);
    }

    public async Task<IActionResult> BecomeMember()
    {
        return View();
    }

    public async Task<IActionResult> JoinEvent()
    {
        return View();
    }

    public IActionResult ChangeLanguage(string lang)
    {
        if (!string.IsNullOrEmpty(lang))
        {
            var culture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Response.Cookies.Append("Language", lang);
            _logger.LogInformation($"Language changed to {lang}");
        }
        else
        {
            var culture = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Response.Cookies.Append("Language", "en");
            _logger.LogInformation("Language changed to default (en)");
        }

        var referer = Request.GetTypedHeaders().Referer?.ToString();
        if (string.IsNullOrEmpty(referer))
        {
            referer = Url.Action("Index", "Home");
        }

        return Redirect(referer);
        //if (!string.IsNullOrEmpty(lang))
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        //}
        //else
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        //    lang = "en";
        //}
        //Response.Cookies.Append("Language", lang);
        //return Redirect(Request.GetTypedHeaders().Referer.ToString());
    }

    //public async Task<IActionResult> SeedDataAsync()
    //{
    //    await _dataSeeder.SeedCompaniesAsync();
    //    await _dataSeeder.SeedMissionsAsync();
    //    await _dataSeeder.SeedServicesAsync();
    //    await _dataSeeder.SeedMembersAsync();
    //    await _dataSeeder.SeedTermsAndConditionsAsync();
    //    await _dataSeeder.SeedEventsAsync();
    //    await _dataSeeder.SeedClientsAsync();
    //    return RedirectToAction(nameof(Index));
    //}
}
