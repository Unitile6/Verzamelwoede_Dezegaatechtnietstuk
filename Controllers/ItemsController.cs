using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Verzamelwoede_Dezegaatechtnietstuk.Data;
using Verzamelwoede_NonBroken.Models;

namespace Verzamelwoede_Dezegaatechtnietstuk.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index([FromQuery] bool? favourite = null)
        {
            var items = _context.Item
                .Where(x => x.Favourite == true || favourite == null)
                .ToList();


            var applicationDbContext = _context.Item.Include(i => i.Category);
            if(items != null)
            {
                return View(items);
            }
            else
            {
                return View(await applicationDbContext.ToListAsync());
            }
            
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        public IActionResult GetCategoryItems(int chosencategoryid)
        {
            var itemsincategory = _context.Item
                .Where(i => i.CategoryId == chosencategoryid)
                .ToList();  // Springt erin.
            return View(itemsincategory);
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CategoryId,Filters,Imageurl,Price,UsesPerYear,Value")] Item item)
        {
            var _picturedebug = item.Imageurl;
            var _filtersdebug = item.Filters;
            // Picture mag niet null zijn; betreft de IFormFile picture. Dus deze moet overbrugd worden.
            //IFormFile picture
            if (ModelState.IsValid) 
            {
                //De code van de pictures in ontvangen van een klasgenoot. Ik heb er aan moeten tweaken om het geheel werkend te krijgen, gezien de Create view
                //Telkens stuk ging en ook filter en categorie - koppelingen verdwenen na de initiële submit.Zowel foto als object worden niet aangemaakt.
                //if (image != null && image.Length > 0)
                //{
                //    // Genereer een unieke bestandsnaam om conflicten te voorkomen
                //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                //    // Bepaal het pad waar het bestand moet worden opgeslagen binnen de wwwroot-map
                //    string imagesFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                //    // Controleer of de map bestaat, zo niet, maak deze aan
                //    if (!Directory.Exists(imagesFolder))
                //    {
                //        Directory.CreateDirectory(imagesFolder);
                //    }

                //    // Bepaal het volledige pad van het bestand
                //    string filePath = Path.Combine(imagesFolder, uniqueFileName);
                //    // Kopieer het bestand naar de opgegeven locatie
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await image.CopyToAsync(stream);
                //    }
                //    // Wijs de bestandsnaam toe aan het 'Picture'-veld van het item
                //    item.Imageurl = uniqueFileName;
                //}
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CategoryId,Imageurl,Price,UsesPerYear,Value,Favourite")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Item'  is null.");
            }
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool ItemExists(int id)
        {
          return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
