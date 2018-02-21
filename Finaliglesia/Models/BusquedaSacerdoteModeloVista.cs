using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class BusquedaSacerdoteModeloVista
    {
        private ApplicationDbContext db;
        public BusquedaSacerdoteModeloVista()
        {
            db = new ApplicationDbContext();
            SacerdoteLista = new List<BusquedaSacerdote>();
        }
        public List<BusquedaSacerdote> SacerdoteLista { get; set; }

        public void SacerdoteConsultas(DateTime Fecha)
        {
            //object consulta = null;

            var consultaa = (from u in db.Users
                             where u.UserName == datosIncioSession.UserName
                             select new
                             {
                                 u.Cedula
                             }).ToList();

            if (consultaa != null)
            {
                foreach (var item in consultaa)
                {

                    var consulta = (from s in db.Sacerdotes
                                join c in db.Ceremonias on s.SacerdoteID equals c.SacerdotesId
                                join i in db.Iglesias on c.iglesiaid equals i.IglesiaID
                                join sc in db.Sacramentos on c.SacramentosId equals sc.SacramentoID
                                join tc in db.TipoCeremonias on c.TipoCeremoniasId equals tc.TipoceremoniaID
                                where s.Cedula.Contains(item.Cedula) && c.Fecha.Equals(Fecha)

                                select new
                                {
                                    s.Cedula,
                                    s.NombreSacerdote,
                                    s.ApellidoSacerdote,
                                    c.Fecha,
                                    c.Hora,
                                    i.Nombre,
                                    sc.DetalleSacramento,
                                    tc.Detalle

                                }).ToList();

                    SacerdoteLista.Clear();
                    if (consulta != null)
                    {
                        var lSacerdote = consulta.ToList();
                        foreach (var item1 in lSacerdote)
                        {
                            SacerdoteLista.Add(new BusquedaSacerdote
                            {

                                Cedula = item1.Cedula,
                                Nombre = item1.NombreSacerdote + " " + item1.ApellidoSacerdote,
                                Fecha = item1.Fecha,
                                Hora = item1.Hora,
                                Iglesia = item1.Nombre,
                                Sacramento = item1.DetalleSacramento,
                                TipoCeremonia = item1.Detalle

                            });
                        }
                    }
                }
                
            }
            //var consulta = from s in db.Sacerdotes
            //               join c in db.Ceremonias on s.SacerdoteID equals c.SacerdotesId
            //               join i in db.Iglesias on c.iglesiaid equals i.IglesiaID
            //               join sc in db.Sacramentos on c.SacramentosId equals sc.SacramentoID
            //               join tc in db.TipoCeremonias on c.TipoCeremoniasId equals tc.TipoceremoniaID
            //               where s.Cedula.Contains(model.UserName) && c.Fecha.Equals(Fecha)

            //               select new
            //               {
            //                   s.Cedula,
            //                   s.NombreSacerdote,
            //                   s.ApellidoSacerdote,
            //                   c.Fecha,
            //                   c.Hora,
            //                   i.Nombre,
            //                   sc.DetalleSacramento,
            //                   tc.Detalle
                               
            //               };
            //SacerdoteLista.Clear();
            //if (consulta != null)
            //{
            //    var lSacerdote = consulta.ToList();
            //    foreach (var item in lSacerdote)
            //    {
            //        SacerdoteLista.Add(new BusquedaSacerdote
            //        {
                        
            //            Cedula=item.Cedula,
            //            Nombre = item.NombreSacerdote+" "+item.ApellidoSacerdote,
            //            Fecha = item.Fecha,
            //            Hora=item.Hora,
            //            Iglesia = item.Nombre,
            //            Sacramento=item.DetalleSacramento,
            //            TipoCeremonia=item.Detalle

            //        });
            //    }
            //}
        }
    }
}