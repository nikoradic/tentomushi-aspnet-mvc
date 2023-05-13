using Microsoft.AspNetCore.Mvc;
using Tentomushi.Data;
using Tentomushi.Models;

namespace Tentomushi.Controllers
{


    public class ApplicationTypeController : Controller
    {

        public readonly ApplicationDbContext _context;

        public ApplicationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _context.ApplicationType;
            return View(objList);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {

            if (ModelState.IsValid)
            {
                _context.ApplicationType.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {

            if (ModelState.IsValid)
            {
                _context.ApplicationType.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            var obj = _context.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.ApplicationType.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}
