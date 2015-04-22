using MovieMadness.Data;
using MovieMadness.Model;
using MovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Sid's work on Movie CRUD/Routing for the program
namespace MovieMadness.Controllers
{
    
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            List<Movie> model;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                model = db.Movies.Include("Reviews").ToList();
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            Movie model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Movies.Include("Reviews").Include("MovieActors").FirstOrDefault(x => x.MovieId == id);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddMovie()
        {
            ViewBag.Message = "Add New Movie:";
            Movie model = new Movie();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddMovie(Movie model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Movie NewMovie = new Movie()
                {
                    MovieId = model.MovieId,
                    Title = model.Title,
                    Year = model.Year,
                    Genre = model.Genre,
                    Rating = model.Rating
                };
                db.Movies.Add(NewMovie);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult EditMovie(int id)
        {
            ViewBag.Message = "Edit Movie:";
            Movie movie;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                movie = db.Movies.FirstOrDefault(x => x.MovieId == id);
            }
            return View("AddMovie", movie);
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult EditMovie(Movie model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Movie movie = db.Movies.FirstOrDefault(x => x.MovieId == model.MovieId);
                movie.Title = model.Title;
                movie.Year = model.Year;
                movie.Genre = model.Genre;
                movie.Rating = model.Rating;
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = model.MovieId });
        }
        [Authorize]
        public ActionResult DeleteMovie(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Movie model = db.Movies.FirstOrDefault(x => x.MovieId == id);
                db.Movies.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }
}