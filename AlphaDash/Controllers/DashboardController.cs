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

    public class DashboardController : Controller
    {
        private static List<HomeModel> _listarCheck = new List<HomeModel>()
        {
         //   new HomeModel() {Id=1, Nome="Empresa1", Endereco="rua 1", Local="mart moda" }
        };

        [Authorize]
        public IActionResult Index()
        {
            return View(DashboardModel.RecuperarLista());

        }

    }
}
