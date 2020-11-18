using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Configuration;
using System.Web.Services.Protocols;
using Web100.Models;
using Web100.Models.ViewModel;
using System.Web.Configuration;
using System.Data;
using System.Collections.Specialized;

namespace Web100.Controllers
{
    public class PersonasController : Controller
    {
        private ExamenEntitiesPersona db = new ExamenEntitiesPersona();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
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

        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
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

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
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


        public ActionResult Personas()
        {
            return View();
        }

        public JsonResult ListaPersonas()
        {
            List<ListaPersona> lista;

            lista = (from R in db.Persona
                     select new ListaPersona
                     {
                         Id = R.Id,
                         Nombre = R.Nombre,
                         ApellidoPaterno = R.ApellidoPaterno,
                         ApellidoMaterno = R.ApellidoMaterno,
                         Estatus = (bool)R.Estatus
                     }).ToList();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

    }
}
