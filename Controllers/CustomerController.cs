using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRenderApp.Models;
using MovieRenderApp.DomainModels;
using MovieRenderApp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace MovieRenderApp.Controllers

{      
    public class CustomerController : Controller
    {
        // GET: Customer
        Dblogics AccessDb;
        List<string> obj = new List<string> {"America","Other" };
        List<MembershipTypeName> MemType = new List<MembershipTypeName>()
       {
           new MembershipTypeName {Id=1,List="Pay As You Go" },
           new MembershipTypeName {Id=2,List="Monthly" },
           new MembershipTypeName {Id=3,List="Quartly" },
           new MembershipTypeName {Id=4,List="Annual" }
       };

        public CustomerController()
        {
           AccessDb = new Dblogics();

        }
        public ActionResult Index()
        { 

            return View(AccessDb.GetCustomer());

          
        }
        public ActionResult Edit(int id)
        {
            var customer = new Customer();
            customer.Name= AccessDb.GetName(id);


            return View(customer);
               
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {

            AccessDb.UpdateName(customer);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            AccessDb.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
        public ActionResult NewCustomer()
        {

            ViewBag.List1 = obj;
            ViewBag.List2 = MemType;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCustomer(Customer custom)
        {
            ViewBag.List1 = obj;
            ViewBag.List2 = MemType;
            if (ModelState.IsValid)
            {
                ViewBag.key = AccessDb.AddCustomer(custom);
                ModelState.Clear();
                return RedirectToAction("Index");

            }


            return View();
        }
               
        
        
    }
}