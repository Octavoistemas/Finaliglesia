using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MatriculasModelVista
    {
        public int MatriculaID { get; set; }
        public string Iglesia { get; set; }
        public string Catequista { get; set; }
        public string Sacramento { get; set; }
        public string Periodo { get; set; }
    }
}