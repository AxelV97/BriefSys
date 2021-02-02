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

        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/CMP/Index.cshtml");
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

            return View("~/Views/CMP/Index.cshtml", lordenes);
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
                Orden_Detalle = new Orden_Detalle(),
                ListaOrden_Detalle = new List<Orden_Detalle>()
            };
            return View("~/Views/CMP/Create.cshtml", ordenVM);
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

            return View("~/Views/CMP/Edit.cshtml", oOrdenVM);
        }

        [HttpPost]
        public ActionResult EditOrden(OrdenVM oOrdenVM)
        {
            if (ModelState.IsValid)
            {
                Orden oOrden = oOrdenVM.Orden;
                Orden oOrdenDetalle = oOrdenVM.Orden;

                _db.Entry(oOrden).State = EntityState.Modified;
                _db.Entry(oOrdenDetalle).State = EntityState.Modified;
                _db.SaveChanges();
            }
            else
            {
                return View("~/Views/CMP/Edit.cshtml", oOrdenVM);
            }

            return RedirectToRoute(new { controller = "CMP", action = "Ordenes" });
        }

        public ActionResult DeleteOrden(int Id)
        {
            var dbSetOrden = _db.Ordenes;
            var lOrdenes = (from o in dbSetOrden
                            where o.IdOrden == Id
                            select o).ToList();

            Orden oOrden;

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
    }
}