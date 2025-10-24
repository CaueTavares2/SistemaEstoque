// Arquivo: SistemaEstoque/Utils/Logger.cs

using System;
using System.IO;

namespace SistemaEstoque.Utils
{
    public static class Logger
    {
        // NOVO: Define o caminho do log para a pasta "Documentos" do usuário.
        private static readonly string LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string LogFileName = "sistema_estoque_log.txt";
        private static readonly string LogFilePath = Path.Combine(LogDirectory, LogFileName);

        /// <summary>
        /// Registra uma mensagem de ERRO no arquivo de log.
        /// </summary>
        /// <param name="message">A mensagem de erro.</param>
        /// <param name="ex">A exceção (pode ser null).</param>
        public static void LogError(string message, Exception ex)
        {
            // Cria a entrada de log com data e hora
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [ERROR] {message}";

            if (ex != null)
            {
                // Adiciona detalhes da exceção se ela for fornecida
                logEntry += Environment.NewLine;
                logEntry += $"  --> Exception: {ex.Message}";
                logEntry += Environment.NewLine;
                logEntry += $"  --> StackTrace: {ex.StackTrace}";
            }

            // Adiciona uma nova linha no final
            logEntry += Environment.NewLine;

            // Tenta escrever no arquivo. 
            try
            {
                // Usa File.AppendAllText para garantir que o arquivo seja aberto, escrito e fechado em cada chamada,
                // o que evita o NullReferenceException que você estava vendo.
                File.AppendAllText(LogFilePath, logEntry);
            }
            catch (Exception fileEx)
            {
                // Se falhar a escrita do log (ex: permissão negada na pasta Documentos), 
                // avisa o desenvolvedor no Debug/Console.
                System.Diagnostics.Debug.WriteLine($"FALHA CRÍTICA: Não foi possível escrever no arquivo de log em '{LogFilePath}'. Erro: {fileEx.Message}");
            }
        }

        // Opcional: Adicionar um método para logs informativos/sucesso
        public static void LogInfo(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] {message}{Environment.NewLine}";
            try
            {
                File.AppendAllText(LogFilePath, logEntry);
            }
            catch { }
        }
    }
}