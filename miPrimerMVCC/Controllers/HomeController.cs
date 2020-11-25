using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miPrimerMVCC.Models;

namespace miPrimerMVCC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            PersonalEntities db = new PersonalEntities();
            return View(db);

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
    }
}