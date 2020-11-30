using BriefSys.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BriefSys.Controllers.Home
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SideMenu()
        {
            List<MenuCategory> categorias = new List<MenuCategory>();
            categorias.Add(new MenuCategory { Category = "Home" });
            categorias.Add(new MenuCategory { Category = "RH" });

            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem { Category = "Home", Link = "/Home/Index", LinkName = "Home" });
            items.Add(new MenuItem { Category = "Home", Link = "/Home/About", LinkName = "About" });
            items.Add(new MenuItem { Category = "Home", Link = "/Home/Contact", LinkName = "Contact" });

            items.Add(new MenuItem { Category = "RH", Link = "/RH/Departamentos", LinkName = "Departamentos" });
            items.Add(new MenuItem { Category = "RH", Link = "/RH/Puestos", LinkName = "Puestos" });
            items.Add(new MenuItem { Category = "RH", Link = "/RH/Empleados", LinkName = "Empleados" });

            MenuVM menuVM = new MenuVM();
            menuVM.Categories = categorias;
            menuVM.Items = items;

            return PartialView("SideMenu", menuVM);
        }
    }
}