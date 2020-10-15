using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class UserPokemon
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPokemon { get; set; }
        public DateTime FechaCaptura { get; set; }
    }
}
