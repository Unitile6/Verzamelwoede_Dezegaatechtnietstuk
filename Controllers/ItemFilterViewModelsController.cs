using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Verzamelwoede_Dezegaatechtnietstuk.Data;
using Verzamelwoede_Dezegaatechtnietstuk.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Controllers
{
    public class ItemFilterViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemFilterViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemFilterViewModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemFilterViewModel.Include(i => i.Filter).Include(i => i.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemFilterViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemFilterViewModel == null)
            {
                return NotFound();
            }

            var itemFilterViewModel = await _context.ItemFilterViewModel
                .Include(i => i.Filter)
                .Include(i => i.Item)
                .ThenInclude(o => o.Description)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemFilterViewModel == null)
            {
                return NotFound();
            }

            return View(itemFilterViewModel);
        }

        // GET: ItemFilterViewModels/Create
        public IActionResult Create()
        {
            ViewData["FilterId"] = new SelectList(_context.Filter, "Id", "Id");
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id");
            return View();
        }

        // POST: ItemFilterViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilterId,ItemId")] ItemFilterViewModel itemFilterViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemFilterViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilterId"] = new SelectList(_context.Filter, "Id", "Id", itemFilterViewModel.FilterId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", itemFilterViewModel.ItemId);
            return View(itemFilterViewModel);
        }

        // GET: ItemFilterViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemFilterViewModel == null)
            {
                return NotFound();
            }

            var itemFilterViewModel = await _context.ItemFilterViewModel.FindAsync(id);
            if (itemFilterViewModel == null)
            {
                return NotFound();
            }
            ViewData["FilterId"] = new SelectList(_context.Filter, "Id", "Id", itemFilterViewModel.FilterId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", itemFilterViewModel.ItemId);
            return View(itemFilterViewModel);
        }

        // POST: ItemFilterViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilterId,ItemId")] ItemFilterViewModel itemFilterViewModel)
        {
            if (id != itemFilterViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemFilterViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemFilterViewModelExists(itemFilterViewModel.Id))
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
            ViewData["FilterId"] = new SelectList(_context.Filter, "Id", "Id", itemFilterViewModel.FilterId);
            ViewData["ItemId"] = new SelectList(_context.Item, "Id", "Id", itemFilterViewModel.ItemId);
            return View(itemFilterViewModel);
        }

        // GET: ItemFilterViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemFilterViewModel == null)
            {
                return NotFound();
            }

            var itemFilterViewModel = await _context.ItemFilterViewModel
                .Include(i => i.Filter)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemFilterViewModel == null)
            {
                return NotFound();
            }

            return View(itemFilterViewModel);
        }

        // POST: ItemFilterViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemFilterViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItemFilterViewModel'  is null.");
            }
            var itemFilterViewModel = await _context.ItemFilterViewModel.FindAsync(id);
            if (itemFilterViewModel != null)
            {
                _context.ItemFilterViewModel.Remove(itemFilterViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemFilterViewModelExists(int id)
        {
          return (_context.ItemFilterViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
