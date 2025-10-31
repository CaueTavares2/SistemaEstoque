using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
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

            AcessibilidadeGlobal.CarregarConfiguracoesUsuario(UserSession.IdUsuario);
            AcessibilidadeGlobal.AplicarConfiguracoes(this);
        }

        private void btnAcessibilidade_Click(object sender, EventArgs e)
        {
            using (var formAcessibilidade = new FormAcessibilidade())
            {
                formAcessibilidade.ShowDialog();

                // Recarrega e aplica as configurações após fechar o form
                AcessibilidadeGlobal.CarregarConfiguracoesUsuario(UserSession.IdUsuario);
                AcessibilidadeGlobal.AplicarConfiguracoes(this);
            }
        }

        private void VerificarPermissoes()
        {
            // Permissões mais específicas
            if (UserSession.NivelAcesso != "Admin")
            {
                var btnUser = this.Controls.Find("btnCadastroUsuario", true);
                if (btnUser.Length > 0 && btnUser[0] is Button btn)
                {
                    btn.Enabled = false;
                    btn.Text = "Cadastro Usuário (Restrito)";
                    btn.BackColor = System.Drawing.Color.LightGray;
                }

                // Exemplo: Operador não pode excluir produtos
                var btnExcluir = this.Controls.Find("btnExcluir", true);
                if (btnExcluir.Length > 0 && btnExcluir[0] is Button btnExcl)
                {
                    btnExcl.Enabled = false;
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