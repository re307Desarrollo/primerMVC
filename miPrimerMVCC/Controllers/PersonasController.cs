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
using Newtonsoft.Json;

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
            List<ListaPersona> lista = new List<ListaPersona>();

            lista = (from R in db.Persona
                     select new ListaPersona
                     {
                         Id = R.Id,
                         Nombre = R.Nombre,
                         ApellidoPaterno = R.ApellidoPaterno,
                         ApellidoMaterno = R.ApellidoMaterno,
                         Estatus = (bool)R.Estatus
                     }).ToList();

            //return Json(cPersona.ListaPersonas(), JsonRequestBehavior.AllowGet);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtienePersona(int Id)
        {
            try
            {
                List<ListaPersona> lista = new List<ListaPersona>();

                List<string> ListaPersona = new List<string>();

                dynamic oPerson = new ListaPersona();

                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spR_ObtinePersona", connection);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader Read = command.ExecuteReader();

                    while (Read.Read())
                    {
                        lista.Add(new ListaPersona
                        {
                            Id = Convert.ToInt32(Read["Id"]),
                            Nombre = Read["Nombre"].ToString(),
                            ApellidoPaterno = Read["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = Read["ApellidoMaterno"].ToString(),
                            Estatus = Convert.ToBoolean(Read["Estatus"]),
                        });
                    }
                }

                var lts = lista.Find(x => x.Id.Equals(Id));

                return Json(lts, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AgregarPersona(string Nombre, string ApellidoPaterno, string ApellidoMaterno, Boolean Estatus)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spC_CreaPersona", connection);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
                    command.Parameters.AddWithValue("@Estatus", Estatus);
                    command.CommandType = CommandType.StoredProcedure;

                    int iResultado = command.ExecuteNonQuery();

                    return Json(new { Resultado = iResultado }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult AgregarPersona1(string Nombre, string ApellidoPaterno, string ApellidoMaterno, Boolean Estatus)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spC_CreaPersona", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
                    command.Parameters.AddWithValue("@Estatus", Estatus);

                    int iResultado = command.ExecuteNonQuery();

                    return Content("" + iResultado);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Content(ex.Message.ToString());
                }
            }
        }

        public ActionResult EliminarPersona(int Id)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                DataTable dts = new DataTable();
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spD_EliminaPersona", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);
                   
                    int i = command.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dts);

                    string dato = dts.Rows[0]["Id"].ToString();
                    return Content("" + i);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Content(ex.Message.ToString());
                }
            }
        }

        public int EliminarPersona2(int Id)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                DataTable dts = new DataTable();
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spD_EliminaPersona", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);

                    int i = command.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dts);

                    string dato = dts.Rows[0]["Id"].ToString();

                    return i;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        public JsonResult EliminarPersona3(int Id)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                DataTable dts = new DataTable();
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spD_EliminaPersona", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Id);

                    int i = command.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dts);

                    string dato = dts.Rows[0]["Id"].ToString();

                    return Json(i, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult ActualizarPersona(int Id, string Nombre, string ApellidoPaterno, string ApellidoMaterno, Boolean Estatus)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                DataTable dts = new DataTable();
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spU_ActualizaPersona", connection);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
                    command.Parameters.AddWithValue("@Estatus", Estatus);
                    command.CommandType = CommandType.StoredProcedure;

                    int iResultado = command.ExecuteNonQuery();

                    return Json(new { Resultado = iResultado }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
        }

    }
}
