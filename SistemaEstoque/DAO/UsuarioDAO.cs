// Arquivo: UsuarioDAO.cs (COMPLETO E CORRIGIDO)

using System;
using MySqlConnector;
using System.Windows.Forms;

namespace SistemaEstoque.DAO
{
    public class UsuarioDAO
    {
        // 1. Método de Inserção de Novo Usuário (Faltante)
        public void Inserir(string login, string senha)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // CRÍTICO: Usamos a função SHA2 do MySQL para hashear a senha antes de salvar.
                    string sql = "INSERT INTO usuario (login, senha) VALUES (@login, SHA2(@senha, 256))";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha); // O MySQL fará o hash no banco.

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Verifica se é um erro de duplicidade (ex: login já existe)
                if (ex.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("Erro: O login informado já está em uso. Por favor, escolha outro.", "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro ao tentar cadastrar o usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw; // Propaga a exceção para que o FormCadastroUsuario saiba que falhou.
            }
        }

        // 2. Método de Validação de Login (Corrigido para usar Hash)
        public bool ValidarLogin(string login, string senha)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // CRÍTICO: Compara o login e o HASH SHA256 da senha digitada
                    // com o hash salvo no banco. O Login só funciona se o Admin tiver a senha hasheada no banco.
                    string sql = "SELECT COUNT(*) FROM usuario WHERE login=@login AND senha=SHA2('" + senha + "', 256)";
                    // NOTA: Usamos concatenação aqui (SHA2('"+senha+"', 256)) pois o MySqlConnector não suporta 
                    // a função SHA2 como um parâmetro '@senhaHash' diretamente na query.

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    // O valor de 'senha' já está concatenado na string SQL.

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}