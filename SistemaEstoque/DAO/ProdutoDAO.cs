using System;
using System.Collections.Generic;
using MySqlConnector;
using SistemaEstoque.Utils; // Importa o Logger
using SistemaEstoque.DAO; // Importa o Database e outras DAOs, se necessário

namespace SistemaEstoque.DAO
{
    public class ProdutoDAO
    {
        /// <summary>
        /// Insere um novo produto no banco de dados.
        /// </summary>
        public void Inserir(Produto p, int idCategoria)
        {
            try // Bloco TRY para capturar erros de conexão ou SQL
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"INSERT INTO produto (nome_produto, quantidade, preco_venda, estoque_minimo, fk_categoria_idcategoria)
VALUES (@nome, @qtd, @venda, @min, @cat)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@qtd", p.Quantidade);
                    cmd.Parameters.AddWithValue("@venda", p.Preco);
                    cmd.Parameters.AddWithValue("@min", 1); // Estoque mínimo padrão
                    cmd.Parameters.AddWithValue("@cat", idCategoria);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"[DAO] Falha ao inserir o produto: {p.Nome}.", ex);
                throw; // Re-lança a exceção para que a camada de UI possa exibir um aviso.
            }
        }

        /// <summary>
        /// Obtém a lista de todos os produtos do banco de dados.
        /// </summary>
        public List<Produto> ObterTodos()
        {
            var lista = new List<Produto>();
            try // Bloco TRY para capturar erros de conexão ou SQL
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT p.idproduto, p.nome_produto, p.quantidade, p.preco_venda, c.nome as categoria_nome
FROM produto p
JOIN categoria c ON p.fk_categoria_idcategoria = c.idcategoria
ORDER BY p.nome_produto"; // Adicionado ORDER BY para melhor UX

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Produto
                            {
                                Id = reader.GetInt32("idproduto"),
                                Nome = reader.GetString("nome_produto"),
                                Quantidade = reader.GetInt32("quantidade"),
                                Preco = reader.GetDecimal("preco_venda"),
                                Categoria = reader.GetString("categoria_nome")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("[DAO] Falha ao obter a lista de todos os produtos do banco de dados.", ex);
                throw;
            }
            return lista;
        }

        /// <summary>
        /// Atualiza os dados de um produto existente.
        /// </summary>
        public void Atualizar(Produto p, int idCategoria)
        {
            try // Bloco TRY para capturar erros de conexão ou SQL
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE produto SET nome_produto=@nome, quantidade=@qtd,
preco_venda=@venda, fk_categoria_idcategoria=@cat WHERE idproduto=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", p.Nome);
                    cmd.Parameters.AddWithValue("@qtd", p.Quantidade);
                    cmd.Parameters.AddWithValue("@venda", p.Preco);
                    cmd.Parameters.AddWithValue("@cat", idCategoria);
                    cmd.Parameters.AddWithValue("@id", p.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"[DAO] Falha ao atualizar produto ID: {p.Id}, Nome: {p.Nome}.", ex);
                throw;
            }
        }

        /// <summary>
        /// Exclui um produto e todas as suas movimentações relacionadas.
        /// </summary>
        public void Excluir(int id)
        {
            try // Bloco TRY para capturar erros de conexão ou SQL
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // CRÍTICO: Primeiro, exclua movimentações relacionadas para evitar erro de chave estrangeira
                    string sqlMov = "DELETE FROM movimentacao WHERE fk_produto_idproduto=@id";
                    MySqlCommand cmdMov = new MySqlCommand(sqlMov, conn);
                    cmdMov.Parameters.AddWithValue("@id", id);
                    cmdMov.ExecuteNonQuery();

                    // Agora, exclua o produto
                    string sqlProd = "DELETE FROM produto WHERE idproduto=@id";
                    MySqlCommand cmdProd = new MySqlCommand(sqlProd, conn);
                    cmdProd.Parameters.AddWithValue("@id", id);
                    cmdProd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"[DAO] Falha ao excluir produto ID: {id}.", ex);
                throw;
            }
        }
    }
}