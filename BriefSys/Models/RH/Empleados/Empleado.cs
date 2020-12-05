using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BriefSys.Models.RH.Empleados
{
    public class Empleado
    {
        public int IdDepartamento { get; set; }
        public int IdPuesto { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmp { get; set; }
        public DateTime Ingreso { get; set; }
    }
}