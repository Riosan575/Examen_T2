using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_T2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Examen_T2.Controllers
{
    public class AtraparController : Controller
    {
        private readonly PokemonContext context;
        private readonly IConfiguration configuration;

        public AtraparController(PokemonContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.pokemons = context.pokemons.ToList();
            ViewBag.users = context.Users.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Atrapar()
        {
            ViewBag.pokemons = context.pokemons.ToList();
            ViewBag.users = context.Users.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Atrapar(UserPokemon userpokemons)
        {
            if (!ModelState.IsValid)
                return View(userpokemons);

            context.userpokemons.Update(userpokemons);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pokemon = context.pokemons.Where(o => o.Id == id).FirstOrDefault();
            context.pokemons.Remove(pokemon);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
