using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Verzamelwoede_Dezegaatechtnietstuk.Data;

namespace Verzamelwoede_Dezegaatechtnietstuk.Controllers
{
    public class TinderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TinderController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        //        // GET: TinderController
        //        public ActionResult Index()
        //        {
        //            return View();
        //        }

        //        // GET: TinderController/Details/5
        //        public ActionResult Details(int id)
        //        {
        //            return View();
        //        }

        //        // GET: TinderController/Create
        //        public ActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: TinderController/Create
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create(IFormCollection collection)
        //        {
        //            try
        //            {
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }

        //        // GET: TinderController/Edit/5
        //        public ActionResult Edit(int id)
        //        {
        //            return View();
        //        }

        //        // POST: TinderController/Edit/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit(int id, IFormCollection collection)
        //        {
        //            try
        //            {
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }

        //        // GET: TinderController/Delete/5
        //        public ActionResult Delete(int id)
        //        {
        //            return View();
        //        }

        //        // POST: TinderController/Delete/5
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Delete(int id, IFormCollection collection)
        //        {
        //            try
        //            {
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }

        public IActionResult CreateTinder(int count)
        {
            var randomItems = _context.Item
            .OrderBy(x => Guid.NewGuid()) // Order randomly
            .Take(2)
            .ToList();

            return View(randomItems);
        }
    }
}
//    }
//}
