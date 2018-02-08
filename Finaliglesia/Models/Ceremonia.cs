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
        [Display(Name = "Sacerdotes")]
        public int SacerdotesId { get; set; }
        public ICollection<Sacerdote> Sacerdotes { get; set; }
      

    }
}