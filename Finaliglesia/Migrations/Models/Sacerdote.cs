using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Sacerdote
    {
        public int SacerdoteID { get; set; }
        public string Cedula { get; set; }
        public string NombreSacerdote { get; set; }
        public string ApellidoSacerdote { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string email { get; set; }
    }
}