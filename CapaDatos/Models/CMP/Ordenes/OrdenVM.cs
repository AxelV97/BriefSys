using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class OrdenVM
    {
        public Orden Orden { get; set; }
        public Orden_Detalle Orden_Detalle { get; set; }
        public List<Orden_Detalle> ListaOrden_Detalle { get; set; }
    }
}