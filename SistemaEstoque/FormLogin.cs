using System;

using System.Windows.Forms;

using SistemaEstoque.DAO;

namespace SistemaEstoque

{

    public partial class FormLogin : Form

    {

        public FormLogin() { InitializeComponent(); }

        private void btnEntrar_Click(object sender, EventArgs e)

        {

            string user = txtUsuario.Text.Trim();

            string pass = txtSenha.Text;

            UsuarioDAO dao = new UsuarioDAO();

            if (dao.ValidarLogin(user, pass))

            {

                this.Hide();

                using (var menu = new FormMenu())

                {

                    menu.ShowDialog();

                }

                this.Close();

            }

            else

            {

                MessageBox.Show("Usuário ou senha incorretos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }

        private void lblCadastro_Click(object sender, EventArgs e)
        {
            // 1. Oculta o formulário de Login
            this.Hide();

            // 2. Abre o formulário de Cadastro em modo modal (bloqueia outras interações até que ele seja fechado)
            using (var formCadastro = new FormCadastroUsuario())
            {
                formCadastro.ShowDialog();
            }

            // 3. Ao fechar o FormCadastroUsuario, ele volta para cá. 
            //    Agora, reexibe o FormLogin (ou fecha tudo, dependendo do seu fluxo desejado).
            //    Se o usuário cadastrado precisar logar, ele verá a tela de login novamente.
            this.Show();

            // Opcional: Limpa os campos de login para o próximo acesso
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }
    }

}