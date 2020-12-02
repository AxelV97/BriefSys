using BriefSys.Models.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Controllers.RH
{
    public class RHController : Controller
    {
        private RHContext db = new RHContext();
        // GET: RH
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleado
        public ActionResult Departamentos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDepartamentos()
        {
            return Json(new { data = db.Departamentos }, JsonRequestBehavior.AllowGet);
            //return View();
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