using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class IglesiasVistaModelo
    {
        private ApplicationDbContext db;
        public IglesiasVistaModelo() {
            db = new ApplicationDbContext();
        }
        
        public List<IglesiasModelVista> Iglesias()
        {
            var consulta = from i in db.Iglesias
                           join t in db.TipoIglesias on i.TipoIglesiasId equals t.TipoiglesiaID
                           select new IglesiasModelVista
                           {
                              IdIglesia =  i.IglesiaID,
                              Nombre= i.Nombre,
                              Direccion= i.Direccion,
                               Tipo = t.Detalle
                           };
            return consulta.ToList();
        }
    }
}