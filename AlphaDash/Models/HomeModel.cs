using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AlphaDash.Models
{
    public class HomeModel
    {

        public int Id { get; set; }
        public string Horario { get; set; }
        public int Cliente { get; set; }
        public int Status { get; set; }

        public static List<HomeModel> RecuperarLista()
        {
            var ret = new List<HomeModel>();
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=LAPTOP-RVT4934F\\MSSQLSERVER01;Initial Catalog=bancoalpha;Integrated Security=SSPI;";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from agenda order by Id";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new HomeModel
                        {
                            Id=(int)reader["id"],
                            Horario=(string)reader["horario"],
                            Cliente=(int)reader["idcliente"],
                            Status=(int)reader["status"]

                        });
                    }
                }
            }

            return ret;
        }



        // de acordo com o nome do botão alterar o numero do status para 1 ou 2
        // posso fazer if?
        //if nomedobotao="Checkin" { update coluna status para 1 } else if nomedobotao="Checkout {update coluna status para 2, e desativa clique do botão}
    //public int Salvar()
    //    {
    //        var ret = 0;

    //        var model RecuperarPeloId(this.Id);

    //        using (var conexao = new SqlConnection())
    //        {
    //            conexao.ConnectionString = "Data Source=LAPTOP-RVT4934F\\MSSQLSERVER01;Initial Catalog=bancoalpha;Integrated Security=SSPI;";
    //            conexao.Open();

    //            using (var comando = new SqlCommand())
    //            {
    //                comando.Connection = conexao;

    //                if (model != null)
    //                {
    //                    comando.CommandText = string.Format(
    //                        "update agenda set status={1} where id={0}",
    //                        this.Id, this.Status);
    //        }
    //            }
    //            return ret;
    //        }
           
    //    }
    
}

}