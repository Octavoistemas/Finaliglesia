using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Ceremonia
    {
        public int  CeremoniaID { get; set; }
        
        public int IglesiasId { get; set; }
        public ICollection<Iglesia> Iglesias { get; set; }
        public int HoraiosId { get; set; }
        public ICollection<Horario> Horarios { get; set; }
        public int SacramentosId { get; set; }
        public ICollection<Sacramento> Sacramentos { get; set; }
        public int FacturasId { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public int SacerdotesId { get; set; }
        public ICollection<Sacerdote> Sacerdotes { get; set; }
        public int MiembroCeremoniaId { get; set; }
        public ICollection<MiembroCeremonia> MiembroCeremonia { get; set; }


    }
}