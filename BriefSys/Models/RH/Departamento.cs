using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BriefSys.Models.RH
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDepartamento { get; set; }
        public string Clasificacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}