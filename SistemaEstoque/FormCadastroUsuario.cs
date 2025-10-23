// Arquivo: FormCadastroUsuario.cs (REVISADO)

using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;

namespace SistemaEstoque
{
    public partial class FormCadastroUsuario : Form
    {
        public FormCadastroUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrarUsuario_Click_1(object sender, EventArgs e) // <--- ESTE É O MÉTODO QUE DEVE SER LIGADO AO BOTÃO
        {
            // 1. Coleta de dados (VERIFIQUE SE OS NOMES SÃO EXATAMENTE ESTES!)
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
                // Não precisa fazer nada aqui, a não ser que queira logar o erro.
            }
        }

        
    }
}