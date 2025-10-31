// Arquivo: FormCadastroUsuario.cs (REVISADO)

using System;
using System.Linq;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Logger;

namespace SistemaEstoque
{
    public partial class FormCadastroUsuario : Form
    {
        public FormCadastroUsuario()
        {
            InitializeComponent();
        }

        private bool ValidarForcaSenha(string senha)
        {
            if (senha.Length < 8)
                return false;

            bool temDigito = false;
            bool temMaiuscula = false;
            bool temMinuscula = false;

            // Verificação manual sem LINQ
            foreach (char c in senha)
            {
                if (char.IsDigit(c)) temDigito = true;
                if (char.IsUpper(c)) temMaiuscula = true;
                if (char.IsLower(c)) temMinuscula = true;
            }

            return temDigito && temMaiuscula && temMinuscula;
        }

        private void btnCadastrarUsuario_Click_1(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text;
            string confirmaSenha = txtConfirmaSenha.Text;

            // Validações existentes...
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Login e Senha não podem estar vazios.", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (senha != confirmaSenha)
            {
                MessageBox.Show("A senha e a confirmação de senha não coincidem.", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // NOVA VALIDAÇÃO: Força da senha
            if (!ValidarForcaSenha(senha))
            {
                MessageBox.Show("A senha deve ter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas e números.",
                               "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            catch (Exception ex)
            {
                // LOG: Registra o erro que veio do DAO (que também loga internamente)
                LogManager.WriteLog(ex.Message, "Erro durante o cadastro de usuário capturado em FormCadastroUsuario para o login: {login}");
                // A mensagem de erro específica já foi mostrada pelo DAO, apenas limpamos o formulário se necessário
            }
        }


    }
}