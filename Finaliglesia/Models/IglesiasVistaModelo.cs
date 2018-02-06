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

        public List<IglesiasModelVista> ListaIglesias { get; set; }

        public void Iglesias()
        {
            var consulta = from i in db.Iglesias
                           join t in db.TipoIglesias on i.TipoIglesiasId equals t.TipoiglesiaID
                           select new
                           {
                               i.IglesiaID,
                               i.Nombre,
                               i.Direccion,
                               t.Detalle
                           };
            ListaIglesias.Clear();
            if (consulta != null)
            {
                var ligkesias = consulta.ToList();
                foreach (var item in ligkesias)
                {
                    ListaIglesias.Add(new IglesiasModelVista
                    {
                        IdIglesia = item.IglesiaID,
                        Nombre = item.Nombre,
                        Direccion = item.Direccion,
                        Tipo = item.Detalle
                    }
                        );
                }
            }


        }
    }
}