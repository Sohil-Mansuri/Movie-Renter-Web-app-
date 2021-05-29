using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRenderApp.Models;
using MovieRenderApp.DomainModels;

namespace MovieRenderApp.Controllers
{
    public class MovieController : Controller
    {
        Dblogics AccessDb;
        List<string> list = new List<string>
        {
            "Romantic","Action","Comedy","Dramatic","Old","Action,Comedy"
        };
        public MovieController()
        {
            AccessDb = new Dblogics(); 
        }
        public ActionResult Index()
        {
           

            return View(AccessDb.GetMovies());

        }
        public ActionResult AddMovie()
        {
            ViewBag.List = list;
            var Movi = new Movie
            {
                Stocks = 0
            };
            return View(Movi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(Movie movi)
        {
            ViewBag.List = list;
            if (ModelState.IsValid)
            {
                AccessDb.AddNewMovie(movi);
                return RedirectToAction("Index");
            }


            return View();
        }
       [HttpPost]
        public ActionResult DeleteMovie(int id)
        {
            AccessDb.DeleteMovie(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(AccessDb.GetMOvieDetails(id));
        }
    }
}