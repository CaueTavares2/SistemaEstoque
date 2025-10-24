using System;
using System.IO;
using System.Text;

namespace SistemaEstoque.Utils
{
    public static class Logger
    {
        // Define o diretório onde os logs serão salvos de forma persistente.
        private static readonly string LogDirectory = @"C:\Logs\SistemaEstoque\";

        // O nome do arquivo agora será fixo, para facilitar a checagem dos códigos de erro.
        private static readonly string LogFile = Path.Combine(LogDirectory, "sistema_estoque.log");

        /// <summary>
        /// Garante que o diretório de log exista.
        /// </summary>
        private static void EnsureLogDirectoryExists()
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        /// <summary>
        /// Registra uma mensagem no arquivo de log, incluindo um código de erro.
        /// </summary>
        /// <param name="errorCode">O código de erro da convenção (ex: 201).</param>
        /// <param name="message">A descrição da ação ou erro.</param>
        /// <param name="ex">A exceção, se houver (opcional).</param>
        public static void Log(string errorCode, string message, Exception ex = null)
        {
            EnsureLogDirectoryExists();

            StringBuilder logEntry = new StringBuilder();

            // Formato da entrada do log: [DATA HORA] [CÓDIGO DE ERRO] MENSAGEM
            logEntry.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [ERRO {errorCode}] {message}");

            if (ex != null)
            {
                // Adiciona detalhes da exceção
                logEntry.AppendLine($"  -> EXCEPTION: {ex.GetType().Name}");
                logEntry.AppendLine($"  -> MESSAGE: {ex.Message}");
                logEntry.AppendLine($"  -> STACK TRACE:\n{ex.StackTrace}");
            }

            logEntry.AppendLine(new string('-', 60)); // Linha separadora

            try
            {
                File.AppendAllText(LogFile, logEntry.ToString(), Encoding.UTF8);
            }
            catch (Exception writeEx)
            {
                // Em caso de falha ao escrever no log, tenta imprimir no console/debugger.
                Console.WriteLine($"ERRO FATAL NO LOGGER: Falha ao escrever no arquivo de log: {writeEx.Message}");
            }
        }
    }
}