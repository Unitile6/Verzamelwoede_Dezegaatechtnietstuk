using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Verzamelwoede_Dezegaatechtnietstuk.Data;
using Verzamelwoede_NonBroken.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VerzamelWoedeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadWriteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReadWriteController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<ReadWriteController>
        [HttpGet("ReadallItems", Name = "ReadAllItems")]
        public IEnumerable<Item> Get()
        {
            return _context.Item;
        }

        // GET api/<ReadWriteController>/5
        [HttpGet("{id}")] // helpt met systeem begrijpen wat er moet gebeuren. GET request met een param van id?
        [ProducesResponseType(200, Type = typeof(Item))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            {
                if (id == null || _context.Item == null)
                {
                    return BadRequest();
                }
                var categorie = await _context.Item
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (categorie == null)
                {
                    return NotFound();
                }
                return Ok(categorie);
            }
        }

        // POST api/<ReadWriteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Item item)
        {
            {
                if (ModelState.IsValid)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return Ok(item);
            }
        }

        // PUT api/<ReadWriteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Item item)
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
            return Ok(item);
        }
        private bool ItemExists(int id)
        {
            return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE api/<ReadWriteController>/5
        [HttpDelete("DeleteItem/{id}",Name ="DeleteItem")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                if (_context.Item == null)
                {
                    return Problem("Entity set 'VerzamelwoedeJane.Categories'  is null.");
                }
                var categorie = await _context.Item.FindAsync(id);
                if (categorie != null)
                {
                    _context.Item.Remove(categorie);
                }



                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
