// Arquivo: UsuarioDAO.cs (SUBSTITUIÇÃO COMPLETA)

using System;
using MySqlConnector;
using System.Windows.Forms;
using SistemaEstoque;
using SistemaEstoque.Logger;

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
                    // O novo usuário é salvo como 'Operador' por padrão
                    string sql = "INSERT INTO usuario (login, senha, nivel_acesso) VALUES (@login, SHA2(@senha, 256), 'Operador')";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("Erro: O login informado já está em uso.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro ao tentar cadastrar o usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. Método de Validação de Login (AGORA RETORNA ID E NÍVEL DE ACESSO)
        public (int id, string nivelAcesso) ObterUsuarioLogado(string login, string senha)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Seleciona ID e NÍVEL DE ACESSO
                    string sql = "SELECT idusuario, nivel_acesso FROM usuario WHERE login=@login AND senha=SHA2('" + senha + "', 256)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32("idusuario");
                            string nivelAcesso = reader.GetString("nivel_acesso");
                            return (id, nivelAcesso); // Retorna o ID e o Nível de Acesso
                        }
                        else
                        {
                            return (0, null); // Login falhou.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, null);
            }
        }
    }
}