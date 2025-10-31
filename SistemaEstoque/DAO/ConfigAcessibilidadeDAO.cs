using System;
using MySqlConnector;
using SistemaEstoque.Classes;
using SistemaEstoque.Logger;

namespace SistemaEstoque.DAO
{
    public class ConfigAcessibilidadeDAO
    {
        public ConfigAcessibilidade ObterConfiguracao(int usuarioId)
        {
            ConfigAcessibilidade config = null;

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT idconfig, fk_usuario_idusuario, tema_escuro, fonte_tamanho, 
                                          alto_contraste, leitor_tela, navegacao_teclado, 
                                          descricao_imagens, contraste_cores 
                                   FROM config_acessibilidade 
                                   WHERE fk_usuario_idusuario = @usuarioId";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            config = new ConfigAcessibilidade
                            {
                                Id = reader.GetInt32("idconfig"),
                                UsuarioId = reader.GetInt32("fk_usuario_idusuario"),
                                TemaEscuro = reader.GetBoolean("tema_escuro"),
                                FonteTamanho = reader.GetInt32("fonte_tamanho"),
                                AltoContraste = reader.GetBoolean("alto_contraste"),
                                LeitorTela = reader.GetBoolean("leitor_tela"),
                                NavegacaoTeclado = reader.GetBoolean("navegacao_teclado"),
                                DescricaoImagens = reader.GetBoolean("descricao_imagens"),
                                ContrasteCores = reader.GetString("contraste_cores")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro ao obter configuração de acessibilidade: {ex.Message}", "ERRO_BD");
            }

            return config ?? new ConfigAcessibilidade { UsuarioId = usuarioId };
        }

        public void SalvarConfiguracao(ConfigAcessibilidade config)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO config_acessibilidade 
                                   (fk_usuario_idusuario, tema_escuro, fonte_tamanho, alto_contraste, 
                                    leitor_tela, navegacao_teclado, descricao_imagens, contraste_cores) 
                                   VALUES (@usuarioId, @temaEscuro, @fonteTamanho, @altoContraste, 
                                           @leitorTela, @navegacaoTeclado, @descricaoImagens, @contrasteCores)
                                   ON DUPLICATE KEY UPDATE 
                                   tema_escuro = @temaEscuro, 
                                   fonte_tamanho = @fonteTamanho, 
                                   alto_contraste = @altoContraste,
                                   leitor_tela = @leitorTela,
                                   navegacao_teclado = @navegacaoTeclado,
                                   descricao_imagens = @descricaoImagens,
                                   contraste_cores = @contrasteCores";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", config.UsuarioId);
                    cmd.Parameters.AddWithValue("@temaEscuro", config.TemaEscuro);
                    cmd.Parameters.AddWithValue("@fonteTamanho", config.FonteTamanho);
                    cmd.Parameters.AddWithValue("@altoContraste", config.AltoContraste);
                    cmd.Parameters.AddWithValue("@leitorTela", config.LeitorTela);
                    cmd.Parameters.AddWithValue("@navegacaoTeclado", config.NavegacaoTeclado);
                    cmd.Parameters.AddWithValue("@descricaoImagens", config.DescricaoImagens);
                    cmd.Parameters.AddWithValue("@contrasteCores", config.ContrasteCores);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro ao salvar configuração de acessibilidade: {ex.Message}", "ERRO_BD");
                throw new Exception("Erro ao salvar configurações de acessibilidade.");
            }
        }
    }
}