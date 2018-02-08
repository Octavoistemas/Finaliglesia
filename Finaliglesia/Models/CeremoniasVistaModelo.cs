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
                           join s in db.Sacramentos on c.SacramentosId equals s.SacramentoID
                           join sc in db.Sacerdotes on c.SacerdotesId equals sc.SacerdoteID
                           join i in db.Iglesias on c.iglesiaid equals i.IglesiaID
                           select new CeremoniasModeloVista
                           {
                               CeremoniaID=c.CeremoniaID,
                               Iglesias=i.Nombre,
                               fecha=c.Fecha,
                               hora=c.Hora,
                               Sacramentos=s.DetalleSacramento,
                               Sacerdotes=sc.NombreSacerdote+" "+sc.ApellidoSacerdote

                           };
            return consulta.ToList();
        }
    }
}