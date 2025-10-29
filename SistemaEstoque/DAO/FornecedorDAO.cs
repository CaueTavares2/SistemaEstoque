// Arquivo: FornecedorDAO.cs (NOVO)
using System;
using System.Collections.Generic;
using MySqlConnector;
using SistemaEstoque.DAO;

namespace SistemaEstoque.DAO
{
    public class FornecedorDAO
    {
        public void Inserir(Fornecedor f)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO fornecedor (razao_social, cnpj, nome_fantasia, email)
                               VALUES (@razao, @cnpj, @fantasia, @email)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@razao", f.RazaoSocial);
                cmd.Parameters.AddWithValue("@cnpj", f.Cnpj);
                cmd.Parameters.AddWithValue("@fantasia", f.NomeFantasia);
                cmd.Parameters.AddWithValue("@email", f.Email);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Fornecedor> ObterTodos()
        {
            var lista = new List<Fornecedor>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT idfornecedor, razao_social, cnpj, nome_fantasia, email FROM fornecedor ORDER BY razao_social";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Fornecedor
                        {
                            Id = reader.GetInt32("idfornecedor"),
                            RazaoSocial = reader.GetString("razao_social"),
                            Cnpj = reader.GetString("cnpj"),
                            NomeFantasia = reader.GetString("nome_fantasia"),
                            Email = reader.GetString("email")
                        });
                    }
                }
            }
            return lista;
        }

        public void Atualizar(Fornecedor f)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE fornecedor SET razao_social=@razao, cnpj=@cnpj, nome_fantasia=@fantasia, email=@email 
                               WHERE idfornecedor=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@razao", f.RazaoSocial);
                cmd.Parameters.AddWithValue("@cnpj", f.Cnpj);
                cmd.Parameters.AddWithValue("@fantasia", f.NomeFantasia);
                cmd.Parameters.AddWithValue("@email", f.Email);
                cmd.Parameters.AddWithValue("@id", f.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM fornecedor WHERE idfornecedor=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}