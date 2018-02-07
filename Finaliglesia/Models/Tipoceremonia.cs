using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Tipoceremonia
    {
        public int TipoceremoniaID { get; set; }
        public string Detalle { get; set; }

        public int Costo { get; set; }
        public int CeremoniaId { get; set; }
        public ICollection<Ceremonia> Ceremosnias { get; set; }

    }
}