using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DataLayer.DataAccess;
using DataLayer.Models;
using DataLayer.Repositories;

namespace BriefSys.Controllers.RH
{
    public class RHController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RHController()
        {
            _db = new ApplicationDbContext();
        }

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
            //var dbSetDepartamentos = _db.Departamentos;

            //var departamentos = from dp in dbSetDepartamentos
            //                    where dp.Estado != "C"
            //                    select dp;

            RHRepository oRH = new RHRepository();
            List<Departamento> ldepartamentos = new List<Departamento>();
            ldepartamentos = oRH.obtenerDepartamentos();

            return View("~/Views/RH/Departamentos/Index.cshtml", ldepartamentos);
        }

        [HttpGet]
        public ActionResult GetDepartamentos()
        {
            var dbSetDepartamentos = _db.Departamentos;
            var departamentos = from dp in dbSetDepartamentos
                                where dp.Estado != "C"
                                select dp;

            return Json(new { data = departamentos }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getDepartamento(int id)
        {
            var dbSetDepartamentos = _db.Departamentos;
            var departamento = from dp in dbSetDepartamentos
                               where dp.Estado != "C" && dp.IdDepartamento == id
                               select dp;

            return Json(new { data = departamento }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateDepartamento()
        {
            return PartialView("~/Views/RH/Departamentos/Create.cshtml", new Departamento());
        }

        [HttpPost]
        public ActionResult CreateDepartamento(Departamento oDepartamento)
        {
            var dbSetDepartamentos = _db.Departamentos;

            var lDepartamentos = (from a in dbSetDepartamentos
                                  where a.IdDepartamento == oDepartamento.IdDepartamento
                                  select a).ToList();

            if (lDepartamentos.Count > 0)
            {
                return PartialView("~/Views/RH/Departamentos/Create.cshtml", oDepartamento);
            }
            else
            {
                oDepartamento.Estado = "A";
                if (ModelState.IsValid)
                {
                    dbSetDepartamentos.Add(oDepartamento);
                    _db.SaveChanges();
                }
                else
                {
                    return PartialView("~/Views/RH/Departamentos/Create.cshtml", oDepartamento);
                }
            }
            string respuesta = "Se ha insertado el dato con exito";
            bool exito = true;
            return Json(new { exito, respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditDepartamento(int id)
        {
            var dbSetDepartamentos = _db.Departamentos;
            var lDepartamentos = (from d in dbSetDepartamentos
                                  where d.IdDepartamento == id
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

            return PartialView("~/Views/RH/Departamentos/Edit.cshtml", oDepartamento);
        }

        //public string RenderRazorViewToString(string viewName, object model)
        //{
        //    ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
        //                                                                 viewName);
        //        var viewContext = new ViewContext(ControllerContext, viewResult.View,
        //                                     ViewData, TempData, sw);
        //        viewResult.View.Render(viewContext, sw);
        //        viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}

        [HttpPost]
        public ActionResult EditDepartamento(Departamento oDepartamento)
        {
            var dbSetDepartamentos = _db.Departamentos;
            if (ModelState.IsValid)
            {
                _db.Entry(oDepartamento).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return View("~/Views/RH/Departamentos/Edit.cshtml", oDepartamento);
            }

            return RedirectToRoute(new { controller = "RH", action = "Departamentos" });
        }

        public ActionResult DeleteDepartamento(int Id)
        {
            var dbSetDepartamentos = _db.Departamentos;
            var lDepartamentos = (from d in dbSetDepartamentos
                                  where d.IdDepartamento == Id
                                  select d).ToList();

            Departamento oDepartamento;

            if (lDepartamentos.Count > 0)
            {
                oDepartamento = lDepartamentos[0];

                oDepartamento.Estado = "C";
                _db.Entry(oDepartamento).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "RH", action = "Departamentos" });
        }

        public IEnumerable<SelectListItem> listaDepartamentos()
        {
            return _db.Departamentos.Select(d => new SelectListItem()
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
            var dbSetPuestos = _db.Puestos;
            var dbSetDepartamentos = _db.Departamentos;

            var puestos = (from pue in dbSetPuestos
                           join dep in dbSetDepartamentos on pue.IdDepartamento equals dep.IdDepartamento
                           where pue.Estado != "C"
                           select pue).OrderBy(x => x.IdPuesto);

            List<Puesto> lpuestos = new List<Puesto>();
            lpuestos = puestos.ToList();

            return View("~/Views/RH/Puestos/Index.cshtml", lpuestos);
        }

        [HttpGet]
        public ActionResult GetPuestos()
        {
            var dbSetPuestos = _db.Puestos;
            var dbSetDepartamentos = _db.Departamentos;

            var puestos = from pue in dbSetPuestos
                          join dep in dbSetDepartamentos on pue.IdDepartamento equals dep.IdDepartamento
                          where pue.Estado != "C"
                          select new
                          {
                              Departamento = dep.Descripcion,
                              IdPuesto = pue.IdPuesto,
                              Clasificación = pue.Clasificacion,
                              Descripcion = pue.Descripcion
                          };

            return Json(new { data = puestos }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<SelectListItem> listaPuestos()
        {
            return _db.Puestos.Select(p => new SelectListItem()
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

            return PartialView("~/Views/RH/Puestos/Create.cshtml", puestoVM);
        }

        [HttpPost]
        public ActionResult CreatePuesto(PuestoVM oPuestoVM)
        {
            Puesto oPuesto = oPuestoVM.Puesto;
            var dbSetPuestos = _db.Puestos;

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
                    _db.SaveChanges();
                }
                else
                {
                    oPuestoVM.ListaDepartamentos = listaDepartamentos();
                    return View("~/Views/RH/Puestos/Create.cshtml", oPuestoVM);
                }
            }

            return RedirectToRoute(new { controller = "RH", action = "Puestos" });
        }

        [HttpGet]
        public ActionResult EditPuesto(int Id)
        {
            var dbSetPuestos = _db.Puestos;
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

            return PartialView("~/Views/RH/Puestos/Edit.cshtml", oPuesto);
        }

        [HttpPost]
        public ActionResult EditPuesto(Puesto oPuesto)
        {
            var dbSetDepartamentos = _db.Departamentos;
            if (ModelState.IsValid)
            {
                _db.Entry(oPuesto).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return PartialView("~/Views/RH/Puestos/Edit.cshtml", oPuesto);
            }

            return RedirectToRoute(new { controller = "RH", action = "Puestos" });
        }

        public ActionResult DeletePuesto(int Id)
        {
            var dbSetPuestos = _db.Puestos;
            var lPuestos = (from d in dbSetPuestos
                            where d.IdPuesto == Id
                            select d).ToList();

            Puesto oPuesto;

            if (lPuestos.Count > 0)
            {
                oPuesto = lPuestos[0];

                oPuesto.Estado = "C";
                _db.Entry(oPuesto).State = EntityState.Modified;
                _db.SaveChanges();
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
            var dbSetEmpleados = _db.Empleados;
            var dbSetEmpleados_Detalle = _db.EmpleadosDetalle;
            var dbSetDepartamentos = _db.Departamentos;
            var dbSetPuestos = _db.Puestos;

            var empleados = (from e in dbSetEmpleados
                             join ed in dbSetEmpleados_Detalle on e.IdEmp equals ed.IdEmp
                             join dep in dbSetDepartamentos on e.IdDepartamento equals dep.IdDepartamento
                             join pue in dbSetPuestos on new { e.IdDepartamento, e.IdPuesto } equals new { pue.IdDepartamento, pue.IdPuesto }
                             where ed.Estado != "C"
                             select new VistaEmpleado
                             {
                                 IdEmp = e.IdEmp,
                                 Ingreso = e.Ingreso,
                                 Nombre = ed.Nombre,
                                 ApellidoP = ed.ApellidoP,
                                 ApellidoM = ed.ApellidoM,
                                 Telefono = ed.Telefono,
                                 Extension = ed.Extension,
                                 FechaNac = ed.FechaNac,
                                 Estado = ed.Estado,
                                 Departamento = dep.Descripcion,
                                 Puesto = pue.Descripcion
                             }).OrderBy(x => x.IdEmp);


            List<VistaEmpleado> lregistrosempleados = new List<VistaEmpleado>();
            lregistrosempleados = empleados.ToList();

            return View("~/Views/RH/Empleados/Index.cshtml", lregistrosempleados);
        }

        [HttpGet]
        public ActionResult GetEmpleados()
        {
            var dbSetEmpleados = _db.Empleados;
            var dbSetEmpleados_Detalle = _db.EmpleadosDetalle;
            var dbSetDepartamentos = _db.Departamentos;
            var dbSetPuestos = _db.Puestos;

            var empleados = from e in dbSetEmpleados
                            join ed in dbSetEmpleados_Detalle on e.IdEmp equals ed.IdEmp
                            join dep in dbSetDepartamentos on e.IdDepartamento equals dep.IdDepartamento
                            join pue in dbSetPuestos on dep.IdDepartamento equals pue.IdDepartamento
                            where ed.Estado != "C" && dep.Estado != "C" && pue.Estado != "C"
                            select new
                            {
                                IdEmp = e.IdEmp,
                                Departamento = dep.Descripcion,
                                Puesto = pue.Descripcion,
                                Ingreso = e.Ingreso,
                                Nombre = ed.Nombre,
                                Apellido_Paterno = ed.ApellidoP,
                                Apellido_Materno = ed.ApellidoM,
                                FechaNacimiento = ed.FechaNac,
                                Telefono = ed.Telefono
                            };
            string json = JsonConvert.SerializeObject(new { data = empleados }, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            return Content(json, "application/json");
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

            return PartialView("~/Views/RH/Empleados/Create.cshtml", oEmpleadoVM);
        }

        [HttpPost]
        public ActionResult CreateEmpleado(EmpleadoVM oEmpleadoVM)
        {
            var dbSetEmpleados = _db.Empleados;

            var lEmpleados = (from e in dbSetEmpleados
                              where e.IdEmp == oEmpleadoVM.Empleado.IdEmp
                              select e).ToList();

            var dbSetEmpleadosDet = _db.EmpleadosDetalle;

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

                oEmpleadoDet.Estado = "A";
                if (ModelState.IsValid)
                {
                    dbSetEmpleados.Add(oEmpleado);
                    _db.SaveChanges();
                    oEmpleadoDet.IdEmp = oEmpleado.IdEmp;

                    dbSetEmpleadosDet.Add(oEmpleadoDet);
                    _db.SaveChanges();
                }
                else
                {
                    return View("~/Views/RH/Empleados/Create.cshtml", oEmpleadoVM);
                }
            }
            return RedirectToRoute(new { controller = "RH", action = "Empleados" });
        }

        [HttpGet]
        public ActionResult EditEmpleado(int Id)
        {
            var dbsetempleados = _db.Empleados;
            var lempleados = (from e in dbsetempleados
                              where e.IdEmp == Id
                              select e).ToList();

            var dbsetempleados_detalle = _db.EmpleadosDetalle;
            var lempleados_detalle = (from ed in dbsetempleados_detalle
                                      where ed.IdEmp == Id
                                      select ed).ToList();
            Empleado oEmpleado;
            Empleado_Detalle oEmpleado_Detalle;
            EmpleadoVM empleadoVM;

            if (lempleados.Count > 0)
            {
                oEmpleado = lempleados[0];
                if (lempleados_detalle.Count > 0)
                {
                    oEmpleado_Detalle = lempleados_detalle[0];
                    empleadoVM = new EmpleadoVM
                    {
                        Empleado = oEmpleado,
                        Empleado_Detalle = oEmpleado_Detalle,
                        ListaDepartamentos = listaDepartamentos(),
                        ListaPuestos = listaPuestos()
                    };
                    return PartialView("~/Views/RH/Empleados/Edit.cshtml", empleadoVM);
                }
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "RH", action = "Empleados" });
        }

        [HttpPost]
        public ActionResult EditEmpleado(EmpleadoVM oEmpleadoVM)
        {
            var dbSetEmpleados = _db.Empleados;

            if (ModelState.IsValid)
            {
                Empleado oEmpleado = oEmpleadoVM.Empleado;
                Empleado_Detalle oEmpleado_Detalle = oEmpleadoVM.Empleado_Detalle;

                _db.Entry(oEmpleado).State = EntityState.Modified;
                _db.Entry(oEmpleado_Detalle).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return PartialView("~/Views/RH/Empleados/Edit.cshtml", oEmpleadoVM);
            }

            return RedirectToRoute(new { controller = "RH", action = "Empleados" });
        }

        public ActionResult DeleteEmpleado(int Id)
        {
            var dbSetPuestos = _db.Puestos;
            var lPuestos = (from d in dbSetPuestos
                            where d.IdPuesto == Id
                            select d).ToList();

            Puesto oPuesto;

            if (lPuestos.Count > 0)
            {
                oPuesto = lPuestos[0];

                oPuesto.Estado = "C";
                _db.Entry(oPuesto).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "RH", action = "Empleados" });
        }
    }
}