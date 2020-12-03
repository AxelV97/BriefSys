using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BriefSys.Models.Menu;

namespace BriefSys.Controllers.Utilities
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SideMenu()
        {
            List<MenuCategory> categorias = new List<MenuCategory>();
            categorias.Add(new MenuCategory { Category = "Home", DisplayName = "Home" });
            categorias.Add(new MenuCategory { Category = "RH", DisplayName = "Recursos Humanos" });
            categorias.Add(new MenuCategory { Category = "CXC", DisplayName = "Cuentas por Cobrar" });
            categorias.Add(new MenuCategory { Category = "CMP", DisplayName = "Compras" });
            categorias.Add(new MenuCategory { Category = "TI", DisplayName = "Tecnología de la Información" });

            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem { Category = "Home", Link = "/Home/Index", LinkName = "Home" });
            items.Add(new MenuItem { Category = "Home", Link = "/Home/About", LinkName = "About" });
            items.Add(new MenuItem { Category = "Home", Link = "/Home/Contact", LinkName = "Contact" });

            items.Add(new MenuItem { Category = "RH", Link = "/RH/Departamentos", LinkName = "Departamentos" });
            items.Add(new MenuItem { Category = "RH", Link = "/RH/Puestos", LinkName = "Puestos" });
            items.Add(new MenuItem { Category = "RH", Link = "/RH/Empleados", LinkName = "Empleados" });

            items.Add(new MenuItem { Category = "CXC", Link = "/CXC/Arqueos", LinkName = "Arqueos" });

            items.Add(new MenuItem { Category = "CMP", Link = "/CMP/OrdenesCompra", LinkName = "Ordenes de Compra" });
            items.Add(new MenuItem { Category = "CMP", Link = "/CMP/CalendarioCompras", LinkName = "Calendario de Compras" });
            items.Add(new MenuItem { Category = "CMP", Link = "/CMP/Proveedores", LinkName = "Proveedores" });

            items.Add(new MenuItem { Category = "TI", Link = "/TI/ServiceDesk", LinkName = "Service Desk" });
            items.Add(new MenuItem { Category = "TI", Link = "/TI/AdministrarCuentas", LinkName = "Adninistración de Cuentas" });

            MenuVM menuVM = new MenuVM();
            menuVM.Categories = categorias;
            menuVM.Items = items;

            return PartialView("SideMenu", menuVM);
        }
    }
}