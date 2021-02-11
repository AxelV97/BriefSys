using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.DataAccess;
using DataLayer.Models;

namespace BriefSys.Controllers.Sistema
{
    public class SistemaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SistemaController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ControlAccesos()
        {
            var dbSetAccesos = _db.Acceso_Usuarios;

            List<Acceso_Usuario> lista_usuarios = new List<Acceso_Usuario>();
            lista_usuarios = dbSetAccesos.ToList();

            return View("~/Views/Sistema/ControlAccesos.cshtml", lista_usuarios);
        }
    }
}