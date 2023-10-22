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
        public async Task<IActionResult> Get()
        {
            var applicationDbContext = _context.Item.Include(i => i.Category);

            var applicationDbContextb = _context.Item.Include(v => v.Filters);
            return Ok();
        }

        // GET api/<ReadWriteController>/5
        [HttpGet("{id}")] // helpt met systeem begrijpen wat er moet gebeuren. GET request met een param van id?
        [ProducesResponseType(200, Type = typeof(Item))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
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

            return Ok();
        }

        //// POST api/<ReadWriteController>
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody][Bind("Id,Name,Description,CategoryId,Filters,Imageurl,Price,UsesPerYear,Value")] Item item, IFormFile image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(item);
        //        await _context.SaveChangesAsync();
        //        return Ok();
        //    }
        //    return NotFound();
        //}

        //// PUT api/<ReadWriteController>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [Bind("Id,Name,Description,CategoryId,Imageurl,Price,UsesPerYear,Value")] Item item)
        //{
        //    //put is like update.
        //    //if (id == null || _context.Item == null)
        //    //{
        //    //    throw new Exception($"Invalid id {id}");
        //    //}

        //    //var item = _context.Item.Find(id);
        //    //if (item == null)
        //    //{
        //    //    //throw new Exception("no item was found!");
        //    //    return NotFound();
        //    //}
        //    //else
        //    //{
        //    //    return Ok();
        //    //}
        //    if (id != item.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(item);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            //if (!ItemExists(item.Id))
        //            //{
        //            //    return NotFound();
        //            //}
        //            //else
        //            //{
        //            //    throw;
        //            //}
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return Ok();
        //}

        //// DELETE api/<ReadWriteController>/5
        //[HttpDelete("{id}")]
        //public async void Delete(int id)
        //{
        //    if (id == null || _context.Item == null)
        //    {
        //        throw new Exception($"Invalid id {id}");
        //    }

        //    var item = await _context.Item
        //        .Include(i => i.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (item == null)
        //    {
        //        throw new Exception($"Invalid id {id}");
        //    }
        //}
    }
}
