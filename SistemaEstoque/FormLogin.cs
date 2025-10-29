// Arquivo: FormLogin.cs

using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
// Mantenha ou adicione este using se UserSession estiver em Classes
using SistemaEstoque.Classes;

namespace SistemaEstoque
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnEntrar;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha todos os campos para fazer login.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDAO dao = new UsuarioDAO();

            // CORREÇÃO CRÍTICA: Usa o método ObterUsuarioLogado que retorna a tupla
            (int idUsuario, string nivelAcesso) resultado = dao.ObterUsuarioLogado(usuario, senha);

            // Verifica se o login foi bem-sucedido (idUsuario > 0)
            if (resultado.idUsuario > 0)
            {
                // Login com sucesso: Preenche a sessão
                UserSession.IdUsuario = resultado.idUsuario;
                UserSession.Login = usuario;             // <--- Preenche o campo Login corrigido
                UserSession.NivelAcesso = resultado.nivelAcesso;

                MessageBox.Show($"Bem vindo(a), {UserSession.Login}!", "Login OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre o menu
                this.Hide();
                new FormMenu().ShowDialog();
                this.Close();
            }
            else
            {
                // Falha no login:
                MessageBox.Show("Usuário ou senha incorretos. Tente novamente.", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtSenha.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblCadastro_Click(object sender, EventArgs e)
        {
            new FormCadastroUsuario().ShowDialog();
        }

        // Se você tiver outros métodos como FormLogin_Load, adicione aqui
    }
}