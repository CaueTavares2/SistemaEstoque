
using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using System.Threading; // Pode ser útil para timers, mas vamos usar o Timer do Designer

namespace SistemaEstoque
{
    public partial class FormLogin : Form
    {
        // 1. Adicionar um Timer (Você precisa adicioná-lo no FormLogin.Designer.cs)
        private System.Windows.Forms.Timer tmrFadeOut;
        private System.Windows.Forms.Timer tmrFadeIn;
        private FormMenu menuForm; // Variável para armazenar a instância do FormMenu

        public FormLogin()
        {
            InitializeComponent();
            InicializarTimers(); // Chamada para configurar os timers
        }

        private void InicializarTimers()
        {
            // Configuração do Timer para Fade Out (saída do Login)
            tmrFadeOut = new System.Windows.Forms.Timer();
            tmrFadeOut.Interval = 20; // Intervalo pequeno para animação suave
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
                // 1. ESCONDE O LOGIN (como já combinamos)
                // this.Hide(); // Não vamos esconder ainda, vamos animar

                // 2. Prepara o formulário de destino
                menuForm = new FormMenu();

                // 3. Inicia o Fade Out do formulário atual
                tmrFadeOut.Start();
                this.btnEntrar.Enabled = false; // Desabilita o botão para evitar cliques múltiplos
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
                this.Opacity -= 0.05; // Reduz a opacidade em 5% por tick
            }
            else
            {
                tmrFadeOut.Stop();
                // Transição completa: Fecha o Login e abre o Menu com animação
                this.Hide();
                menuForm.Opacity = 0; // Garante que o próximo formulário comece transparente
                menuForm.Show();
                tmrFadeIn.Start(); // Inicia o Fade In do Menu
            }
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            if (menuForm.Opacity < 1)
            {
                menuForm.Opacity += 0.05; // Aumenta a opacidade em 5% por tick
            }
            else
            {
                tmrFadeIn.Stop();
                // Animação completa, fecha o FormLogin permanentemente (como no seu fluxo original)
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}