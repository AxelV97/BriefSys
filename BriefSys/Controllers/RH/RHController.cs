using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Controllers.RH
{
    public class RHController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Departamentos()
        {
            return View();
        }
        public ActionResult Puestos()
        {
            return View();
        }
        public ActionResult Empleados()
        {
            return View();
        }
    }
}