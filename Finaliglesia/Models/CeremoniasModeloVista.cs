﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finaliglesia.Models
{
    public class CeremoniasModeloVista
    {
        public int CeremoniaID { get; set; }     
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string  Sacramentos { get; set; }
        public string Sacerdotes { get; set; }
        public string TipoCeremonia { get; set; }
        public string Iglesia { get; set; }
    }
}