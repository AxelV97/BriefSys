using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class ServiceDesk_Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTicket { get; set; }
        public string Nota { get; set; }
        public DateTime FechaNota { get; set; }
        public string IdEstadoNota { get; set; }
        public string EstadoNota { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Auditoria { get; set; }
    }
}