using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Logger;

namespace SistemaEstoque
{
    public partial class FormListagem : Form
    {
        public FormListagem()
        {
            InitializeComponent();
            AtualizarGrid(); // Carrega os dados assim que a tela é aberta
        }

        /// <summary>
        /// Busca todos os produtos e define o resultado como fonte de dados da DataGridView, 
        /// com tratamento de erro e logging.
        /// </summary>
        private void AtualizarGrid()
        {
            ProdutoDAO dao = new ProdutoDAO();
            try
            {
                // Busca todos os produtos e define o resultado como fonte de dados da DataGridView
                dgvProdutos.DataSource = dao.ObterTodos();
            }
            catch (Exception ex)
            {
                // O DAO já logou o erro. Aqui logamos o contexto do Formulário (opcional).
                LogManager.WriteLog(ex.Message, "Erro capturado no FormListagem ao carregar produtos para a grid.");
                MessageBox.Show("Erro ao carregar a lista de produtos. Verifique o log de erros.", "Erro de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvProdutos.DataSource = null; // Limpa o grid em caso de falha
            }
        }

        /// <summary>
        /// Retorna o objeto Produto que está na linha atualmente selecionada.
        /// </summary>
        private Produto GetSelecionado()
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                // Note: O objeto retornado é um objeto Produto do data source
                return dgvProdutos.SelectedRows[0].DataBoundItem as Produto;
            }
            return null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var p = GetSelecionado();
            if (p == null)
            {
                MessageBox.Show("Selecione um produto para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
            if (p == null)
            {
                MessageBox.Show("Selecione um produto para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Pede confirmação antes de excluir
            if (MessageBox.Show($"Tem certeza que deseja excluir '{p.Nome}' (ID: {p.Id})? Todas as movimentações relacionadas também serão excluídas.",
                                "Confirmação de Exclusão",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProdutoDAO dao = new ProdutoDAO();
                try
                {
                    dao.Excluir(p.Id); // Chama o método de exclusão
                    MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarGrid();
                }
                catch (Exception ex)
                {
                    // O DAO já logou o erro detalhado.
                    LogManager.WriteLog(ex.Message, "Erro capturado no FormListagem ao excluir produto ID: {p.Id}.");
                    MessageBox.Show("Erro ao excluir o produto. Verifique o log de erros para detalhes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        // Adiciona tratamento de clique duplo para edição
        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se o clique não foi no cabeçalho
            {
                // Chama o método de edição
                btnEditar_Click(sender, e);
            }
        }
    }
}