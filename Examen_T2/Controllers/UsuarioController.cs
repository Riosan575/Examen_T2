using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Examen_T2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Examen_T2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly PokemonContext context;
        private readonly IConfiguration configuration;

        public UsuarioController(PokemonContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user, string usuario)
        {
            var usuarios = context.Users.ToList();
            foreach (var item in usuarios)
            {
                if (item.Usuario == usuario)
                    ModelState.AddModelError("Usuario", "El usuario ya existe, ingrese otro usuario");
            }

            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Create", user);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string usuario, string contraseña)
        {
            var user = context.Users.Where(o => o.Usuario == usuario && o.Contraseña == contraseña)
                .FirstOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Login", "Usuario o contraseña incorrectos.");
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
