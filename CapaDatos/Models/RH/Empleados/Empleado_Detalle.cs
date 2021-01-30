using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BriefSys.Models.RH.Empleados
{
    public class Empleado_Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmp { get; set; }

        [Display(Name = "Nombre(s)")]
        [Required(ErrorMessage = "Ingresa Nombre(s)")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Ingresa Apellido Paterno")]
        public string ApellidoP { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "Ingresa Apellido Materno")]
        public string ApellidoM { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Ingresa Fecha de Nacimiento")]
        public DateTime FechaNac { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Ingresa Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Extensión")]
        public string Extension { get; set; }

        public byte[] FotografiaDigital { get; set; }

        public string Estado { get; set; }
    }
}