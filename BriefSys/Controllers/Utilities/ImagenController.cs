using BriefSys.Models.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Controllers.Utilities
{
    public class ImagenController : Controller
    {
        private RHContext db = new RHContext();
        // GET: Imagen
        public ActionResult Show(int IdEmp)
        {
            var dbSetEmpleados = db.EmpleadosDetalle;

            var empleadoExistente = from emp in dbSetEmpleados
                                    where emp.IdEmp == IdEmp
                                    select emp;

            var imageData = empleadoExistente.ToList()[0].FotografiaDigital;
            return File(imageData, "image/jpg");
        }
    }
}