using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Models.RH.Puestos
{
    public class PuestoVM
    {
        public Puesto Puesto { get; set; }
        public IEnumerable<SelectListItem> ListaDepartamentos { get; set; }
    }
}