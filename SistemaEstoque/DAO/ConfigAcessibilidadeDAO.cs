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

                            LogManager.WriteLog($"Configurações carregadas para usuário {usuarioId}", "ACESSIBILIDADE");
                        }
                        else
                        {
                            LogManager.WriteLog($"Nenhuma configuração encontrada para usuário {usuarioId}, usando padrão", "ACESSIBILIDADE");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                LogManager.WriteLog($"Erro MySQL ao obter configuração: {ex.Message} (Código: {ex.Number})", "ERRO_BD_ACESSIBILIDADE");

                // Se a tabela não existe, não quebra a aplicação
                if (ex.Number == 1146) // Table doesn't exist
                {
                    LogManager.WriteLog("Tabela config_acessibilidade não existe. Criar tabela.", "ERRO_BD_ACESSIBILIDADE");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro geral ao obter configuração: {ex.Message}", "ERRO_ACESSIBILIDADE");
            }

            // Retorna configuração padrão se não encontrou ou se houve erro
            return config ?? new ConfigAcessibilidade { UsuarioId = usuarioId };
        }

        public void SalvarConfiguracao(ConfigAcessibilidade config)
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // SQL melhorado com tratamento de erro mais específico
                    string sql = @"INSERT INTO config_acessibilidade 
                           (fk_usuario_idusuario, tema_escuro, fonte_tamanho, alto_contraste, 
                            leitor_tela, navegacao_teclado, descricao_imagens, contraste_cores) 
                           VALUES (@usuarioId, @temaEscuro, @fonteTamanho, @altoContraste, 
                                   @leitorTela, @navegacaoTeclado, @descricaoImagens, @contrasteCores)
                           ON DUPLICATE KEY UPDATE 
                           tema_escuro = VALUES(tema_escuro), 
                           fonte_tamanho = VALUES(fonte_tamanho), 
                           alto_contraste = VALUES(alto_contraste),
                           leitor_tela = VALUES(leitor_tela),
                           navegacao_teclado = VALUES(navegacao_teclado),
                           descricao_imagens = VALUES(descricao_imagens),
                           contraste_cores = VALUES(contraste_cores)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuarioId", config.UsuarioId);
                    cmd.Parameters.AddWithValue("@temaEscuro", config.TemaEscuro);
                    cmd.Parameters.AddWithValue("@fonteTamanho", config.FonteTamanho);
                    cmd.Parameters.AddWithValue("@altoContraste", config.AltoContraste);
                    cmd.Parameters.AddWithValue("@leitorTela", config.LeitorTela);
                    cmd.Parameters.AddWithValue("@navegacaoTeclado", config.NavegacaoTeclado);
                    cmd.Parameters.AddWithValue("@descricaoImagens", config.DescricaoImagens);
                    cmd.Parameters.AddWithValue("@contrasteCores", config.ContrasteCores);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Log de sucesso
                    LogManager.WriteLog($"Configurações salvas para usuário {config.UsuarioId}. Linhas afetadas: {rowsAffected}", "ACESSIBILIDADE");
                }
            }
            catch (MySqlException ex)
            {
                // Log específico para erro MySQL
                string errorMessage = $"Erro MySQL ({ex.Number}): {ex.Message}";
                LogManager.WriteLog(errorMessage, "ERRO_BD_ACESSIBILIDADE");

                // Mensagens mais específicas baseadas no código de erro
                switch (ex.Number)
                {
                    case 1062: // Duplicate entry
                        throw new Exception("Já existe uma configuração para este usuário.");
                    case 1452: // Foreign key constraint fails
                        throw new Exception("Usuário não encontrado no banco de dados.");
                    case 1045: // Access denied
                        throw new Exception("Acesso negado ao banco de dados. Verifique as credenciais.");
                    default:
                        throw new Exception($"Erro de banco de dados: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro geral ao salvar configuração de acessibilidade: {ex.Message}", "ERRO_ACESSIBILIDADE");
                throw new Exception($"Erro ao salvar configurações: {ex.Message}");
            }
        }

        public void CriarTabelaSeNaoExiste()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                CREATE TABLE IF NOT EXISTS config_acessibilidade (
                    idconfig INT NOT NULL AUTO_INCREMENT,
                    fk_usuario_idusuario INT NOT NULL,
                    tema_escuro BOOLEAN NOT NULL DEFAULT FALSE,
                    fonte_tamanho INT NOT NULL DEFAULT 9,
                    alto_contraste BOOLEAN NOT NULL DEFAULT FALSE,
                    leitor_tela BOOLEAN NOT NULL DEFAULT FALSE,
                    navegacao_teclado BOOLEAN NOT NULL DEFAULT TRUE,
                    descricao_imagens BOOLEAN NOT NULL DEFAULT FALSE,
                    contraste_cores VARCHAR(20) NOT NULL DEFAULT 'normal',
                    PRIMARY KEY (idconfig),
                    UNIQUE KEY (fk_usuario_idusuario),
                    FOREIGN KEY (fk_usuario_idusuario) REFERENCES usuario(idusuario)
                        ON DELETE CASCADE
                        ON UPDATE CASCADE
                )";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    LogManager.WriteLog("Tabela config_acessibilidade verificada/criada com sucesso", "BD_ACESSIBILIDADE");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog($"Erro ao criar tabela config_acessibilidade: {ex.Message}", "ERRO_BD_ACESSIBILIDADE");
                throw;
            }
        }
    }
}