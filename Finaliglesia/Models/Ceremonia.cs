using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Finaliglesia.Models
{
    public class Ceremonia
    {
        public int  CeremoniaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        [Display(Name ="Sacramento")]
        public int SacramentosId { get; set; }
        public ICollection<Sacramento> Sacramentos { get; set; }
        [Display(Name = "Tipo de Ceremonia")]
        public int TipoCeremoniasId { get; set; }
        public ICollection<Tipoceremonia> TipoCeremonias { get; set; }
        [Display(Name = "Sacerdote")]
        public int SacerdotesId { get; set; }
        public ICollection<Sacerdote> Sacerdotes { get; set; }
        [Display(Name = "Iglesia")]
        public int iglesiaid { get; set; }
        public ICollection<Iglesia> iglesias { get; set; }
    }
}