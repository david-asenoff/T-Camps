using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Camps.ViewModels;
using T_Camps.Data;

public class ClientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Clients.ToListAsync());
    }
}
