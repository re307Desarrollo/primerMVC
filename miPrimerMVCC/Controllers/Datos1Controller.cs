using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using miPrimerMVCC.Data;
using miPrimerMVCC.Models;

namespace miPrimerMVCC.Controllers
{
    public class Datos1Controller : Controller
    {
        private PersonalEntities4 db = new PersonalEntities4();

        // GET: Datos1
        public ActionResult Index()
        {
            return View(db.personas.ToList());
        }

        // GET: Datos1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //Datos datos = db.Datos.Find(id);
            //if (datos == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Datos1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Datos1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,IsActive,IsRowCreatedat,IsRowUdDated")] Datos datos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Datos.Add(datos);
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(datos);
        //}

        // GET: Datos1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Datos datos = db.Datos.Find(id);
            //if (datos == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Datos1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Nombre,ApellidoPaterno,ApellidoMaterno,IsActive,IsRowCreatedat,IsRowUdDated")] Datos datos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(datos).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(datos);
        //}

        // GET: Datos1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Datos datos = db.Datos.Find(id);
            //if (datos == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Datos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Datos datos = db.Datos.Find(id);
            //db.Datos.Remove(datos);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
