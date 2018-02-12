using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class BusquedaSacerdote
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Iglesia { get; set; }
        public string Sacramento { get; set; }
        public string TipoCeremonia { get; set; }

    }
}