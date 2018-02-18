using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MatriculasVistaModelo
    {
        private ApplicationDbContext db;
        public MatriculasVistaModelo()
        {
            db = new ApplicationDbContext();
        }

        public List<MatriculasModelVista> Matriculas()
        {
            var consulta = from m in db.Matriculas
                           join i in db.Iglesias on m.IglesiasId equals i.IglesiaID
                           join c in db.Catequistas on m.CatequistasId equals c.CatequistaID
                           join s in db.Sacramentos on m.SacramentosId equals s.SacramentoID
                           join p in db.Periodos on m.PeriodosId equals p.PeriodoID
                           orderby m.MatriculaID descending
                           select new MatriculasModelVista
                           {
                               MatriculaID=m.MatriculaID,
                               Iglesia=i.Nombre,
                               Catequista=c.Nombre+" "+c.Apellido,
                               Sacramento=s.DetalleSacramento,
                               Periodo=p.Detalle                           
                           };
            return consulta.ToList();
        }
    }
}