using AlphaDash.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlphaDash.Controllers
{

    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();

        }


  
        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string senha, string ReturnUrl)
        {

            var entrar = UsuarioModel.ValidarUsuario(usuario, senha);

            if (entrar)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Redirect(ReturnUrl == null ? "/Home" : ReturnUrl);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }










    }
}
