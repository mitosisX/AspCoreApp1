using AspCategoryApp.Data;
using AspCategoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCategoryApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _db.Categories;
            return View(categoriesList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }

            var categoryFomDb = _db.Categories.FirstOrDefault(u=>u.Id == id);

            if (categoryFomDb == null) { return NotFound(); }

            return View(categoryFomDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if(categoryFromDb == null) { return NotFound(); }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var cat = _db.Categories.Find(id);

            if(cat == null) { return NotFound(); }

            _db.Categories.Remove(cat);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
