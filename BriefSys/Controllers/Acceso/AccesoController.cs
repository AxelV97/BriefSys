using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using DataLayer.DataAccess;
using DataLayer.Models;
using DataLayer.BusinessLogic;

namespace BriefSys.Controllers.Acceso
{
    public class AccesoController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        private CSD_MetodosGenericos oGenerico = new CSD_MetodosGenericos();

        public ActionResult Register()
        {
            Acceso_UsuarioVM accesoVM = new Acceso_UsuarioVM()
            {
                Acceso_Usuario = new Acceso_Usuario(),
                ListaEmpleados = listaEmpleados()
            };

            return View(accesoVM);
        }

        public IEnumerable<SelectListItem> listaEmpleados()
        {
            return _db.EmpleadosDetalle.Select(i => new SelectListItem()
            {
                Text = i.Nombre + " " + i.ApellidoP + " " + i.ApellidoM,
                Value = i.IdEmp.ToString()
            });
        }

        [HttpPost]
        public ActionResult Register(Acceso_UsuarioVM oUsuarioVM)
        {
            Acceso_Usuario oUser = oUsuarioVM.Acceso_Usuario;

            var dbSetUsuarios = _db.Acceso_Usuarios;

            var usuarioExistente = from a in dbSetUsuarios
                                   where a.UsuarioId == oUser.UsuarioId
                                   select a;

            byte[] imagenBytes = ReadFile(oUsuarioVM.File);

            var lExistente = usuarioExistente.ToList();

            if (lExistente.Count > 0)
            {
                return RedirectToRoute(new { controller = "Acceso", action = "Login" });
            }

            Acceso_Usuario oUsuario = new Acceso_Usuario();
            oUsuario.IdEmp = oUser.IdEmp;
            oUsuario.UsuarioId = oUser.UsuarioId;
            oUsuario.Salt = oGenerico.GetGeneratedSalt();
            oUsuario.Password = oGenerico.GetHashedText(oUser.Password + oUsuario.Salt);
            oUsuario.FechaModificacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                var dbSetEmpleados = _db.EmpleadosDetalle;

                var empleadoExistente = from emp in _db.EmpleadosDetalle
                                        where emp.IdEmp == oUser.IdEmp
                                        select emp;

                Empleado_Detalle oEmpleado = empleadoExistente.ToList()[0];

                oEmpleado.FotografiaDigital = imagenBytes;

                dbSetUsuarios.Add(oUsuario);
                _db.Entry(oEmpleado).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View("Register", oUser);
        }
        public ActionResult Login()
        {
            return View(new Acceso_Usuario());
        }

        public static byte[] ReadFile(HttpPostedFileBase image)
        {
            byte[] binaryImage;
            using (Stream inputStream = image.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                binaryImage = memoryStream.ToArray();
            }
            return binaryImage;
        }

        [HttpPost]
        public ActionResult Login(Acceso_Usuario oUsuario)
        {
            var dbSetUsuarios = _db.Acceso_Usuarios;
            var dbSetEmpleados = _db.EmpleadosDetalle;

            var usuarioExistente = from a in dbSetUsuarios
                                   where a.UsuarioId == oUsuario.UsuarioId
                                   select a;

            var lUsuarioExistente = usuarioExistente.ToList();

            /*Se encontró usuario*/
            if (lUsuarioExistente.Count > 0)
            {
                oUsuario.Password = oGenerico.GetHashedText(oUsuario.Password + lUsuarioExistente[0].Salt);

                /*Contraseñas coinciden*/
                if (oUsuario.Password == lUsuarioExistente[0].Password)
                {
                    oUsuario.IdEmp = lUsuarioExistente[0].IdEmp;
                    var empleadoExistente = from a in dbSetEmpleados
                                            where a.IdEmp == oUsuario.IdEmp
                                            select a;

                    Empleado_Detalle oEmpleado = empleadoExistente.ToList()[0];

                    Session["IdEmp"] = oEmpleado.IdEmp;
                    Session["NombreEmpleado"] = oEmpleado.Nombre + " " + oEmpleado.ApellidoP + " " + oEmpleado.ApellidoM;
                    return RedirectToRoute(new { Controller = "Home", Action = "Index" });
                }
                /*No coinciden*/
                else
                {
                    /*Se ingreso user y pwd*/
                    if (ModelState.IsValid)
                    {
                        return RedirectToRoute(new { Controller = "Acceso", Action = "Login" });
                    }
                    /*No se ingreso user o pwd*/
                    else
                    {
                        return View(oUsuario);
                    }
                }
            }
            /*No se encontro user*/
            else
            {
                /*Se ingreso user y pwd*/
                if (ModelState.IsValid)
                {
                    return RedirectToRoute(new { Controller = "Acceso", Action = "Login" });
                }
                /*No se ingreso user o pwd*/
                else
                {
                    return View(oUsuario);
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
    }
}