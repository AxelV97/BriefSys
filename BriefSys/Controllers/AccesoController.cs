using BriefSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos;

namespace BriefSys.Controllers
{
    public class AccesoController : Controller
    {
        private AccesoContext db = new AccesoContext();
        private CSD_MetodosGenericos oGenerico = new CSD_MetodosGenericos();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Registrar(string user, string pwd)
        {
            var dbSetUsuarios = db.acceso_Usuarios;

            var usuarioExistente = from a in dbSetUsuarios
                                   where a.UsuarioID == user
                                   select a;

            var lExistente = usuarioExistente.ToList();

            int ID = 0;

            if (lExistente.Count > 0)
            {
                return RedirectToRoute(new { controller = "Acceso", action = "Login" });
            }
            if (dbSetUsuarios.ToList().Count > 0)
            {
                ID = dbSetUsuarios.Select(u => u.Id).First();
                ID++;
            }
            else
            {

            }


            Acceso_Usuario oUsuario = new Acceso_Usuario();
            oUsuario.Id = ID;
            oUsuario.UsuarioID = user;
            oUsuario.Salt = oGenerico.GetGeneratedSalt();
            oUsuario.Password = oGenerico.GetHashedText(pwd + oUsuario.Salt);
            oUsuario.ModifiedDate = DateTime.Now;

            dbSetUsuarios.Add(oUsuario);
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}