// MovimentacaoDAO.cs
using System;
using MySqlConnector;
using SistemaEstoque.DAO;
using SistemaEstoque.Utils;
namespace SistemaEstoque.DAO
{
    public class MovimentacaoDAO
    {
        public void RegistrarSaida(int idProduto, int quantidade, decimal preco)
        {
            try // NOVO: Bloco try externo
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    var tx = conn.BeginTransaction();
                    try
                    {
                        // 1. Atualiza o estoque do produto
                        // 2. Insere o registro na tabela de movimentação
                        // 3. tx.Commit();
                    }
                    catch (Exception ex) // Bloco catch interno para rollback
                    {
                        tx.Rollback();
                        throw; // Propaga para o catch externo
                    }
                }
            }
            catch (Exception ex) // NOVO: Bloco catch externo para logar
            {
                Logger.LogError($"Falha ao registrar saída para o produto ID: {idProduto}, Qtd: {quantidade}.", ex);
                throw;
            }
        }
    }
}