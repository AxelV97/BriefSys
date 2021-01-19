using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BriefSys.Models.TI.Tickets
{
    public class ServiceDesk_Detalle
    {
        public int IdTicket { get; set; }
        public string Nota { get; set; }
        public DateTime FechaNota { get; set; }
        public string IdEstadoNota { get; set; }
        public string EstadoNota { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Auditoria { get; set; }
    }
}