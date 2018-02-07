using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Ceremonia
    {
        public int  CeremoniaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int SacramentosId { get; set; }
        public ICollection<Sacramento> Sacramentos { get; set; }     
        public int SacerdotesId { get; set; }
        public ICollection<Sacerdote> Sacerdotes { get; set; }
        public int MiembroCeremoniaId { get; set; }
        public ICollection<MiembroCeremonia> MiembroCeremonia { get; set; }


    }
}