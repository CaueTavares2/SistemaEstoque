using System;
using System.Collections.Generic;
using MySqlConnector;
namespace SistemaEstoque.DAO
{
    public class ProdutoDAO
    {
        // Método para INSERIR um novo produto no banco de dados
        public void Inserir(Produto p, int idCategoria)
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

        // Método para OBTER a lista de todos os produtos do banco
        public List<Produto> ObterTodos()
        {
            var lista = new List<Produto>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT p.idproduto, p.nome_produto, p.quantidade, p.preco_venda, c.nome as categoria_nome
FROM produto p
JOIN categoria c ON p.fk_categoria_idcategoria = c.idcategoria";
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
            return lista;
        }

        // Método para ATUALIZAR um produto existente
        public void Atualizar(Produto p, int idCategoria)
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

        // Método para EXCLUIR um produto
        public void Excluir(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                // Primeiro, exclua movimentações relacionadas para evitar erro de chave estrangeira
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
    }
}