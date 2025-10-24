using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Utils; // Importa o Logger

namespace SistemaEstoque
{
    public partial class FormLogin : Form
    {
        private System.Windows.Forms.Timer tmrFadeOut;
        private System.Windows.Forms.Timer tmrFadeIn;
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

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDAO dao = new UsuarioDAO();
            bool loginValido = false;

            try
            {
                loginValido = dao.ValidarLogin(user, pass);
            }
            catch // Captura erros que o DAO não conseguiu tratar internamente (raro, mas possível)
            {
                // Este log já deve ocorrer dentro do UsuarioDAO se for erro de conexão.
                // Mantido como fallback para erros inesperados fora do DAO.
                Logger.LogError($"[FormLogin] Erro inesperado ao tentar chamar ValidarLogin para o usuário: {user}.", null);
                MessageBox.Show("Ocorreu um erro inesperado durante a validação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loginValido)
            {
                // Se o login é válido, iniciamos a animação de saída
                menuForm = new FormMenu(); // Instancia o Menu aqui
                tmrFadeOut.Start();
                this.btnEntrar.Enabled = false;
            }
            else
            {
                // *** CORREÇÃO DO ERRO CS7036: Passando 'null' para o parâmetro 'Exception' ***
                Logger.LogError($"Tentativa de login falhou: Usuário '{user}' tentou acessar com credenciais inválidas.", null);
                // ***************************************************************

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