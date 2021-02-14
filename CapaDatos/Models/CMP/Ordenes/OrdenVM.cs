using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataLayer.Models
{
    public class OrdenVM
    {
        public Orden Orden { get; set; }
        public IEnumerable<SelectListItem> ListaProveedores { get; set; }
        public List<Orden_Detalle> ListaOrden_Detalle { get; set; }
    }
}