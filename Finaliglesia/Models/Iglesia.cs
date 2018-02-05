using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Iglesia
    {
        public int IglesiaID { get; set; }
        public string Nombre { get; set; }
        public int Direccion { get; set; }
        public int TipoIglesiasId { get; set; }
        public ICollection<Tipoiglesia> TipoIglesias { get; set; }
    }
}