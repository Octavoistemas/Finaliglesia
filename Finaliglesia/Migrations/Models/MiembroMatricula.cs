using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MiembroMatricula
    {
        public int MiembroMatriculaID { get; set; }
        public int MiembrosId { get; set; }
        public ICollection<Miembro> Miembros { get; set; }
        public int MatriculasId { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }
    }
}