using System;
using System.Windows.Forms;
using SistemaEstoque.DAO; // Importante para acessar o ProdutoDAO
using SistemaEstoque.Classes;

namespace SistemaEstoque
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            VerificarPermissoes();
            VerificarEstoqueBaixo();
        }

        private void VerificarPermissoes()
        {
            // Restrição: Apenas o 'Admin' pode acessar o cadastro de usuários.
            if (UserSession.NivelAcesso != "Admin")
            {
                // Verifica se o componente 'btnCadastroUsuario' existe e o desabilita
                var btnUser = this.Controls.Find("btnCadastroUsuario", true);
                if (btnUser.Length > 0 && btnUser[0] is Button btn)
                {
                    btn.Enabled = false;
                    btn.Text = "Cadastro Usuário (Restrito)";
                    btn.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }


        private void VerificarEstoqueBaixo()
        {
            ProdutoDAO dao = new ProdutoDAO();
            var produtosBaixoEstoque = dao.ObterProdutosComEstoqueBaixo();

            if (produtosBaixoEstoque.Count > 0)
            {
                string mensagem = "ATENÇÃO! Os seguintes produtos estão com estoque abaixo do mínimo:\n\n";
                foreach (var p in produtosBaixoEstoque)
                {
                    mensagem += $"- {p.Nome} (Estoque atual: {p.Quantidade})\n";
                }

                // Este é o popup que aparece logo após o login e o 'Bem Vindo'.
                MessageBox.Show(mensagem, "Alerta de Estoque Baixo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Métodos de botões (Mantenha conforme seu layout)
        private void btnCadastro_Click(object sender, EventArgs e) { new FormCadastro().ShowDialog(); }

        private void btnListagem_Click(object sender, EventArgs e) { new FormListagem().ShowDialog(); }

        private void btnSaida_Click(object sender, EventArgs e) { new FormSaida().ShowDialog(); }

        private void btnRelatorio_Click(object sender, EventArgs e) { new FormRelatorio().ShowDialog(); }

        private void btnSairMenu_Click(object sender, EventArgs e) { this.Close(); }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            new FormCadastroUsuario().ShowDialog();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            // Abre o novo formulário de Fornecedores
            new FormFornecedor().ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
    }
}