using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Utils; // Importa o Logger

namespace SistemaEstoque
{
    public partial class FormLogin : Form
    {
        
        private FormMenu menuForm;

        public FormLogin()
        {
            InitializeComponent();
            InicializarTimers(); // Chamada para configurar os timers
        }

        private void InicializarTimers()
        {
            // Configuração do Timer para Fade Out (saída do Login)
            tmrFadeOut = new System.Windows.Forms.Timer();
            tmrFadeOut.Interval = 20;
            tmrFadeOut.Tick += new EventHandler(tmrFadeOut_Tick);

            // Configuração do Timer para Fade In (entrada do Menu)
            tmrFadeIn = new System.Windows.Forms.Timer();
            tmrFadeIn.Interval = 20;
            tmrFadeIn.Tick += new EventHandler(tmrFadeIn_Tick);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtSenha.Text;

            UsuarioDAO dao = new UsuarioDAO();

            if (dao.ValidarLogin(user, pass))
            {
                // ----------------------------------------------------
                // CÓDIGO TEMPORÁRIO DE TESTE: IGNORA A ANIMAÇÃO
                // ----------------------------------------------------

                // 1. Esconde a tela de Login
                this.Hide();

                // 2. Cria e mostra o FormMenu IMEDIATAMENTE
                FormMenu menuForm = new FormMenu();
                menuForm.Show();

                // 3. Fecha o FormLogin
                this.Close();

                // ----------------------------------------------------
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tmrFadeOut_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                tmrFadeOut.Stop();
                this.Hide();
                menuForm.Opacity = 0;
                menuForm.Show();
                tmrFadeIn.Start();
            }
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            if (menuForm.Opacity < 1)
            {
                menuForm.Opacity += 0.05;
            }
            else
            {
                tmrFadeIn.Stop();
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // *** CORREÇÃO DO ERRO CS1061: Método renomeado para corresponder ao Designer ***
        private void lblCadastro_Click(object sender, EventArgs e)
        {
            new FormCadastroUsuario().ShowDialog();
        }
        // ******************************************************************************
    }
}