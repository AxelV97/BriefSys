using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BriefSys.Models.CMP.Ordenes
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrden { get; set; }
        public int IdRequisicion { get; set; }
        public string IdProveedor { get; set; }
        public string Proveedor { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddTHH:mm}")]
        public DateTime FechaElaboracion { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-ddTHH:mm}")]
        public DateTime FechaEntrega { get; set; }

        public string Moneda { get; set; }
        public int IdElaboro { get; set; }
        public string Estado { get; set; }
    }
}