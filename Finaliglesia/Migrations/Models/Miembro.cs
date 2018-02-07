using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Miembro
    {
        public int MiembroID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string email { get; set; }
        //public int CeremoniasId { get; set; }
        //public ICollection<Ceremonia> Ceremonias { get; set; }
    }
}