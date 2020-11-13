﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
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

        public ActionResult Editar(int? Id)
        {
            var cPersona = new RegistroPersona();

            var oPersona = db.Persona.Find(Id);

            bool bEstatus = cPersona.Estatus;

            cPersona.Nombre = oPersona.Nombre;
            cPersona.ApellidoPaterno = oPersona.ApellidoPaterno;
            cPersona.ApellidoMaterno = oPersona.ApellidoMaterno;
            cPersona.Estatus = oPersona.Estatus;

            return View(cPersona);
        }

        [HttpPost]
        public ActionResult AgregarEdicion(RegistroPersona model)
        {
            try
            {
                var cPersona = db.Persona.Find(model.Id);

                cPersona.Nombre = model.Nombre;
                cPersona.ApellidoPaterno = model.ApellidoPaterno;
                cPersona.ApellidoMaterno = model.ApellidoMaterno;
                cPersona.Estatus = model.Estatus;

                db.Entry(cPersona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarRegistro(RegistroPersona model)
        {
            try
            {
                bool bEstatus = model.Estatus;

                var cPersona = new Persona();

                cPersona.Nombre = model.Nombre;
                cPersona.ApellidoPaterno = model.ApellidoPaterno;
                cPersona.ApellidoMaterno = model.ApellidoMaterno;
                cPersona.Estatus = model.Estatus;

                db.Persona.Add(cPersona);
                db.SaveChanges();
           
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
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