using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.DataAccess;
using DataLayer.Models;

namespace BriefSys.Controllers.Utilities
{
    public class ImagenController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ImagenController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: Imagen
        public ActionResult Show(int IdEmp)
        {
            var dbSetEmpleados = _db.EmpleadosDetalle;

            var empleadoExistente = from emp in dbSetEmpleados
                                    where emp.IdEmp == IdEmp
                                    select emp;

            var imageData = empleadoExistente.ToList()[0].FotografiaDigital;
            return File(imageData, "image/jpg");
        }
    }
}