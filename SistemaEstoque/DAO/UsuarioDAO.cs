// Arquivo: UsuarioDAO.cs (VERSÃO CORRIGIDA)

using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Windows.Forms;
using SistemaEstoque;
using SistemaEstoque.Logger;

namespace SistemaEstoque.DAO
{
    public class UsuarioDAO
    {
        private static Dictionary<string, LoginAttemptInfo> loginAttempts =
            new Dictionary<string, LoginAttemptInfo>();

        // Classe auxiliar para armazenar informações de tentativas
        private class LoginAttemptInfo
        {
            public int Attempts { get; set; }
            public DateTime LockTime { get; set; }
        }

        public (int id, string nivelAcesso) ObterUsuarioLogado(string login, string senha)
        {
            // VERIFICAÇÃO DE BLOQUEIO POR TENTATIVAS
            if (IsAccountLocked(login))
            {
                MessageBox.Show("Conta temporariamente bloqueada por excesso de tentativas. Tente novamente em 15 minutos.",
                               "Conta Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return (0, null);
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    // CORREÇÃO SEGURANÇA: Usar parâmetro para senha
                    string sql = "SELECT idusuario, nivel_acesso FROM usuario WHERE login=@login AND senha=SHA2(@senha, 256)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // LOGIN BEM-SUCEDIDO: Reseta tentativas
                            ResetLoginAttempts(login);

                            int id = reader.GetInt32("idusuario");
                            string nivelAcesso = reader.GetString("nivel_acesso");

                            // LOG de login bem-sucedido
                            LogManager.WriteLog($"Login bem-sucedido para usuário: {login}", "SEGURANCA");

                            return (id, nivelAcesso);
                        }
                        else
                        {
                            // LOGIN FALHOU: Incrementa tentativas
                            IncrementLoginAttempts(login);

                            // LOG de tentativa falha
                            LogManager.WriteLog($"Tentativa de login falhou para usuário: {login}", "SEGURANCA");

                            MessageBox.Show("Usuário ou senha incorretos.", "Erro de Login",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return (0, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message,
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, null);
            }
        }

        private bool IsAccountLocked(string login)
        {
            if (loginAttempts.ContainsKey(login))
            {
                LoginAttemptInfo attemptInfo = loginAttempts[login];

                // Bloqueia por 15 minutos após 5 tentativas
                if (attemptInfo.Attempts >= 5)
                {
                    if (DateTime.Now < attemptInfo.LockTime.AddMinutes(15))
                    {
                        return true;
                    }
                    else
                    {
                        // Remove o bloqueio após 15 minutos
                        loginAttempts.Remove(login);
                        return false;
                    }
                }
            }
            return false;
        }

        private void IncrementLoginAttempts(string login)
        {
            if (!loginAttempts.ContainsKey(login))
            {
                loginAttempts[login] = new LoginAttemptInfo
                {
                    Attempts = 1,
                    LockTime = DateTime.Now
                };
            }
            else
            {
                LoginAttemptInfo attemptInfo = loginAttempts[login];
                attemptInfo.Attempts++;
                attemptInfo.LockTime = DateTime.Now;
            }
        }

        private void ResetLoginAttempts(string login)
        {
            if (loginAttempts.ContainsKey(login))
            {
                loginAttempts.Remove(login);
            }
        }

        // Método de Inserção mantido igual
        public void Inserir(string login, string senha)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
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
    }
}