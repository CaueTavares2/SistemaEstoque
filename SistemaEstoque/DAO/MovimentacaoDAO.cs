// MovimentacaoDAO.cs
using System;
using MySqlConnector;
using System.Windows.Forms;
using SistemaEstoque.Classes;
namespace SistemaEstoque.DAO
{
    public class MovimentacaoDAO
    {
        public void RegistrarSaida(int idProduto, int quantidade, decimal preco)
        {
            int idUsuario = UserSession.IdUsuario;

            if (idUsuario == 0)
            {
                MessageBox.Show("Erro de sessão: Nenhum usuário logado. Ação de saída cancelada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var tx = conn.BeginTransaction();
                try
                {
                    // 1. Atualiza o estoque do produto (diminui a quantidade)
                    string sqlEstoque = "UPDATE produto SET quantidade = quantidade - @qtd WHERE idproduto=@id";
                    var cmd1 = new MySqlCommand(sqlEstoque, conn, tx);
                    cmd1.Parameters.AddWithValue("@qtd", quantidade);
                    cmd1.Parameters.AddWithValue("@id", idProduto);
                    cmd1.ExecuteNonQuery();

                    // 2. Insere o registro na tabela de movimentação
                    // CRÍTICO: Inclusão do fk_usuario_idusuario
                    string sqlMov = @"INSERT INTO movimentacao (tipo, quantidade, preco, date, fk_produto_idproduto, fk_usuario_idusuario)
                              VALUES ('Saida', @qtd, @preco, NOW(), @id, @idUsuario)";

                    var cmd2 = new MySqlCommand(sqlMov, conn, tx);
                    cmd2.Parameters.AddWithValue("@qtd", quantidade);
                    cmd2.Parameters.AddWithValue("@preco", preco);
                    cmd2.Parameters.AddWithValue("@id", idProduto);
                    cmd2.Parameters.AddWithValue("@idUsuario", idUsuario); // NOVO PARÂMETRO
                    cmd2.ExecuteNonQuery();

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("Falha ao registrar saída e movimentação.", ex);
                }
            }
        }
    }
}