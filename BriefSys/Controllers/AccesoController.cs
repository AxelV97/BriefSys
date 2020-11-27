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
            return View(new Acceso_Usuario());
        }

        [HttpPost]
        public ActionResult Login(Acceso_Usuario oUsuario)
        {
            var dbSetUsuarios = db.acceso_Usuarios;

            var usuarioExistente = from a in dbSetUsuarios
                                   where a.UsuarioID == oUsuario.UsuarioID
                                   select a;

            var lUsuarioExistente = usuarioExistente.ToList();

            /*Se encontró usuario*/
            if (lUsuarioExistente.Count > 0)
            {
                oUsuario.Password = oGenerico.GetHashedText(oUsuario.Password + lUsuarioExistente[0].Salt);

                if (oUsuario.Password == lUsuarioExistente[0].Password)
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    return RedirectToRoute(new { controller = "Acceso", action = "Login" });
                }
            }
            else
            {
                return RedirectToRoute(new { controller = "Acceso", action = "Login" });
            }
        }

        public ActionResult Register()
        {
            return View(new Acceso_Usuario());
        }

        [HttpPost]
        public ActionResult Register(Acceso_Usuario oUser)
        {
            var dbSetUsuarios = db.acceso_Usuarios;

            var usuarioExistente = from a in dbSetUsuarios
                                   where a.UsuarioID == oUser.UsuarioID
                                   select a;

            var lExistente = usuarioExistente.ToList();

            int ID = 1;

            if (lExistente.Count > 0)
            {
                return RedirectToRoute(new { controller = "Acceso", action = "Login" });
            }

            if (dbSetUsuarios.ToList().Count > 0)
            {
                ID = dbSetUsuarios.Select(u => u.Id).First();
                ID++;
            }

            Acceso_Usuario oUsuario = new Acceso_Usuario();
            oUsuario.Id = ID;
            oUsuario.UsuarioID = oUser.UsuarioID;
            oUsuario.Salt = oGenerico.GetGeneratedSalt();
            oUsuario.Password = oGenerico.GetHashedText(oUser.Password + oUsuario.Salt);
            oUsuario.ModifiedDate = DateTime.Now;

            dbSetUsuarios.Add(oUsuario);
            db.SaveChanges();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}