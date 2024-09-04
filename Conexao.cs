using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AtividadeAvaliativaPOO
{
    public static class Conexao
    {
        static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                string strConexao = "server=localhost;uid=root;database=aula_23_07;port=3306";
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                Console.WriteLine("Conexão realizada");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na conexão com o servidor: " + ex.Message);
            }
            return conexao;
        }

        public static void FecharConexao()
        {
            conexao.Close();
        }
    }
}
