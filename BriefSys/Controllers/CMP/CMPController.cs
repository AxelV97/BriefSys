using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.DataAccess;
using DataLayer.Models;

namespace BriefSys.Controllers.CMP
{
    public class CMPController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CMPController()
        {
            _db = new ApplicationDbContext();
        }

        /*Compras*/

        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/CMP/Compras/Index.cshtml");
        }

        [HttpGet]
        public ActionResult Ordenes()
        {
            var dbSetOrdenes = _db.Ordenes;
            var dbSetOrdenes_Detalle = _db.Ordenes_Detalle;

            var ordenes = from o in dbSetOrdenes
                              //join od in dbSetOrdenes_Detalle on o.IdOrden equals od.IdOrden
                          where o.Estado != "C"
                          select o;

            List<Orden> lordenes = new List<Orden>();
            lordenes = ordenes.ToList();

            return View("~/Views/CMP/Compras/Index.cshtml", lordenes);
        }

        [HttpGet]
        public ActionResult GetOrdenes()
        {
            var dbSetOrdenes = _db.Ordenes;
            var ordenes = from o in dbSetOrdenes
                          where o.Estado != "C"
                          select o;

            string json = JsonConvert.SerializeObject(new { data = ordenes }, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" });
            return Content(json, "application/json");
        }

        [HttpGet]
        public ActionResult CreateOrden()
        {
            OrdenVM ordenVM = new OrdenVM()
            {
                Orden = new Orden(),
                ListaOrden_Detalle = new List<Orden_Detalle>()
            };
            return View("~/Views/CMP/Compras/Create.cshtml", ordenVM);
        }

        [HttpPost]
        public ActionResult CreateOrden(Orden orden, List<Orden_Detalle> orden_detalle)
        {
            string result = "";
            var dbSetOrden = _db.Ordenes;
            var dbSetOrdenDetalle = _db.Ordenes_Detalle;

            Orden ord = orden;
            ord.Estado = "N";

            if (!(Session["IdEmp"] == null))
            {
                ord.IdElaboro = int.Parse(Session["IdEmp"].ToString());
            }
            else
            {
                ord.IdElaboro = 0;
            }

            if (ModelState.IsValid)
            {
                dbSetOrden.Add(ord);
                _db.SaveChanges();

                foreach (var itemorden in orden_detalle)
                {
                    itemorden.IdOrden = ord.IdOrden;
                    itemorden.Estado = "N";
                    dbSetOrdenDetalle.Add(itemorden);
                }

                _db.SaveChanges();

                result = "Success! Order Is Complete!";

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            result = "Ocurrió un error al procesar la solicitud";

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditOrden(int Id)
        {
            var dbSetOrden = _db.Ordenes;
            var lOrdenes = (from o in dbSetOrden
                            where o.IdOrden == Id
                            select o).ToList();
            Orden oOrden;

            var dbSetOrdenDetalle = _db.Ordenes_Detalle;
            List<Orden_Detalle> lordendetalle = (from od in dbSetOrdenDetalle
                                                 where od.IdOrden == Id
                                                 select od).ToList();

            OrdenVM oOrdenVM = new OrdenVM();

            if (lOrdenes.Count > 0)
            {
                oOrden = lOrdenes[0];
            }
            else
            {
                return HttpNotFound();
            }

            if (lordendetalle.Count > 0)
            {

            }
            else
            {
                return HttpNotFound();
            }

            oOrdenVM.Orden = oOrden;
            oOrdenVM.ListaOrden_Detalle = lordendetalle;

            return View("~/Views/CMP/Compras/Edit.cshtml", oOrdenVM);
        }

        [HttpPost]
        public ActionResult EditOrden(Orden orden, List<Orden_Detalle> orden_detalle)
        {
            if (ModelState.IsValid)
            {
                Orden oOrden = orden;

                List<Orden_Detalle> lDetalle = orden_detalle;
                _db.Entry(oOrden).State = EntityState.Modified;

                if (lDetalle.Count > 0)
                {
                    foreach (Orden_Detalle orden_Detalle in lDetalle)
                    {
                        _db.Entry(orden_Detalle).State = EntityState.Modified;
                    }
                }

                _db.SaveChanges();
            }
            else
            {
                OrdenVM ordenVM = new OrdenVM { Orden = orden, ListaOrden_Detalle = orden_detalle };

                return View("~/Views/CMP/Compras/Edit.cshtml", ordenVM);
            }

            return RedirectToRoute(new { controller = "CMP", action = "Ordenes" });
        }

        public ActionResult DeleteOrden(int id)
        {
            var dbSetOrden = _db.Ordenes;
            var lOrdenes = (from o in dbSetOrden
                            where o.IdOrden == id
                            select o).ToList();

            Orden oOrden = null;

            if (lOrdenes.Count > 0)
            {
                oOrden = lOrdenes[0];

                oOrden.Estado = "C";
                _db.Entry(oOrden).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "CMP", action = "Ordenes" });
        }

        public IEnumerable<SelectListItem> listaOrdenes()
        {
            return _db.Ordenes.Select(d => new SelectListItem()
            {
                Text = d.IdOrden.ToString(),
                Value = d.IdOrden.ToString()
            });
        }

        /*Proveedores*/

        [HttpGet]
        public ActionResult Proveedores()
        {
            var dbSetProveedores = _db.Proveedores;
            var lProveedores = (from p in dbSetProveedores
                                where p.Estado == "N"
                                select p).ToList();

            return View("~/Views/CMP/Proveedores/Index.cshtml", lProveedores);
        }

        [HttpGet]
        public ActionResult CreateProveedor()
        {
            Proveedor proveedor = new Proveedor();
            return PartialView("~/Views/CMP/Proveedores/Create.cshtml", proveedor);
        }

        [HttpPost]
        public ActionResult CreateProveedor(Proveedor proveedor)
        {
            var proveedores = _db.Proveedores;
            var lProveedores = (from p in proveedores
                                where p.IdProveedor == proveedor.IdProveedor
                                select p).ToList();
            string result = "";
            bool exito = false;

            if (lProveedores.Count > 0)
            {
                exito = false;
                result = "Ya existe un proveedor con ID(" + proveedor.IdProveedor + ") en la base de datos";

                return View("~/Views/CMP/Proveedores/Create.cshtml", proveedor);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    proveedor.Estado = "N";
                    proveedores.Add(proveedor);
                    _db.SaveChanges();

                    return RedirectToRoute(new { controller = "CMP", action = "Proveedores" });
                }
                else
                {
                    exito = false;
                    result = "El modelo no es válido, revisa bien los datos";

                    return View("~/Views/CMP/Proveedores/Create.cshtml", proveedor);
                }
            }
        }

        [HttpGet]
        public ActionResult EditProveedor(string id)
        {
            var dbSetProveedores = _db.Proveedores;
            var proveedor = (from p in dbSetProveedores
                             where p.IdProveedor == id
                             select p).First();

            if (proveedor == null)
            {
                return HttpNotFound();
            }

            return PartialView("~/Views/CMP/Proveedores/Edit.cshtml", proveedor);
        }

        [HttpPost]
        public ActionResult EditProveedor(Proveedor proveedor)
        {
            var dbSetProveedores = _db.Proveedores;

            if (ModelState.IsValid)
            {
                proveedor.Estado = "N";
                _db.Entry(proveedor).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToRoute(new { controller = "CMP", action = "Proveedores" });
            }
            else
            {
                return View("~/Views/CMP/Proveedores/Index.cshtml", proveedor);
            }

        }

        public ActionResult DeleteProveedor(string id)
        {
            var dbSetProveedores = _db.Proveedores;
            var lProveedor = (from p in dbSetProveedores
                              where p.IdProveedor == id
                              select p).ToList();

            Proveedor proveedor = null;

            if (lProveedor.Count > 0)
            {
                proveedor = lProveedor[0];
                proveedor.Estado = "C";
                _db.Entry(proveedor).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToRoute(new { controller = "CMP", action = "Proveedores" });
        }
    }
}