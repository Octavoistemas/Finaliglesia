using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Horario
    {
        public int HorarioID { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

    }
}