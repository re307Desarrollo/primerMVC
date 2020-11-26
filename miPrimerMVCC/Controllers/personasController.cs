using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using miPrimerMVCC.Models;

namespace miPrimerMVCC.Controllers
{
    public class personasController : Controller
    {
        private PersonalEntities db = new PersonalEntities();

        // GET: personas
        public ActionResult Index()
        {
            return View(db.personas.ToList());
        }

        // GET: personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personas personas = db.personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // GET: personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombres,apellidop,apellidom,edad,sexo")] personas personas)
        {
            if (ModelState.IsValid)
            {
                db.personas.Add(personas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personas);
        }

        // GET: personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personas personas = db.personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // POST: personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombres,apellidop,apellidom,edad,sexo")] personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personas);
        }

        // GET: personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personas personas = db.personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personas personas = db.personas.Find(id);
            db.personas.Remove(personas);
            db.SaveChanges();
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
