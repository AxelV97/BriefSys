using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Acceso_Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEmp { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Ingresa un usuario")]
        public string UsuarioId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ingresa un password")]
        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}