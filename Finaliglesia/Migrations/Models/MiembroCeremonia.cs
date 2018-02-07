using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class MiembroCeremonia
    {
        public int MiembroCeremoniaID { get; set; }
        public string Rol { get; set; }
        public int MiembrosId { get; set; }
        public ICollection<Miembro> Miembros { get; set; }
        public int CeremoniasId { get; set; }
        public ICollection<Ceremonia> Ceremonias { get; set; }
    }
}