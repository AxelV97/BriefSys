using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class MenuVM
    {
        public List<MenuCategory> Categories { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}