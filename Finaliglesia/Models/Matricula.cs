using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int IglesiasId { get; set; }
        public ICollection<Iglesia> Iglesias { get; set; }
        public int CatequistasId { get; set; }
        public ICollection<Catequista> Catequistas { get; set; }
        public int SacramentosId { get; set; }
        public ICollection<Sacramento> Sacramentos { get; set; }
        public int PeriodosId { get; set; }
        public ICollection<Periodo> Periodos { get; set; }


    }
}