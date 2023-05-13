using Microsoft.AspNetCore.Mvc;
using Tentomushi.Data;
using Tentomushi.Models;

namespace Tentomushi.Controllers
{
    public class CategoryController : Controller
    {

        public readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _context.Category;
            return View(objList);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _context.Category.Add(obj);
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
            var obj = _context.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _context.Category.Update(obj);
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
            var obj = _context.Category.Find(id);
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
            var obj = _context.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Category.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}
