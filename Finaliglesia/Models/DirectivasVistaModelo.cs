using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class DirectivasVistaModelo
    {
        private ApplicationDbContext db;
        public DirectivasVistaModelo()
        {
            db = new ApplicationDbContext();
        }

        public List<DirectivasModelVista> Directivas()
        {
            var consulta = from d in db.Directivas
                           join i in db.Iglesias on d.IglesiasId equals i.IglesiaID
                           join c in db.Cargos on d.CargosId equals c.cargoID
                           join p in db.Periodos on d.PeriodosId equals p.PeriodoID
                           select new DirectivasModelVista
                           {
                               DirectivaID = d.DirectivaID,
                               Cedula=d.Cedula,
                               Nombre=d.Nombre,
                               Apellido=d.Apellido,
                               Direccion=d.Direccion,
                               Telefono=d.Telefono,
                               Celular=d.Celular,
                               email=d.email,
                               Iglesias= i.Nombre,
                               Cargo=c.Nombre,
                               Periodo= p.Detalle                            
                           };
            return consulta.ToList();
        }
    }
}