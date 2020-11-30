using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Models.Acceso
{
    public class Acceso_UsuarioVM
    {
        public Acceso_Usuario Acceso_Usuario { get; set; }
        public IEnumerable<SelectListItem> ListaEmpleados { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}