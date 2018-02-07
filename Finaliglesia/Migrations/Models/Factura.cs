using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public string Numero { get; set; }
        public string DetalleFactura { get; set; }

    }
}