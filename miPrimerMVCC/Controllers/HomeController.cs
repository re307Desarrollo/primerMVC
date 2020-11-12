using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Web100.Models;
using Web100.Models.ViewModel;

namespace Web100.Controllers
{
    public class HomeController : Controller
    {
        private ExamenEntitiesPersona db = new ExamenEntitiesPersona();

        public ActionResult Index()
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

            return View(lista);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Actualizar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            try
            {
                var del = db.Persona.Find(Id);
                db.Persona.Remove(del);
                db.SaveChanges();

                return Content("1");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message.ToString());

                return Content(e.Message);
            }
        }

    }
}