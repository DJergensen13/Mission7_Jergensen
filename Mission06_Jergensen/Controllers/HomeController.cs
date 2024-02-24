using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Jergensen.Models;
using System.Diagnostics;

namespace Mission06_Jergensen.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext _context;
        public HomeController(MovieApplicationContext temp) // constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Application()
        {
            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Application", new Movies());
        }
        [HttpPost]
        public IActionResult Application(Movies response)
        {
            if(ModelState.IsValid)
            {
                _context.Movies.Add(response); // add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Movies()
        {
            var movies = _context.Movies.Include(x => x.CategoryName)
                .OrderBy(x => x.MovieId).ToList();

            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("Application", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movies updatedinfo)
        {
            _context.Update(updatedinfo);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            
            return RedirectToAction("Movies");
        }
    }
}
