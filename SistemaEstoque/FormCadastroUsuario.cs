// Arquivo: FormCadastroUsuario.cs

using System;
using System.Windows.Forms;
using SistemaEstoque.DAO; // Importa o DAO para usar a classe UsuarioDAO

namespace SistemaEstoque
{
    public partial class FormCadastroUsuario : Form
    {
        public FormCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            // 1. Coleta de dados (Assumindo que os campos se chamam: txtLogin, txtSenha, txtConfirmaSenha)
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text;
            string confirmaSenha = txtConfirmaSenha.Text;

            // 2. Validações Básicas
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Login e Senha não podem estar vazios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (senha != confirmaSenha)
            {
                MessageBox.Show("A senha e a confirmação de senha não coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Chamada segura ao DAO
            UsuarioDAO dao = new UsuarioDAO();
            try
            {
                // O método Inserir do DAO se encarrega de HASHEAR a senha antes de salvar!
                dao.Inserir(login, senha);

                MessageBox.Show($"Usuário '{login}' cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa campos após sucesso
                txtLogin.Clear();
                txtSenha.Clear();
                txtConfirmaSenha.Clear();
                txtLogin.Focus();
            }
            catch (Exception)
            {
                // A exceção de erro de banco já foi tratada e exibida dentro do DAO.
            }
        }
    }
}