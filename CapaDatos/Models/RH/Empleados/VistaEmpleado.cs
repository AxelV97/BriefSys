using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class VistaEmpleado
    {
        public int IdEmp { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public DateTime Ingreso { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public DateTime FechaNac { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public string Estado { get; set; }
    }
}
