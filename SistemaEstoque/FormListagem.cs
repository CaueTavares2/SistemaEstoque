using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
namespace SistemaEstoque
{
    public partial class FormListagem : Form
    {
        public FormListagem()
        {
            InitializeComponent();
            AtualizarGrid(); // Carrega os dados assim que a tela é aberta
        }

        private void AtualizarGrid()
        {
            // Busca todos os produtos e define o resultado como fonte de dados da DataGridView
            ProdutoDAO dao = new ProdutoDAO();
            dgvProdutos.DataSource = dao.ObterTodos();
        }

        private Produto GetSelecionado()
        {
            // Retorna o objeto Produto que está na linha atualmente selecionada
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                return dgvProdutos.SelectedRows[0].DataBoundItem as Produto;
            }
            return null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var p = GetSelecionado();
            if (p == null) { MessageBox.Show("Selecione um produto."); return; }

            // Abre a tela de cadastro/edição, passando o produto selecionado
            using (var f = new FormCadastro(p))
            {
                f.ShowDialog();
            }
            // Atualiza a lista após a edição
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var p = GetSelecionado();
            if (p == null) { MessageBox.Show("Selecione um produto."); return; }

            // Pede confirmação antes de excluir
            if (MessageBox.Show($"Tem certeza que deseja excluir {p.Nome}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProdutoDAO dao = new ProdutoDAO();
                dao.Excluir(p.Id); // Chama o método de exclusão (que também remove movimentações relacionadas)
                AtualizarGrid();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e) { AtualizarGrid(); }

        
    }
}