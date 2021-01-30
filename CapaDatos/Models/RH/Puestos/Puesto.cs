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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPuesto { get; set; }
        public int IdDepartamento { get; set; }
        public string Clasificacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

    }
}