using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRenderApp.Models;
using MovieRenderApp.DomainModels;


namespace MovieRenderApp.Controllers
{
    

    public class NewRenterController : Controller
    {
        Dblogics dbaccess;
        // GET: NewRenter

        public NewRenterController()
        {
            dbaccess = new Dblogics();
        }
        public ActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Index(NewRenter NewMovieRenter)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        public JsonResult GetCustomerByName(string term)
        {

            var dt = dbaccess.GetCustomer();

            var result = dbaccess.CustomerFilter(dt).Where(x => x.Name.StartsWith(term)).Select(x => x.Name).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetMovieByName(string term)
        {
            var data = dbaccess.GetMovies();

            var result = dbaccess.MovieFilter(data).Where(x => x.Name.StartsWith(term)).Select(x => x.Name).ToList();

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}