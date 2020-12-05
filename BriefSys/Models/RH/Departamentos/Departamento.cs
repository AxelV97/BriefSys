using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BriefSys.Models.RH.Departamentos
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDepartamento { get; set; }

        [Display(Name = "Clasificación")]
        [Required(ErrorMessage = "Ingresa una clasificación")]
        public string Clasificacion { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingresa una descripción")]
        public string Descripcion { get; set; }

        public string Estado { get; set; }
    }
}