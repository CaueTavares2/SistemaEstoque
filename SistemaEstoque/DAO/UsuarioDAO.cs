// Arquivo: UsuarioDAO.cs (ATUALIZADO COM LOGGER)

using System;
using MySqlConnector;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Utils; // Importe o novo namespace do Logger

namespace SistemaEstoque.DAO
{
    public class UsuarioDAO
    {
        // 1. Método de Inserção de Novo Usuário
        public void Inserir(string login, string senha)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Usando a função nativa do MySQL para manter a consistência com a sua query anterior
                    string sql = "INSERT INTO usuario (login, senha) VALUES (@login, SHA2(@senha, 256))";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha); // O MySQL fará o hash

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // LOG: Registra o erro de inserção
                Logger.LogError($"Falha ao inserir novo usuário: {login}", ex);

                if (ex.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("Erro: O login informado já está em uso. Por favor, escolha outro.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro ao tentar cadastrar o usuário: Verifique o log de erros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
        }

        // 2. Método de Validação de Login
        public bool ValidarLogin(string login, string senha)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // CRÍTICO: Compara o login e o HASH SHA256 da senha digitada
                    // NOTA: Mantido o estilo de concatenação para usar a função SHA2 do MySQL.
                    string sql = $"SELECT COUNT(*) FROM usuario WHERE login=@login AND senha=SHA2('{senha}', 256)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // LOG: Registra o erro de validação/conexão
                Logger.LogError($"Falha na validação de login para o usuário: {login}", ex);
                MessageBox.Show("Erro ao conectar ao banco de dados durante o login.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}