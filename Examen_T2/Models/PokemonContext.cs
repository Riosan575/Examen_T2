using Examen_T2.Models.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class PokemonContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<UserPokemon> userpokemons { get; set; }
        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Esto se hace por cada tabla de base de datos
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PokemonMap());
            modelBuilder.ApplyConfiguration(new TipoMap());
            modelBuilder.ApplyConfiguration(new UserPokemonMap());
        }
    }
}
