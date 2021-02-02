using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepartamento { get; set; }

        [Display(Name = "Clasificación")]
        [Required(ErrorMessage = "Ingresa una clasificación")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Máximo 5 caracteres")]
        public string Clasificacion { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingresa una descripción")]
        public string Descripcion { get; set; }


        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}