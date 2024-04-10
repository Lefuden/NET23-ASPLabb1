using ASPLabb1.Data;
using ASPLabb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Controllers;

public class TimeOffApplicationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public TimeOffApplicationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TimeOffApplications
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.TimeOffApplications.Include(t => t.Personal);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: TimeOffApplications/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var timeOffApplication = await _context.TimeOffApplications
            .Include(t => t.Personal)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (timeOffApplication == null)
        {
            return NotFound();
        }

        return View(timeOffApplication);
    }

    // GET: TimeOffApplications/Create
    public IActionResult Create()
    {
        ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Name");
        return View();
    }

    // POST: TimeOffApplications/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,TypeName,StartDate,EndDate,ApplicationDate,PersonalId")] TimeOffApplication timeOffApplication)
    {
        if (ModelState.IsValid)
        {
            _context.Add(timeOffApplication);
            await _context.SaveChangesAsync();

            History history = new()
            {
                PersonalId = timeOffApplication.PersonalId,
                TimeOffApplicationId = timeOffApplication.Id
            };

            _context.Add(history);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Name", timeOffApplication.PersonalId);
        return View(timeOffApplication);
    }

    // GET: TimeOffApplications/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var timeOffApplication = await _context.TimeOffApplications.FindAsync(id);
        if (timeOffApplication == null)
        {
            return NotFound();
        }
        ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Name", timeOffApplication.PersonalId);
        return View(timeOffApplication);
    }

    // POST: TimeOffApplications/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName,StartDate,EndDate,ApplicationDate,PersonalId")] TimeOffApplication timeOffApplication)
    {
        if (id != timeOffApplication.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(timeOffApplication);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeOffApplicationExists(timeOffApplication.Id))
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
        ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Name", timeOffApplication.PersonalId);
        return View(timeOffApplication);
    }

    // GET: TimeOffApplications/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var timeOffApplication = await _context.TimeOffApplications
            .Include(t => t.Personal)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (timeOffApplication == null)
        {
            return NotFound();
        }

        return View(timeOffApplication);
    }

    // POST: TimeOffApplications/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var timeOffApplication = await _context.TimeOffApplications.FindAsync(id);
        if (timeOffApplication != null)
        {
            _context.TimeOffApplications.Remove(timeOffApplication);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TimeOffApplicationExists(int id)
    {
        return _context.TimeOffApplications.Any(e => e.Id == id);
    }
}