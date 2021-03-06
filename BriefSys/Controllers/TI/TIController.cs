﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.DataAccess;
using DataLayer.Models;

namespace BriefSys.Controllers.TI
{
    public class TIController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        /*---------------
         * Tickets
         ----------------*/
        [HttpGet]
        public ActionResult Tickets()
        {
            return View("~/Views/TI/ServiceDesk/Index.cshtml");
        }

        [HttpGet]
        public ActionResult GetTickets()
        {
            var dbSetTickets = _db.Tickets;
            var tickets = from sd in dbSetTickets
                          where sd.Estado != "C"
                          select sd;

            return Json(new { data = tickets }, JsonRequestBehavior.AllowGet);
        }
    }
}