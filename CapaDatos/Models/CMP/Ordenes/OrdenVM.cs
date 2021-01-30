using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BriefSys.Models.CMP.Ordenes
{
    public class OrdenVM
    {
        public Orden Orden { get; set; }
        public Orden_Detalle Orden_Detalle { get; set; }
    }
}