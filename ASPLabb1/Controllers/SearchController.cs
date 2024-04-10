using ASPLabb1.Data;
using ASPLabb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ASPLabb1.Controllers;
public class SearchController : Controller
{
	private readonly ApplicationDbContext _context;
	public SearchController(ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult Index()
	{
		return View();
	}

	// Search
	[HttpGet]
	public IActionResult Search()
	{
		ViewData["PersonalId"] = new SelectList(_context.Personals, "Id", "Name");
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Search(int? id)
	{
		if (id != null)
		{
			Personal personal = await _context.Personals.FindAsync(id);
			if (personal != null)
			{
				TimeOffApplication timeOffApplication = _context.TimeOffApplications.FirstOrDefault(model =>
					model.PersonalId == personal.Id && model.StartDate >= DateTime.Now);

				SearchPersonalViewModel searchPersonalViewModel = new()
				{
					Personal = personal,
					TimeOffApplication = timeOffApplication,
					ActiveApplication = timeOffApplication != null
				};
				return View("SearchResult", searchPersonalViewModel);
			}
		}
		return RedirectToAction("Search");
	}

	public IActionResult SearchResult(SearchPersonalViewModel searchPersonalViewModel)
	{
		return View(searchPersonalViewModel);
	}

	[HttpGet]
	public IActionResult FilterSearch()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> FilterSearch(int month)
	{
		List<TimeOffApplication> timeOffApplications =
			_context.TimeOffApplications.Where(a => a.ApplicationDate.Month == month)
				.Include(a => a.Personal)
				.ToList();

		FilterSearchModel filteredApplications = new FilterSearchModel
		{
			TimeOffApplications = timeOffApplications,
			FilteredMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)
		};

		return View("FilterResults", filteredApplications);
	}

	public IActionResult FilterResults(FilterSearchModel filteredApplications)
	{
		return View(filteredApplications);
	}
}