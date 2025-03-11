using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T_Camps.ViewModels;
using T_Camps.Data;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly DataSeeder _dataSeeder;
    public AdminController(ApplicationDbContext context, DataSeeder? dataSeeder)
    {
        _context = context;
        _dataSeeder = dataSeeder;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Clients.ToListAsync());
    }

    // GET: Admin/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Admin/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Phone,Email,Description")] ClientViewModel client)
    {
        if (ModelState.IsValid)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }

    // GET: Admin/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return View(client);
    }

    // POST: Admin/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,Email,Description")] ClientViewModel client)
    {
        if (id != client.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(client);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(client.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }

    // POST: Admin/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClientExists(int id)
    {
        return _context.Clients.Any(e => e.Id == id);
    }

}
