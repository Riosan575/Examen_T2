using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo usuario es requerido")]
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
