using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Verzamelwoede_Dezegaatechtnietstuk.Data;
using Verzamelwoede_NonBroken.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Controllers
{
    public class FiltersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FiltersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filters
        public async Task<IActionResult> Index()
        {
              return _context.Filter != null ? 
                          View(await _context.Filter.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Filter'  is null.");
        }

        // GET: Filters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filter == null)
            {
                return NotFound();
            }

            var filter = await _context.Filter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filter == null)
            {
                return NotFound();
            }

            return View(filter);
        }

        // GET: Filters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Filter filter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filter);
        }

        // GET: Filters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filter == null)
            {
                return NotFound();
            }

            var filter = await _context.Filter.FindAsync(id);
            if (filter == null)
            {
                return NotFound();
            }
            return View(filter);
        }

        // POST: Filters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Filter filter)
        {
            if (id != filter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilterExists(filter.Id))
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
            return View(filter);
        }

        // GET: Filters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filter == null)
            {
                return NotFound();
            }

            var filter = await _context.Filter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filter == null)
            {
                return NotFound();
            }

            return View(filter);
        }

        // POST: Filters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Filter'  is null.");
            }
            var filter = await _context.Filter.FindAsync(id);
            if (filter != null)
            {
                _context.Filter.Remove(filter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilterExists(int id)
        {
          return (_context.Filter?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
