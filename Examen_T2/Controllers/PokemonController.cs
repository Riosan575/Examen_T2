using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Examen_T2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Examen_T2.Controllers
{
    public class PokemonController : BaseController
    {
        private readonly PokemonContext context;
        public IHostEnvironment _hostEnv;

        public PokemonController(PokemonContext context, IHostEnvironment hostEnv) :base(context)
        {
            this.context = context;
            _hostEnv = hostEnv;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var accounts = context.pokemons
                .Where(o => o.UserId == LoggedUser().Id)
                .Include(o => o.Tipo)
                .ToList();
            return View(accounts);
        }
       [HttpGet]
       public IActionResult Create()
        {
            ViewBag.Types = context.Tipos.ToList();
            return View("Create", new Pokemon());
        }
        [HttpPost]
        public IActionResult Create(Pokemon pokemon, IFormFile image, string nombre)
        {
            var nombres = context.pokemons.ToList();
            foreach (var item in nombres)
            {
                if (item.Nombre == nombre)
                    ModelState.AddModelError("Nombre", "El nombre ya existe, ingrese otro nombre");
            }
            pokemon.UserId = LoggedUser().Id;
            if (image != null && image.Length > 0)
            {
                var basePath = _hostEnv.ContentRootPath + @"\wwwroot";
                var ruta = @"\files\" + image.FileName;

                using (var strem = new FileStream(basePath + ruta, FileMode.Create))
                {
                    image.CopyTo(strem);
                    pokemon.ImagePath = ruta;
                }
            }
            else
            {
                ModelState.AddModelError("ImagePath", "Campo imagen es obligatorio");
            }
            if (ModelState.IsValid)
            {
                context.pokemons.Add(pokemon);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Types = context.Tipos.ToList();
            return View("Create", pokemon);
        }
    }
}
