using System;
using System.Collections.Generic;
using MySqlConnector;
using SistemaEstoque.DAO;
using SistemaEstoque.Logger; // Adicione este using

namespace SistemaEstoque.DAO
{
    public class FornecedorDAO
    {
        public void Inserir(Fornecedor f)
        {
            try
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
            catch (MySqlException ex)
            {
                // Log específico para erro de MySQL
                LogManager.WriteLog($"Erro MySQL ao inserir fornecedor: {ex.Message}", "ERRO_BD");

                if (ex.Number == 1062) // ERRO: Entrada duplicada
                {
                    throw new Exception("Já existe um fornecedor com este CNPJ cadastrado.");
                }
                throw new Exception("Erro ao inserir fornecedor no banco de dados.");
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro geral ao inserir fornecedor: {ex.Message}", "ERRO");
                throw new Exception("Erro ao inserir fornecedor.");
            }
        }

        public List<Fornecedor> ObterTodos()
        {
            var lista = new List<Fornecedor>();
            try
            {
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
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro ao carregar fornecedores: {ex.Message}", "ERRO_BD");
                throw new Exception("Erro ao carregar lista de fornecedores.");
            }
            return lista;
        }

        public void Atualizar(Fornecedor f)
        {
            try
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
            catch (MySqlException ex)
            {
                LogManager.WriteLog($"Erro MySQL ao atualizar fornecedor: {ex.Message}", "ERRO_BD");
                if (ex.Number == 1062)
                {
                    throw new Exception("Já existe um fornecedor com este CNPJ cadastrado.");
                }
                throw new Exception("Erro ao atualizar fornecedor no banco de dados.");
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro geral ao atualizar fornecedor: {ex.Message}", "ERRO");
                throw new Exception("Erro ao atualizar fornecedor.");
            }
        }

        public void Excluir(int id)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM fornecedor WHERE idfornecedor=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Fornecedor não encontrado para exclusão.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                LogManager.WriteLog($"Erro MySQL ao excluir fornecedor: {ex.Message}", "ERRO_BD");
                if (ex.Number == 1451) // ERRO: Chave estrangeira
                {
                    throw new Exception("Não é possível excluir este fornecedor pois existem produtos vinculados a ele.");
                }
                throw new Exception("Erro ao excluir fornecedor do banco de dados.");
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro geral ao excluir fornecedor: {ex.Message}", "ERRO");
                throw;
            }
        }
    }
}