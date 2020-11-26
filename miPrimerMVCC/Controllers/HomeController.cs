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
        PersonalEntities db = new PersonalEntities();
        public ActionResult Index()
        {

            return View();

        }
        public ActionResult Form()
        {
            return View();
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
        [HttpPost]
        public ActionResult createPerson(personas pers)
        {
            db.personas.Add(pers);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public JsonResult getPersons()
        {  
            return Json(db.personas.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult deletePerson(int id) {
            personas per = db.personas.Find(id);
            db.personas.Remove(per);
            string message = "Deleted Succsfully";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

    }
}