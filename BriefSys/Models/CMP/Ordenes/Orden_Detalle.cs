using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BriefSys.Models.CMP.Ordenes
{
    public class Orden_Detalle
    {

        public int IdOrden { get; set; }
        public int CodigoPartida { get; set; }
        public int Partida { get; set; }
        public int PartidaRequisicion { get; set; }
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadInterna { get; set; }
        public string UnidadExterna { get; set; }
        public bool Atendido { get; set; }
        public string Estado { get; set; }
    }
}