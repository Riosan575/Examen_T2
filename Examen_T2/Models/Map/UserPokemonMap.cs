using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models.Map
{
    public class UserPokemonMap: IEntityTypeConfiguration<UserPokemon>
    {
        public void Configure(EntityTypeBuilder<UserPokemon> builder)
        {
            builder.ToTable("UsuarioPokemon");
            builder.HasKey(o => o.Id);
        }
    }
}
