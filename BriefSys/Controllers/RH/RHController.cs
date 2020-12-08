using BriefSys.Models.RH.Context;
using BriefSys.Models.RH.Departamentos;
using BriefSys.Models.RH.Empleados;
using BriefSys.Models.RH.Puestos;
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
            return View("~/Views/RH/Departamentos/Index.cshtml");
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
            return View("~/Views/RH/Departamentos/Create.cshtml", new Departamento());
        }

        [HttpPost]
        public ActionResult CreateDepartamento(Departamento oDepartamento)
        {
            var dbSetDepartamentos = db.Departamentos;

            var lDepartamentos = (from a in dbSetDepartamentos
                                  where a.IdDepartamento == oDepartamento.IdDepartamento
                                  select a).ToList();

            if (lDepartamentos.Count > 0)
            {
                return View("~/Views/RH/Departamentos/Create.cshtml", oDepartamento);
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

            return View("~/Views/RH/Departamentos/Create.cshtml", oDepartamento);
        }

        [HttpGet]
        public ActionResult EditDepartamento(int Id)
        {
            var dbSetDepartamentos = db.Departamentos;
            var lDepartamentos = (from d in dbSetDepartamentos
                                  where d.IdDepartamento == Id
                                  select d).ToList();
            Departamento oDepartamento;

            if (lDepartamentos.Count > 0)
            {
                oDepartamento = lDepartamentos[0];
            }
            else
            {
                return HttpNotFound();
            }

            return View("~/Views/RH/Departamentos/Edit.cshtml", oDepartamento);
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
            var lDepartamentos = (from d in dbSetDepartamentos
                                  where d.IdDepartamento == Id
                                  select d).ToList();

            Departamento oDepartamento;

            if (lDepartamentos.Count > 0)
            {
                oDepartamento = lDepartamentos[0];

                oDepartamento.Estado = "C";
                db.Entry(oDepartamento).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "RH", action = "Departamentos" });
        }

        public IEnumerable<SelectListItem> listaDepartamentos()
        {
            return db.Departamentos.Select(d => new SelectListItem()
            {
                Text = d.Descripcion,
                Value = d.IdDepartamento.ToString()
            });
        }

        /*---------
         * Puestos
        -----------*/
        [HttpGet]
        public ActionResult Puestos()
        {
            return View("~/Views/RH/Puestos/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetPuestos()
        {
            var dbSetPuestos = db.Puestos;
            var puestos = from dp in dbSetPuestos
                          where dp.Estado != "C"
                          select dp;

            return Json(new { data = puestos }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<SelectListItem> listaPuestos()
        {
            return db.Puestos.Select(p => new SelectListItem()
            {
                Text = p.Descripcion,
                Value = p.IdPuesto.ToString()
            });
        }

        [HttpGet]
        public ActionResult CreatePuesto()
        {
            PuestoVM puestoVM = new PuestoVM()
            {
                Puesto = new Puesto(),
                ListaDepartamentos = listaDepartamentos()
            };

            return View("~/Views/RH/Puestos/Create.cshtml", puestoVM);
        }

        [HttpPost]
        public ActionResult CreatePuesto(PuestoVM oPuestoVM)
        {
            Puesto oPuesto = oPuestoVM.Puesto;
            var dbSetPuestos = db.Puestos;

            var lPuestos = (from p in dbSetPuestos
                            where p.IdPuesto == oPuesto.IdPuesto
                            select p).ToList();

            if (lPuestos.Count > 0)
            {
                return View("~/Views/RH/Puestos/Create.cshtml", oPuestoVM);
            }
            else
            {
                oPuesto.Estado = "A";
                if (ModelState.IsValid)
                {
                    dbSetPuestos.Add(oPuesto);
                    db.SaveChanges();
                    return RedirectToRoute(new { controller = "RH", action = "Puestos" });
                }
            }

            return View("~/Views/RH/Puestos/Create.cshtml", oPuestoVM);
        }

        [HttpGet]
        public ActionResult EditPuesto(int Id)
        {
            var dbSetPuestos = db.Puestos;
            var lPuestos = (from d in dbSetPuestos
                            where d.IdPuesto == Id
                            select d).ToList();
            Puesto oPuesto;

            if (lPuestos.Count > 0)
            {
                oPuesto = lPuestos[0];
            }
            else
            {
                return HttpNotFound();
            }

            return View("~/Views/RH/Puestos/Edit.cshtml", oPuesto);
        }

        [HttpPost]
        public ActionResult EditPuesto(Puesto oPuesto)
        {
            var dbSetDepartamentos = db.Departamentos;
            if (ModelState.IsValid)
            {
                db.Entry(oPuesto).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToRoute(new { controller = "RH", action = "Puestos" });
        }

        public ActionResult DeletePuesto(int Id)
        {
            var dbSetPuestos = db.Puestos;
            var lPuestos = (from d in dbSetPuestos
                            where d.IdPuesto == Id
                            select d).ToList();

            Puesto oPuesto;

            if (lPuestos.Count > 0)
            {
                oPuesto = lPuestos[0];

                oPuesto.Estado = "C";
                db.Entry(oPuesto).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "RH", action = "Puestos" });
        }

        /*-----------
         * Empleados
         ------------*/
        [HttpGet]
        public ActionResult Empleados()
        {
            return View("~/Views/RH/Empleados/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetEmpleados()
        {
            var dbSetEmpleados = db.Empleados;
            var dbSetEmpleados_Detalle = db.EmpleadosDetalle;

            var empleados = from e in dbSetEmpleados
                            join ed in dbSetEmpleados_Detalle on e.IdEmp equals ed.IdEmp
                            where ed.Estado != "C"
                            select e;

            return Json(new { data = empleados }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateEmpleado()
        {
            EmpleadoVM oEmpleadoVM = new EmpleadoVM()
            {
                Empleado = new Empleado(),
                Empleado_Detalle = new Empleado_Detalle(),
                ListaDepartamentos = listaDepartamentos(),
                ListaPuestos = listaPuestos()
            };

            return View("~/Views/RH/Empleados/Create.cshtml", oEmpleadoVM);
        }

        [HttpPost]
        public ActionResult CreateEmpleado(EmpleadoVM oEmpleadoVM)
        {
            var dbSetEmpleados = db.Empleados;

            var lEmpleados = (from e in dbSetEmpleados
                              where e.IdEmp == oEmpleadoVM.Empleado.IdEmp
                              select e).ToList();

            var dbSetEmpleadosDet = db.EmpleadosDetalle;

            var lEmpleadosDet = (from ed in dbSetEmpleadosDet
                                 where ed.IdEmp == oEmpleadoVM.Empleado.IdEmp
                                 select ed).ToList();

            if (lEmpleados.Count > 0 || lEmpleadosDet.Count > 0)
            {
                return View("~/Views/RH/Empleados/Create.cshtml", oEmpleadoVM);
            }
            else
            {
                Empleado oEmpleado = oEmpleadoVM.Empleado;
                Empleado_Detalle oEmpleadoDet = oEmpleadoVM.Empleado_Detalle;

                oEmpleadoDet.IdEmp = oEmpleado.IdEmp;
                oEmpleadoDet.Estado = "A";
                if (ModelState.IsValid)
                {
                    dbSetEmpleados.Add(oEmpleado);
                    dbSetEmpleadosDet.Add(oEmpleadoDet);
                    db.SaveChanges();
                    return RedirectToRoute(new { controller = "RH", action = "Empleados" });
                }
            }

            return View("~/Views/RH/Empleados/Create.cshtml", oEmpleadoVM);
        }
    }
}