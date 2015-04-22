using MovieMadness.Data;
using MovieMadness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieMadness.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        // by Sherry
        public ActionResult Index()
        {
            List<Movie> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Movies.Include("Reviews").ToList();
            }
            return View(model);
        }
        public ActionResult AddReview(int id)//id is MovieId
        {
            ViewBag.Message = "Add A Review";
            Review model = new Review();
            model.MovieId = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddReview(Review model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model.DatePosted = DateTime.Now;
                db.Reviews.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditReview(int id)//id is ReviewId
        {
            ViewBag.Message = "Edit A Review";
            Review model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
            }
            return View("AddReview", model);
        }

        [HttpPost]
        public ActionResult EditReview(Review review)
        {
            Review model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Reviews.FirstOrDefault(x => x.ReviewId == review.ReviewId);
                model.Post = review.Post;
                model.DatePosted = DateTime.Now;
                model.Rating = review.Rating;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteReview(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Review model = db.Reviews.FirstOrDefault(x => x.ReviewId == id);
                db.Reviews.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}