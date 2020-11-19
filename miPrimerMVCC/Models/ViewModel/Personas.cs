using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web100.Models.ViewModel
{
    public class Personas
    {
        public List<ListaPersona> ListaPersonas()
        {
            List<ListaPersona> lst = new List<ListaPersona>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionExamen"].ConnectionString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Select * from Persona", con);
                com.CommandType = CommandType.Text;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new ListaPersona
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Nombre = rdr["Nombre"].ToString(),
                        ApellidoPaterno = rdr["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = rdr["ApellidoMaterno"].ToString(),
                        Estatus = Convert.ToBoolean(rdr["Estatus"]),
                    });
                }
                return lst;
            }
        }
    }
}