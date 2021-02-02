using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Puesto
    {
        [Key]
        public int IdPuesto { get; set; }
        public int IdDepartamento { get; set; }

        [StringLength(5, MinimumLength = 2, ErrorMessage = "Máximo 5 caracteres")]
        public string Clasificacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}