using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class CatequistasVistaModelo
    {
        private ApplicationDbContext db;
        public CatequistasVistaModelo()
        {
            db = new ApplicationDbContext();
        }

        public List<CatequistasModelVista> Catequistas()
        {
            var consulta = from c in db.Catequistas
                           join i in db.Iglesias on c.IglesiasId equals i.IglesiaID
                           select new CatequistasModelVista
                           {
                               CatequistaID=c.CatequistaID,
                               Cedula=c.Cedula,
                               Nombre=c.Nombre,
                               Apellido=c.Apellido,
                               Direccion=c.Direccion,
                               Telefono=c.Telefono,
                               Celular=c.Celular,
                               Email=c.Email,
                               Iglesia=i.Nombre                             
                           };
            return consulta.ToList();
        }
    }
}