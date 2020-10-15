using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerdio")]
        public string Nombre {get;set;}
        [Required(ErrorMessage = "El campo tipo es requerido")]
        public int TipoId { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }

        //relacion
        public Tipo Tipo { get; set; }
    }
}
