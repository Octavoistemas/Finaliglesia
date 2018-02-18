using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class BusquedaMiembros
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string email { get; set; }
    }
}