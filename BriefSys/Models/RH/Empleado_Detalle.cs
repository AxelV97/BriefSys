using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BriefSys.Models.RH
{
    public class Empleado_Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmp { get; set; }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public DateTime FechaNac { get; set; }

        public string Telefono { get; set; }

        public string Extension { get; set; }

        public byte[] FotografiaDigital { get; set; }

        public char Estado { get; set; }
    }
}