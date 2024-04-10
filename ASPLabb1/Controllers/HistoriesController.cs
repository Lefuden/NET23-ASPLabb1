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
}