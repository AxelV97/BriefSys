using BriefSys.Models.CMP.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Controllers.CMP
{
    public class CMPController : Controller
    {

        public CMPContext _db =  new CMPContext();

        [HttpGet]
        public ActionResult Ordenes()
        {
            return View("~/Views/CMP/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetOrdenes()
        {
            var dbSetOrdenes = _db.Ordenes;
            var ordenes = from dp in dbSetOrdenes
                          where dp.Estado != "C"
                          select dp;

            return Json(new { data = ordenes }, JsonRequestBehavior.AllowGet);
        }
    }
}