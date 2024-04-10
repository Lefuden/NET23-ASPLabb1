using ASPLabb1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Controllers;

public class HistoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public HistoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Histories
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Historys.Include(h => h.Personal).Include(h => h.TimeOffApplication);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Histories/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var history = await _context.Historys
            .Include(h => h.Personal)
            .Include(h => h.TimeOffApplication)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (history == null)
        {
            return NotFound();
        }

        return View(history);
    }





    // GET: Histories/Create
    //public IActionResult Create()
    //{
    //    ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Id");
    //    ViewData["TimeOffApplicationId"] = new SelectList(_context.TimeOffApplications, "Id", "Id");
    //    return View();
    //}

    //// POST: Histories/Create
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,PersonalId,TimeOffApplicationId,ApplicationStatus")] History history)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(history);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Id", history.PersonalId);
    //    ViewData["TimeOffApplicationId"] = new SelectList(_context.TimeOffApplications, "Id", "Id", history.TimeOffApplicationId);
    //    return View(history);
    //}

    //// GET: Histories/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var history = await _context.Historys.FindAsync(id);
    //    if (history == null)
    //    {
    //        return NotFound();
    //    }
    //    ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Id", history.PersonalId);
    //    ViewData["TimeOffApplicationId"] = new SelectList(_context.TimeOffApplications, "Id", "Id", history.TimeOffApplicationId);
    //    return View(history);
    //}

    //// POST: Histories/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int id, [Bind("Id,PersonalId,TimeOffApplicationId,ApplicationStatus")] History history)
    //{
    //    if (id != history.Id)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(history);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!HistoryExists(history.Id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Id", history.PersonalId);
    //    ViewData["TimeOffApplicationId"] = new SelectList(_context.TimeOffApplications, "Id", "Id", history.TimeOffApplicationId);
    //    return View(history);
    //}

    //// GET: Histories/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var history = await _context.Historys
    //        .Include(h => h.Personal)
    //        .Include(h => h.TimeOffApplication)
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (history == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(history);
    //}

    //// POST: Histories/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    var history = await _context.Historys.FindAsync(id);
    //    if (history != null)
    //    {
    //        _context.Historys.Remove(history);
    //    }

    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool HistoryExists(int id)
    //{
    //    return _context.Historys.Any(e => e.Id == id);
    //}
}