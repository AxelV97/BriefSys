using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BriefSys.Models.Acceso
{
    public class Acceso_Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Ingresa un usuario")]
        public string UsuarioID { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ingresa un password")]
        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}