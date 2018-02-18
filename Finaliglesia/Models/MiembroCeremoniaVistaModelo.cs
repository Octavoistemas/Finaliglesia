using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MiembroCeremoniaVistaModelo
    {
        private ApplicationDbContext db;
        public MiembroCeremoniaVistaModelo()
        {
            db = new ApplicationDbContext();
        }

        public List<MiembroCeremoniaModeloVista> MienbroCeremonias()
        {
            var consulta = from mc in db.MiembrosCeremonias
                           join c in db.Ceremonias on mc.CeremoniasId equals c.CeremoniaID
                           join s in db.Sacramentos on c.SacramentosId equals s.SacramentoID
                           join t in db.TipoCeremonias on c.TipoCeremoniasId equals t.TipoceremoniaID
                           join i in db.Iglesias on c.iglesiaid equals i.IglesiaID
                           orderby mc.MiembroCeremoniaID descending
                           from m in mc.Miembros
                           where m.Rol == "Sacramentado"
                           select new MiembroCeremoniaModeloVista
                           {
                               Sacramento=s.DetalleSacramento,
                               Sacramentado = m.Nombre + " " + m.Apellido,
                               Fecha=c.Fecha,
                               Tipoceremonia=t.Detalle,
                               Iglesia=i.Nombre,
                               
                           };
            return consulta.ToList();
        }
    }
}