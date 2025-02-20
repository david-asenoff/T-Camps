using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using T_Camps.Models;

namespace T_Camps.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
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

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Events()
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
    }
}
