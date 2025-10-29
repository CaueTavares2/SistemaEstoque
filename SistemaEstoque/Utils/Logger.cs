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
                // Formato do log: [DATA HORA] [TIPO] MENSAGEM
                string logEntry = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] [{type}] {message}{Environment.NewLine}";

                // 1. Verifica e cria o diretório se necessário (embora a Área de Trabalho sempre exista)
                if (!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }

                // 2. Adiciona o texto ao arquivo. Cria o arquivo se ele não existir.
                File.AppendAllText(LogFilePath, logEntry);
            }
            catch (Exception ex)
            {
                // Em caso de falha na escrita do log (ex: problemas de permissão), 
                // exibimos um alerta, mas evitamos travar a aplicação principal.
                MessageBox.Show($"Erro grave ao tentar escrever no log: {ex.Message}\nO log deveria ser salvo em: {LogFilePath}",
                                "Erro de Logger",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}