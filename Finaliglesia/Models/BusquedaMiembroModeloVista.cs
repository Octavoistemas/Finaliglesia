using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class BusquedaMiembroModeloVista
    {
        private ApplicationDbContext db;
        public BusquedaMiembroModeloVista()
        {
            db = new ApplicationDbContext();
            MiembroLista = new List<BusquedaMiembros>();
        }
        public List<BusquedaMiembros> MiembroLista { get; set; }

        //public void consulta()
        //{
        //    var con = from mc in db.MiembrosCeremonias
        //              select new {
        //                 Ceremosnia =(from c in mc.Ceremonias select c.TipoCeremoniasId),
        //                 Miembros = (from m in mc.Miembros where )

        //                              ),
        //              };
        //}
        public void MiembroConsultas(int idiglesia,int idperiodo,int idsacramento)
        {
            var consulta = from m in db.Matriculas
                           join mm in db.MiembrosMatriculas on m.MatriculaID equals mm.MiembroMatriculaID
                           where
                             m.IglesiasId == idiglesia &&
                             m.PeriodosId == idperiodo &&
                             m.SacramentosId == idsacramento
                           from mb in mm.Miembros
                           where mb.Rol == "Estudiante"
                           select new 
                           {
                               mb.Cedula,
                               mb.Nombre,
                               mb.Apellido,
                               mb.Direccion,
                               mb.Celular,
                               mb.FechaNacimiento,
                               mb.email
                           };
            MiembroLista.Clear();
            if (consulta != null)
            {
                var lMiembro = consulta.ToList();
                foreach (var item in lMiembro)
                {
                    MiembroLista.Add(new BusquedaMiembros
                    {
                        Cedula = item.Cedula,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Direccion = item.Direccion,
                        Celular = item.Celular,
                        FechaNacimiento = item.FechaNacimiento,
                        email=item.email                  
                    });
                }
            }
        }
    }
}