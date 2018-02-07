using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class BusquedaCeremoniaModeloVista
    {
        private ApplicationDbContext db;
        public BusquedaCeremoniaModeloVista()
        {
            db = new ApplicationDbContext();
            //ClienteLista = new List<BusquedaCereminia>();
        }
        public List<BusquedaCereminia> CeremoniaLista { get; set; }
        public void ClienteConsultas(string apellido)
        {
            var consulta = from c in db.Ceremonias
                           join s in db.Sacramentos on c.SacramentosId equals s.SacramentoID    
                           join sc in db.Sacerdotes
                           where c.Apellido.Contains(apellido)
                           select new
                           {
                           };
            CeremoniaLista.Clear();
            if (consulta != null)
            {
                var lclientes = consulta.ToList();
                foreach (var item in lclientes)
                {
                    ClienteLista.Add(new BusquedaCliente
                    {
                        ClienteId = item.ClienteId,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        edad = item.edad,
                        FechaNacimienot = item.FechaNacimienot,
                        Direcciones = item.Direcciones,
                        Correos = item.Correos,
                        Telefonos = item.Telefonos
                    });
                }
            }
        }
    }
}
}