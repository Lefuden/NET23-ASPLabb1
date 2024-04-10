using ASPLabb1.Data;
using ASPLabb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Controllers
{
	public class PersonalsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PersonalsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Personals
		public async Task<IActionResult> Index()
		{
			return View(await _context.Personals.ToListAsync());
		}

		// GET: Personals/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var personal = await _context.Personals
				.FirstOrDefaultAsync(m => m.Id == id);
			if (personal == null)
			{
				return NotFound();
			}

			return View(personal);
		}

		// GET: Personals/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Personals/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name")] Personal personal)
		{
			if (ModelState.IsValid)
			{
				_context.Add(personal);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(personal);
		}

		// GET: Personals/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var personal = await _context.Personals.FindAsync(id);
			if (personal == null)
			{
				return NotFound();
			}
			return View(personal);
		}

		// POST: Personals/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Personal personal)
		{
			if (id != personal.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(personal);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PersonalExists(personal.Id))
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
			return View(personal);
		}

		// GET: Personals/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var personal = await _context.Personals
				.FirstOrDefaultAsync(m => m.Id == id);
			if (personal == null)
			{
				return NotFound();
			}

			return View(personal);
		}

		// POST: Personals/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var personal = await _context.Personals.FindAsync(id);
			if (personal != null)
			{
				_context.Personals.Remove(personal);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PersonalExists(int id)
		{
			return _context.Personals.Any(e => e.Id == id);
		}
	}
}
