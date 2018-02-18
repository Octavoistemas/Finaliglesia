using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MiembroMatriculaModeloVista
    {
        public int idmiembro { get; set; }
        public int idmatricula { get; set; }
        public string Estudiante { get; set; }
        public string Iglesia { get; set; }
        public string Catequista { get; set; }
        public string Sacramento { get; set; }
        public string Periodo { get; set; }
    }
}