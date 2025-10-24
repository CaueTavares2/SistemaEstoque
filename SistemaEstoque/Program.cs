// Arquivo: Program.cs

using System;
using System.Windows.Forms;

namespace SistemaEstoque
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            FormLogin loginForm = new FormLogin();
            Application.Run(loginForm);

            // *** Após o FormLogin fechar (this.Close() for chamado nele), 
            // ele só deve fechar *depois* que o FormMenu for fechado. ***

            // O FormMenu precisa estar aberto em algum lugar para ser mostrado.
            // COMO o FormMenu foi instanciado DENTRO do FormLogin (no construtor),
            // ele continuará aberto em segundo plano enquanto o FormLogin estiver visível/oculto.
            // Quando o FormLogin fechar, o FormMenu (se estiver aberto) continua rodando.

            // Para garantir que o aplicativo só feche quando o Menu fechar:
            // Você precisa garantir que o FormMenu feche o aplicativo se ele for fechado.
            // (Verifique o FormMenu.cs para ter certeza que btnSairMenu_Click chama this.Close()).

            // Como a lógica agora é: Login.Show() -> Login.Hide() -> Menu.Show() -> Login.Close()
            // O programa vai sair APÓS o FormLogin fechar, o que é o comportamento antigo.

            // Para o novo fluxo funcionar: O FormLogin deve ser FECHADO quando o usuário deslogar
            // ou sair do programa a partir do Menu.

            // Vamos garantir que o FormMenu feche o aplicativo ao sair:
            // No FormMenu.cs:
            // private void btnSairMenu_Click(object sender, EventArgs e) { Application.Exit(); } // Mudar para Application.Exit() se for fechar tudo.

            // Se você quer que o FormMenu seja o principal, vamos mudar o ponto de partida:
            // Application.Run(new FormMenu()); // <-- Isso ignora o Login, então MANTENHA O LOGIN COMO INICIAL.

            // O que acontece no seu caso (Login.Close()): 
            // Se o FormLogin fecha, o Application.Run() termina, e o EXE fecha, a menos que outro Form esteja rodando.

            // SOLUÇÃO: O FormLogin deve apenas ser ocultado, e o FormMenu deve ser o responsável por fechar o aplicativo.
            // Como você já fez o 'this.Hide()' no FormLogin, o 'this.Close()' deve ser REMOVIDO. 
            // O Application.Run() vai parar quando o último formulário MODAL (ou o primeiro, se não for modal) fechar.
        }
    }
}

// O trecho no FormLogin.cs que você removeu:
/*
    // Fecha o FormLogin permanentemente
    this.Close(); // <-- REMOVER ESTA LINHA
*/