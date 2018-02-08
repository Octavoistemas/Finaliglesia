using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Finaliglesia.Models
{
    public class Iglesia
    {
        public int IglesiaID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [Display(Name = "Tipo")]
        public int TipoIglesiasId { get; set; }
        public ICollection<Tipoiglesia> TipoIglesias { get; set; }
       
    }
}