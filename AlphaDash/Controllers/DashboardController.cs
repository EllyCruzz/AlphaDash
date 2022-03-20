using AlphaDash.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        //public static IActionResult AtualizaStatuss(HomeModel model)
        //{
        //    var ret = new List<HomeModel>();
        //    using (var conexao = new SqlConnection())
        //    {
        //        conexao.ConnectionString = "Data Source=LAPTOP-RVT4934F\\MSSQLSERVER01;Initial Catalog=bancoalpha;Integrated Security=SSPI;";
        //        conexao.Open();
        //        using (var comando = new SqlCommand())
        //        {
        //            comando.Connection = conexao;
        //            comando.CommandText = "update agenda set status ='1' where id = '1'";
        //            var reader = comando.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ret.Add(new HomeModel
        //                {
        //                    Id = (int)reader["id"],
        //                    Status = (int)reader["status"]

        //                });
        //            }
        //        }

        //    }

        //    return Json(true);
        //}

        //public IActionResult AtualizaStatusC(HomeModel model)
        //{

        //    var resultado = "OK";
        //    var mensagens = new List<string>();
        //    var idSalvo = string.Empty;


        //    var id = model.AtualizaStatus();
        //    if (id > 0)
        //    {
        //        idSalvo = id.ToString();
        //    }
        //    else
        //    {
        //        resultado = "ERRO";
        //    }

        //    return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
    }
}
