using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            db.SaveChanges();
            string message = "Deleted Succsfully";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public ActionResult getID(int id) 
        {
            personas pers = db.personas.Find(id);
            return Json(pers, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult updatePerson(int id, personas pers) 
        {
            personas prsonUpdate = db.personas.Find(id);
            if (!string.IsNullOrWhiteSpace(pers.nombres)) { prsonUpdate.nombres = pers.nombres; }
            if (!string.IsNullOrWhiteSpace(pers.apellidop)) { prsonUpdate.apellidop = pers.apellidop; }
            if (!string.IsNullOrWhiteSpace(pers.apellidom)) { prsonUpdate.apellidom = pers.apellidom; }
            if (!string.IsNullOrWhiteSpace(pers.edad.ToString())) { prsonUpdate.edad = pers.edad; }
            if (!string.IsNullOrWhiteSpace(pers.sexo)) { prsonUpdate.sexo = pers.sexo; }
            db.SaveChanges();
            string mess = "Updated";
            return Json(new { Message = mess, JsonRequestBehavior.AllowGet });
        }
    }
}