using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AlphaDash.Models
{
    public class DashboardModel
    {

        public int Id { get; set; }
        public string Horario { get; set; }
        public string Cliente { get; set; }
        public string Suporte { get; set; }
        public string Local { get; set; }
        public int Status { get; set; }

        public static List<DashboardModel> RecuperarLista()
        {
            var ret = new List<DashboardModel>();
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=LAPTOP-RVT4934F\\MSSQLSERVER01;Initial Catalog=bancoalpha;Integrated Security=SSPI;";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    var date = DateTime.Today; //DateTime.Today;
                    comando.CommandText = "SELECT A.Horario, C.Nome, S.Nome, L.Nome, A.Status, A.Status" +
                " FROM Agenda AS A " +
                " INNER JOIN Cliente AS C ON A.IdCliente = C.Id" +
                " INNER JOIN Suporte AS S ON A.IdSuporte = S.Id" +
                " INNER JOIN LocalCliente AS L ON A.IdLocal = L.Id" +
                " WHERE A.Data >='" + date + "'" + " AND A.Data < '" + DateTime.Today.AddDays(1) + "'";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new DashboardModel
                        {

                            Horario = (string)reader["horario"],
                            Cliente = (string)reader["Nome"],
                            Suporte = (string)reader["Nome"],
                            Local = (string)reader["Nome"],
                            Status = (int)reader["status"]

                        });
                    }
                }

            }
            return ret;
        }
                
            }
 
        }
    


