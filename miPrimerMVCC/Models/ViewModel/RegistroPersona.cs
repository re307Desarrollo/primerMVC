using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web100.Models.ViewModel
{
    public class RegistroPersona
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("ApellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [DisplayName("ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [DisplayName("Estatus")]
        public bool Estatus { get; set; }
    }
}