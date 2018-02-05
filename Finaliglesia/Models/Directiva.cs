using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Directiva
    {
        public int DirectivaID { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string email { get; set; }
        public int IglesiasId { get; set; }
        public ICollection<Iglesia> Iglesias { get; set; }
        public int CargosId { get; set; }
        public ICollection<Cargo> Cargos { get; set; }
        public int PeriodosId { get; set; }
        public ICollection<Periodo> Periodos { get; set; }
    }
}