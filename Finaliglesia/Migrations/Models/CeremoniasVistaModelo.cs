using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class CeremoniasVistaModelo
    {
        private ApplicationDbContext db;
        public CeremoniasVistaModelo()
        {
            db = new ApplicationDbContext();
        }

        public List<CeremoniasModeloVista> Ceremonias()
        {
            var consulta = from c in db.Ceremonias
                           join tc in db.TipoCeremonias on c.CeremoniaID equals tc.CeremoniaId
                           join i in db.Iglesias on c.IglesiasId equals i.IglesiaID
                           join f in db.Horarios on c.HoraiosId equals f.HorarioID
                           join s in db.Sacramentos on c.SacramentosId equals s.SacramentoID
                           join sc in db.Sacerdotes on c.SacerdotesId equals sc.SacerdoteID
                           select new CeremoniasModeloVista
                           {
                               CeremoniaID=c.CeremoniaID,
                               TipoCeremonia=tc.Detalle,
                               Iglesias=i.Nombre,
                               fecha=f.Fecha.ToString("dd/MM/yyyy"),
                               hora=f.Hora.ToString("t"),
                               Sacramentos=s.DetalleSacramento,
                               Sacerdotes=sc.NombreSacerdote+" "+sc.ApellidoSacerdote
                           };
            return consulta.ToList();
        }
    }
}