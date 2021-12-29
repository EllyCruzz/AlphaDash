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

    
}

}