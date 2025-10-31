// Arquivo: LogManager.cs (ou Logger.cs)

using System;
using System.IO;
// Adicionamos System.Windows.Forms apenas para o MessageBox em caso de erro no log
using System.Windows.Forms;

namespace SistemaEstoque.Logger
{
    // Tornamos a classe estática para facilitar o acesso de qualquer lugar: LogManager.WriteLog(...)
    public static class LogManager
    {
        // CRÍTICO: Define o caminho para a Área de Trabalho do usuário
        private static readonly string LogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Define o nome do arquivo de log
        private static readonly string LogFileName = "SistemaEstoque_Log.txt";

        // Combina o caminho do diretório com o nome do arquivo
        private static readonly string LogFilePath = Path.Combine(LogDirectory, LogFileName);

        public static void WriteLog(string message, string type = "INFO")
        {
            try
            {
                // Adiciona informações de contexto
                string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string machine = Environment.MachineName;

                string logEntry = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] [{type}] [User: {user}] [Machine: {machine}] {message}{Environment.NewLine}";

                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }

                File.AppendAllText(LogFilePath, logEntry);
            }
            catch (Exception ex)
            {
                // Mantém o tratamento de erro existente
            }
        }
    }
}