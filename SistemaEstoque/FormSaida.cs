using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
namespace SistemaEstoque
{
    public partial class FormSaida : Form
    {
        public FormSaida()
        {
            InitializeComponent();
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            // Carrega a lista de produtos existentes no ComboBox
            ProdutoDAO dao = new ProdutoDAO();
            cmbProduto.DataSource = dao.ObterTodos();
            cmbProduto.DisplayMember = "Nome"; // Exibe o nome do produto
            cmbProduto.ValueMember = "Id"; // Usa o Id do produto como valor interno
        }

        private void btnRegistrarSaida_Click(object sender, EventArgs e)
        {
            // 1. Validação e obtenção de dados
            if (cmbProduto.SelectedValue == null)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            int idProduto = (int)cmbProduto.SelectedValue;
            int quantidade = (int)nudSaida.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.");
                return;
            }

            // Busca o preço atual do produto para registrar na movimentação
            // NOTE: Isso exige que ObterTodos() retorne um objeto Produto com o preço,
            // ou que você implemente um método ObterProdutoPorId() no ProdutoDAO.
            // Para simplificar, vamos assumir que o preço está disponível na lista carregada.
            Produto produtoSelecionado = cmbProduto.SelectedItem as Produto;
            decimal precoVenda = produtoSelecionado?.Preco ?? 0; // Preço do produto no momento da saída

            if (precoVenda <= 0)
            {
                MessageBox.Show("Não foi possível obter o preço de venda do produto.");
                return;
            }

            // 2. Execução da transação (Atualização de estoque + Registro de Movimentação)
            MovimentacaoDAO dao = new MovimentacaoDAO();

            try
            {
                // A MovimentacaoDAO.RegistrarSaida executa a transação no banco.
                dao.RegistrarSaida(idProduto, quantidade, precoVenda);

                MessageBox.Show($"Saída de {quantidade} unidades de '{produtoSelecionado.Nome}' registrada com sucesso!");
                nudSaida.Value = 1; // Limpa/reseta o campo

                // Recarrega a lista se for necessário mostrar o estoque atualizado
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                // Este erro geralmente indica falha na transação ou quantidade insuficiente (a depender da sua regra de negócio SQL)
                MessageBox.Show("Erro ao registrar saída: " + ex.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}