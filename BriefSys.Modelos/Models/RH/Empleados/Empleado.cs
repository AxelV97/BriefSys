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
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Selecciona un departamento")]
        public int IdDepartamento { get; set; }

        [Display(Name = "Puesto")]
        [Required(ErrorMessage = "Selecciona un puesto")]
        public int IdPuesto { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmp { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de Ingreso")]
        [Required(ErrorMessage = "Selecciona fecha de ingreso")]
        public DateTime Ingreso { get; set; }
    }
}