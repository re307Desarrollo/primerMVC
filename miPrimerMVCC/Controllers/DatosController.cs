using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miPrimerMVCC.Models;
//using miPrimerMVCC.Data;

namespace miPrimerMVCC.Controllers
{
    public class DatosController : Controller
    {
       
        public ActionResult Main() 
        {
            return View();
        }
        // GET: Datos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Datos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Datos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Datos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Datos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Datos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Datos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Datos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
