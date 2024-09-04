using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtividadeAvaliativaPOO.Models;
using MySql.Data.MySqlClient;

namespace AtividadeAvaliativaPOO.Dao
{
    internal class VendaDAO
    {
        public void Insert(Venda venda)
        {
            try
            {
                string dtVenda = venda.data.ToString("yyyy-MM-dd");
                string hrVenda = venda.hora.ToString("HH:mm:ss");
                string sql = "INSERT INTO Venda(data_vend, hora_vend, valorTotal_vend, desconto_vend, valorFinal_vend, tipo_vend, fk_cliente) " +
                    "VALUES(@data, @hora, @valorTotal, @desconto, @valorFinal, @tipo, @cliente);";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.Conectar());
                cmd.Parameters.AddWithValue("@data", dtVenda);
                cmd.Parameters.AddWithValue("@hora", hrVenda);
                cmd.Parameters.AddWithValue("@valorTotal", venda.valor);
                cmd.Parameters.AddWithValue("@desconto", venda.desconto);
                cmd.Parameters.AddWithValue("@valorFinal", venda.valorFinal);
                cmd.Parameters.AddWithValue("@tipo", venda.tipo);
                cmd.Parameters.AddWithValue("@cliente", venda.fkCliente);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Venda cadastrada.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar os dados da venda \nErro: {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Update(Venda venda)
        {
            try
            {
                string dtVenda = venda.data.ToString("yyyy-MM-dd");
                string hrVenda = venda.hora.ToString("HH:mm:ss");
                string sql = "UPDATE Venda SET data_vend = @data, hora_vend = @hora, valorTotal_vend = @valorTotal, " +
                             "desconto_vend = @desconto, valorFinal_vend = @valorFinal, tipo_vend = @tipo, fk_cliente = @cliente " +
                             "WHERE id_venda = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.Conectar());
                cmd.Parameters.AddWithValue("@data", dtVenda);
                cmd.Parameters.AddWithValue("@hora", hrVenda);
                cmd.Parameters.AddWithValue("@valorTotal", venda.valor);
                cmd.Parameters.AddWithValue("@desconto", venda.desconto);
                cmd.Parameters.AddWithValue("@valorFinal", venda.valorFinal);
                cmd.Parameters.AddWithValue("@tipo", venda.tipo);
                cmd.Parameters.AddWithValue("@cliente", venda.fkCliente);
                cmd.Parameters.AddWithValue("@id", venda.idVenda);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Venda atualizada.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar os dados da venda \nErro: {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Delete(Venda venda)
        {
            try
            {
                string sql = "DELETE FROM Venda WHERE id_venda = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.Conectar());
                cmd.Parameters.AddWithValue("@id", venda.idVenda);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Venda excluída.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir os dados da venda \nErro: {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public List<Venda> List()
        {
            List<Venda> vendas = new List<Venda>();
            try
            {
                var sql = "SELECT * FROM Venda;";
                MySqlCommand cmd = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Venda venda = new Venda();
                        venda.idVenda = reader.GetInt32("id_venda");
                        venda.data = DateOnly.FromDateTime(reader.GetDateTime("data_vend"));
                        venda.hora = TimeOnly.FromTimeSpan(reader.GetTimeSpan("hora_vend"));
                        venda.valor = reader.GetDouble("valorTotal_vend");
                        venda.desconto = reader.GetDouble("desconto_vend");
                        venda.valorFinal = reader.GetDouble("valorFinal_vend");
                        venda.tipo = reader.GetString("tipo_vend");
                        venda.fkCliente = reader.GetInt32("fk_cliente");

                        vendas.Add(venda);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar os dados das vendas \nErro: {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return vendas;
        }
    }
}
