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
            // Abre a nova tela de cadastro de usuários em modo modal
            using (var formCadastro = new FormCadastroUsuario())
            {
                formCadastro.ShowDialog();
            }

            // Opcional: Limpa os campos de login para o usuário
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario.Focus();
        }
    }

}