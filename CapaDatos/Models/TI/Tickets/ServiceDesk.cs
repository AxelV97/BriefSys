using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class ServiceDesk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTicket { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal HorasSeguimiento { get; set; }
        public string EnTiempo { get; set; }
        public string Tipo { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public int Prioridad { get; set; }
        public decimal Tiempo { get; set; }
        public int ReportadoPor { get; set; }
        public string ReportadoMediante { get; set; }
        public string Nota { get; set; }
        public string IdEstado { get; set; }
        public string Estado { get; set; }
        public DateTime Auditoria { get; set; }
        public int Quien { get; set; }
    }
}