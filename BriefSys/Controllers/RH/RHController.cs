using BriefSys.Models.RH.Context;
using BriefSys.Models.RH.Departamentos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var dbSetDepartamentos = db.Departamentos;
            var departamentos = from dp in dbSetDepartamentos
                                where dp.Estado != "C"
                                select dp;

            return Json(new { data = departamentos }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult EditDepartamento(int Id)
        {
            var dbSetDepartamentos = db.Departamentos;

            Departamento oDepartamento = (from d in dbSetDepartamentos
                                          where d.IdDepartamento == Id
                                          select d).ToList()[0];

            if (oDepartamento == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/RH/Departamento/Edit.cshtml", oDepartamento);
        }

        [HttpPost]
        public ActionResult EditDepartamento(Departamento oDepartamento)
        {
            var dbSetDepartamentos = db.Departamentos;
            if (ModelState.IsValid)
            {
                db.Entry(oDepartamento).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToRoute(new { controller = "RH", action = "Departamentos" });
        }

        public ActionResult DeleteDepartamento(int Id)
        {
            var dbSetDepartamentos = db.Departamentos;

            Departamento oDepartamento = (from d in dbSetDepartamentos
                                          where d.IdDepartamento == Id
                                          select d).ToList()[0];

            if (oDepartamento == null)
            {
                return HttpNotFound();
            }
            else
            {
                oDepartamento.Estado = "C";
                db.Entry(oDepartamento).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToRoute(new { controller = "RH", action = "Departamentos" });
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