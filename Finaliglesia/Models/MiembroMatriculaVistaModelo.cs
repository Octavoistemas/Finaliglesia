using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MiembroMatriculaVistaModelo
    {
        private ApplicationDbContext db;
        public MiembroMatriculaVistaModelo()
        {
            db = new ApplicationDbContext();
        }

        public List<MiembroMatriculaModeloVista> MiembroMatriculas()
        {
            var consulta = from mm in db.MiembrosMatriculas
                           join m in db.Matriculas on mm.MatriculasId equals m.MatriculaID 
                           join i in db.Iglesias on m.IglesiasId equals i.IglesiaID
                           join c in db.Catequistas on m.CatequistasId equals c.CatequistaID 
                           join s in db.Sacramentos on m.SacramentosId equals s.SacramentoID
                           join p in db.Periodos on m.PeriodosId equals p.PeriodoID 
                           orderby mm.MiembroMatriculaID descending
                           from mi in mm.Miembros
                           where mi.Rol == "Estudiante"
                           select new MiembroMatriculaModeloVista
                           {
                               idmatricula = m.MatriculaID,
                               idmiembro = mi.MiembroID,
                               Estudiante= (mi.Nombre + " " + mi.Apellido),
                               Iglesia =i.Nombre,
                               Catequista = (c.Nombre + "" + c.Apellido),
                               Sacramento = s.DetalleSacramento,
                               Periodo = p.Detalle
                           };
            return consulta.ToList();
        }
    }
}