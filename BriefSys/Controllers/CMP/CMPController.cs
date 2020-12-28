using BriefSys.Models.CMP.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Controllers.CMP
{
    public class CMPController : Controller
    {

        public CMPContext _db = new CMPContext();

        [HttpGet]
        public ActionResult Ordenes()
        {
            return View("~/Views/CMP/Index.cshtml");
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
    }
}