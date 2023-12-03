using Microsoft.AspNetCore.Mvc;
using TP2.Models;

namespace TP2.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategorieController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            var movies = _db.Movies.ToList();
            return View(movies);
        }

        public IActionResult Create()

        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id); 

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            Movie movieEdit = _db.Movies.FirstOrDefault(x => x.Id == movie.Id);
            movieEdit.Name = movie.Name;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Movie movie)
        {
            Movie movieDelete = _db.Movies.FirstOrDefault(x => x.Id == movie.Id);
            _db.Movies.Remove(movieDelete);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
