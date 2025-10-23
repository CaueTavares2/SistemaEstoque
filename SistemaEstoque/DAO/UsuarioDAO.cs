using System;
using MySqlConnector;
using System.Windows.Forms;
using SistemaEstoque.Utils; // Adicionado para usar o CryptoHelper

namespace SistemaEstoque.DAO
{
    public class UsuarioDAO
    {
        /// <summary>
        /// Valida as credenciais de login, hasheando a senha fornecida antes de comparar.
        /// </summary>
        public bool ValidarLogin(string login, string senha)
        {
            try
            {
                // 1. GERAÇÃO DO HASH: Hasheia a senha fornecida pelo usuário.
                string senhaHash = CryptoHelper.ComputeSha256Hash(senha);

                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // A consulta valida o login contra o HASH da senha.
                    string sql = "SELECT COUNT(*) FROM usuario WHERE login=@login AND senha=@senhaHash";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senhaHash", senhaHash); // Usa o hash para comparação

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

        /// <summary>
        /// Insere um novo usuário, hasheando a senha antes de salvar no banco.
        /// </summary>
        public void Inserir(string login, string senha)
        {
            // 2. GERAÇÃO DO HASH: Hasheia a senha antes de salvar no banco de dados.
            string senhaHash = CryptoHelper.ComputeSha256Hash(senha);

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    // Assumindo que a tabela 'usuario' tem as colunas 'login' e 'senha'
                    string sql = "INSERT INTO usuario (login, senha) VALUES (@login, @senhaHash)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senhaHash", senhaHash); // Salva o HASH
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar novo usuário: " + ex.Message, "Erro de Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Adicione aqui outros métodos como ExcluirUsuario, ObterUsuario, etc., 
        // lembrando de hashear a senha em qualquer ponto de atualização ou obtenção.
    }
}