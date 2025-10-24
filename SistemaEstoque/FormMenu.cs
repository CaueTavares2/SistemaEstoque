using System;
using System.Windows.Forms;
using SistemaEstoque.DAO; // Importante para acessar o ProdutoDAO

namespace SistemaEstoque
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            // O InitializeComponent() inicializa o lblAlertaEstoque.
            // A verificação deve vir APÓS esta chamada!
            VerificarEstoqueBaixo();
        }

        private void VerificarEstoqueBaixo()
        {
            ProdutoDAO dao = new ProdutoDAO();
            try
            {
                // Verifica quantos produtos estão com estoque baixo (Usando o método que criamos)
                int totalBaixo = dao.ContarProdutosBaixoEstoque();

                if (totalBaixo > 0)
                {
                    this.lblAlertaEstoque.Text = $"ATENÇÃO! {totalBaixo} produto(s) com estoque baixo!";
                    this.lblAlertaEstoque.ForeColor = System.Drawing.Color.Red;
                    this.lblAlertaEstoque.Visible = true; // Torna o Label visível
                }
                else
                {
                    // Garante que esteja oculto se não houver alerta
                    this.lblAlertaEstoque.Visible = false;
                }
            }
            catch (Exception ex)
            {
                // Em caso de falha de conexão ou erro no DAO, exibe o problema no Label.
                this.lblAlertaEstoque.Text = "ERRO: Falha ao checar estoque (Verifique o Banco de Dados).";
                this.lblAlertaEstoque.ForeColor = System.Drawing.Color.OrangeRed;
                this.lblAlertaEstoque.Visible = true;

                // Opcional: Logar o erro no arquivo (se você quiser logar o erro no sistema_estoque_log.txt)
                // SistemaEstoque.Utils.Logger.LogError("Falha ao checar estoque no FormMenu.", ex);
            }
        }

        // ... (Mantenha o resto dos seus métodos Click)
        private void btnCadastro_Click(object sender, EventArgs e) { new FormCadastro().ShowDialog(); }

        private void btnListagem_Click(object sender, EventArgs e) { new FormListagem().ShowDialog(); }

        private void btnSaida_Click(object sender, EventArgs e) { new FormSaida().ShowDialog(); }

        private void btnRelatorio_Click(object sender, EventArgs e) { new FormRelatorio().ShowDialog(); }

        private void btnSairMenu_Click(object sender, EventArgs e) { this.Close(); }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            new FormCadastroUsuario().ShowDialog();
        }
    }
}