using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Finaliglesia.Models
{
    public class Catequista
    {
        public int CatequistaID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        [Display(Name = "Iglesia")]
        public int IglesiasId { get; set; }
        public ICollection<Iglesia> Iglesias { get; set; }

    }
}