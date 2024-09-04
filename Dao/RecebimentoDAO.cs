using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtividadeAvaliativaPOO.Models;
using MySql.Data.MySqlClient;

namespace AtividadeAvaliativaPOO.Dao
{
    internal class RecebimentoDAO
    {
        public void Insert(Recebimento recebimento)
        {
            try
            {
                string sql = "INSERT INTO Recebimento(valor_rec, vencimento_rec, pagamento_rec, status_rec, fk_caixa, fk_venda) " +
                             "VALUES(@valor, @vencimento, @pagamento, @status, @caixa, @venda);";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.Conectar());
                cmd.Parameters.AddWithValue("@valor", recebimento.valor);
                cmd.Parameters.AddWithValue("@vencimento", recebimento.vencimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@pagamento", recebimento.pagamento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@status", recebimento.status);
                cmd.Parameters.AddWithValue("@caixa", recebimento.fkCaixa);
                cmd.Parameters.AddWithValue("@venda", recebimento.fkVenda);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Recebimento cadastrado.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar os dados do recebimento \nErro: {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }
    }
}
