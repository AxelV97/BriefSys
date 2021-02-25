using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string IdProveedor { get; set; }

        [Display(Name = "Nombre Proveedor")]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        public string Estado { get; set; }
    }
}
