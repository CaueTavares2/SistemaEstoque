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

            // *** Ap�s o FormLogin fechar (this.Close() for chamado nele), 
            // ele s� deve fechar *depois* que o FormMenu for fechado. ***

            // O FormMenu precisa estar aberto em algum lugar para ser mostrado.
            // COMO o FormMenu foi instanciado DENTRO do FormLogin (no construtor),
            // ele continuar� aberto em segundo plano enquanto o FormLogin estiver vis�vel/oculto.
            // Quando o FormLogin fechar, o FormMenu (se estiver aberto) continua rodando.

            // Para garantir que o aplicativo s� feche quando o Menu fechar:
            // Voc� precisa garantir que o FormMenu feche o aplicativo se ele for fechado.
            // (Verifique o FormMenu.cs para ter certeza que btnSairMenu_Click chama this.Close()).

            // Como a l�gica agora �: Login.Show() -> Login.Hide() -> Menu.Show() -> Login.Close()
            // O programa vai sair AP�S o FormLogin fechar, o que � o comportamento antigo.

            // Para o novo fluxo funcionar: O FormLogin deve ser FECHADO quando o usu�rio deslogar
            // ou sair do programa a partir do Menu.

            // Vamos garantir que o FormMenu feche o aplicativo ao sair:
            // No FormMenu.cs:
            // private void btnSairMenu_Click(object sender, EventArgs e) { Application.Exit(); } // Mudar para Application.Exit() se for fechar tudo.

            // Se voc� quer que o FormMenu seja o principal, vamos mudar o ponto de partida:
            // Application.Run(new FormMenu()); // <-- Isso ignora o Login, ent�o MANTENHA O LOGIN COMO INICIAL.

            // O que acontece no seu caso (Login.Close()): 
            // Se o FormLogin fecha, o Application.Run() termina, e o EXE fecha, a menos que outro Form esteja rodando.

            // SOLU��O: O FormLogin deve apenas ser ocultado, e o FormMenu deve ser o respons�vel por fechar o aplicativo.
            // Como voc� j� fez o 'this.Hide()' no FormLogin, o 'this.Close()' deve ser REMOVIDO. 
            // O Application.Run() vai parar quando o �ltimo formul�rio MODAL (ou o primeiro, se n�o for modal) fechar.
        }
    }
}

// O trecho no FormLogin.cs que voc� removeu:
/*
    // Fecha o FormLogin permanentemente
    this.Close(); // <-- REMOVER ESTA LINHA
*/