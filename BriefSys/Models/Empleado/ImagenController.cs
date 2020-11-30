using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Models.Empleado
{
    public class ImagenController : Controller
    {
        private EmpleadoContext db = new EmpleadoContext();
        // GET: Imagen
        public ActionResult Show(int IdEmp)
        {
            var dbSetEmpleados = db.empleados;

            var empleadoExistente = from emp in dbSetEmpleados
                                    where emp.IdEmp == IdEmp
                                    select emp;
            var imageData = empleadoExistente.ToList()[0].FotografiaDigital;
            return File(imageData, "image/jpg");
        }
    }
}