using BriefSys.Models.RH.Context;
using BriefSys.Models.RH.Departamentos;
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

        public ActionResult Index()
        {
            return View();
        }

        /*---------------
         * Departamentos
         ----------------*/
        [HttpGet]
        public ActionResult Departamentos()
        {
            return View("~/Views/RH/Departamento/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetDepartamentos()
        {
            return Json(new { data = db.Departamentos }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateDepartamento()
        {
            return View("~/Views/RH/Departamento/Create.cshtml", new Departamento());
        }

        [HttpPost]
        public ActionResult CreateDepartamento(Departamento oDepartamento)
        {
            var dbSetDepartamentos = db.Departamentos;

            var existentes = (from a in dbSetDepartamentos
                              where a.IdDepartamento == oDepartamento.IdDepartamento
                              select a).ToList();

            if (existentes.Count > 0)
            {
                return View("~/Views/RH/Departamento/Create.cshtml", oDepartamento);
            }
            else
            {
                oDepartamento.Estado = "A";
                if (ModelState.IsValid)
                {
                    dbSetDepartamentos.Add(oDepartamento);
                    db.SaveChanges();
                    return RedirectToRoute(new { controller = "RH", action = "Departamentos" });
                }
            }

            return View("~/Views/RH/Departamento/Create.cshtml", oDepartamento);
        }

        /*---------
         * Puestos
        -----------*/
        [HttpGet]
        public ActionResult Puestos()
        {
            return View("~/Views/RH/Puestos/Index.cshtml");
        }

        /*-----------
         * Empleados
         ------------*/
        [HttpGet]
        public ActionResult Empleados()
        {
            return View("~/Views/RH/Empleados/Index.cshtml");
        }
    }
}