using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Models.RH.Empleados
{
    public class EmpleadoVM
    {
        public Empleado Empleado { get; set; }
        public Empleado_Detalle Empleado_Detalle { get; set; }
        public IEnumerable<SelectListItem> ListaDepartamentos { get; set; }
        public IEnumerable<SelectListItem> ListaPuestos { get; set; }
    }
}