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

        private Personas cPersona = new Personas();

        public ActionResult Personas()
        {
            return View();
        }

        public JsonResult ListaPersonas()
        {
            /*
            List<ListaPersona> lista = new List<ListaPersona>();

            lista = (from R in db.Persona
                     select new ListaPersona
                     {
                         Id = R.Id,
                         Nombre = R.Nombre,
                         ApellidoPaterno = R.ApellidoPaterno,
                         ApellidoMaterno = R.ApellidoMaterno,
                         Estatus = (bool)R.Estatus
                     }).ToList();*/

            return Json(cPersona.ListaPersonas(), JsonRequestBehavior.AllowGet);
        }

    }
}
