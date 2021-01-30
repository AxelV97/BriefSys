using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class MenuCategory
    {
        public string Category { get; set; }
        public string DisplayName { get; set; }
    }
    public class MenuItem
    {
        public string Category { get; set; }
        public string LinkName { get; set; }
        public string Link { get; set; }
    }
}