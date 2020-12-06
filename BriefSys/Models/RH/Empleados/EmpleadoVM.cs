using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BriefSys.Models.RH.Empleados
{
    public class EmpleadoVM
    {
        public Empleado Empleado { get; set; }
        public Empleado_Detalle Empleado_Detalle { get; set; }
    }
}