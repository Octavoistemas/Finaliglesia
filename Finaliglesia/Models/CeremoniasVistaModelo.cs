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
                           join s in db.Sacramentos on c.SacramentosId equals s.SacramentoID
                           join sc in db.Sacerdotes on c.SacerdotesId equals sc.SacerdoteID
                           select new CeremoniasModeloVista
                           {
                               CeremoniaID=c.CeremoniaID,
                               TipoCeremonia=tc.Detalle,
                               Sacramentos=s.DetalleSacramento,
                               Sacerdotes=sc.NombreSacerdote+" "+sc.ApellidoSacerdote
                           };
            return consulta.ToList();
        }
    }
}