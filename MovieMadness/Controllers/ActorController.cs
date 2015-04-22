using MovieMadness.Data;
using MovieMadness.Model;
using MovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieMadness.Controllers
{
    
    public class ActorController : Controller
    {
        // GET: Actor
        public ActionResult Index()
        {
            //List<Actor> model;
            List<ActorIndexViewModel> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //model = db.Actors.Include("Movies").ToList();
                model = db.Actors.Select(a => new ActorIndexViewModel()
                {
                    ActorId = a.ActorId,
                    Name = a.Name,
                    ActorMovies = a.MovieActors.Select(m => new MovieViewModel()
                    {
                        Title = m.Movie.Title,
                        Year = m.Movie.Year
                    }).ToList()
                }).ToList();
            }
            return View(model);
        }

        public ActionResult AddActor(int id)
        {
            ViewBag.Message = "Add A New Actor";
            Actor model = new Actor();
            model.MovieId = id;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddActor(Actor model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Actors.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Home", new { id = model.MovieId });
        }
        public ActionResult EditActor(int id)
        {
            ViewBag.Message = "Edit Actor";
            Actor actor;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                actor = db.Actors.FirstOrDefault(x => x.ActorId == id);
            }
            return View("AddActor", actor);
        }
        [HttpPost]
        public ActionResult EditActor(Actor model)
        {
            ViewBag.Message = "Edit Actor";
            Actor actor;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                actor = db.Actors.FirstOrDefault(x => x.ActorId == model.ActorId);
                actor.Name = model.Name;

                db.SaveChanges();
            }
            return RedirectToAction("Details", "Home", new { id = actor.MovieId });
        }
        public ActionResult DeleteActor(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Actor model = db.Actors.FirstOrDefault(x => x.MovieId == id);
                db.Actors.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}



