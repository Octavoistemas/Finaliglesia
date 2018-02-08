using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class BusquedaCereminia
    {
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Sacramento{ get; set; }
        public string  Iglesia { get; set; }
    }
}