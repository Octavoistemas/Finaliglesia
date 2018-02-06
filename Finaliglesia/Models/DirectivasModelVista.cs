using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class DirectivasModelVista
    {
        public int DirectivaID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string email { get; set; }
        public string Iglesias { get; set; }
        public string Cargo { get; set; }
        public string Periodo { get; set; }
    }
}