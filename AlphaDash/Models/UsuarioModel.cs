using System;
using System.Data.SqlClient;

namespace AlphaDash.Models
{
    public class UsuarioModel
    {

        public static bool ValidarUsuario(string usuario, string senha)
        {
            var ret = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=LAPTOP-RVT4934F\\MSSQLSERVER01;Initial Catalog=bancoalpha;";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from usuario where usuario='{0}' and senha='{1}", usuario, senha);
                    ret=((int)comando.ExecuteScalar() > 0);               
                }
            }

            return ret;
        }

    }
}
