using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MiembroCeremoniaModeloVista
    {
        public string Sacramento { get; set; }
        public string Sacramentado { get; set; }
        public string Tipoceremonia { get; set; }
        public DateTime Fecha { get; set; }
        public string Iglesia { get; set; }
    }
}