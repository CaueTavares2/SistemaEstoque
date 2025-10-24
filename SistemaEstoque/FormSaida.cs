using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Utils; // Importa o Logger
using System.Collections.Generic; // Necessário para List<Produto>

namespace SistemaEstoque
{
    public partial class FormSaida : Form
    {
        public FormSaida()
        {
            InitializeComponent();
            CarregarProdutos(); // Carrega produtos no ComboBox ao iniciar o form
        }

        /// <summary>
        /// Carrega todos os produtos disponíveis no ComboBox.
        /// Inclui tratamento de erro com logging.
        /// </summary>
        private void CarregarProdutos()
        {
            ProdutoDAO dao = new ProdutoDAO();
            try
            {
                // Carrega a lista de produtos existentes no ComboBox
                List<Produto> produtos = dao.ObterTodos();

                // Define a fonte de dados
                cmbProduto.DataSource = produtos;

                // Define o que será exibido (o nome) e o que será o valor real (o objeto Produto)
                cmbProduto.DisplayMember = "Nome";
                cmbProduto.ValueMember = "Id"; // A propriedade que será usada como valor

                // Configuração inicial
                if (cmbProduto.Items.Count > 0)
                {
                    cmbProduto.SelectedIndex = 0;
                    nudSaida.Value = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Erro capturado no FormSaida ao carregar produtos para o ComboBox.", ex);
                MessageBox.Show("Erro ao carregar a lista de produtos. Verifique o log de erros.", "Erro de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProduto.DataSource = null;
            }
        }

        /// <summary>
        /// Registra a saída do produto no estoque.
        /// Inclui validações de estoque e tratamento de erro com logging.
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // 1. Validação e obtenção de dados
            Produto produtoSelecionado = cmbProduto.SelectedItem as Produto;
            int quantidade = (int)nudSaida.Value;

            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProduto = produtoSelecionado.Id;
            decimal precoVenda = produtoSelecionado.Preco; // Pega o preço do objeto

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CRÍTICO: Adiciona a verificação de estoque
            if (quantidade > produtoSelecionado.Quantidade)
            {
                MessageBox.Show($"Estoque insuficiente. Em estoque: {produtoSelecionado.Quantidade} unidades.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Execução da transação
            MovimentacaoDAO dao = new MovimentacaoDAO();

            try
            {
                // O DAO se encarregará de atualizar o estoque e inserir o registro de movimentação em uma transação.
                dao.RegistrarSaida(idProduto, quantidade, precoVenda);

                MessageBox.Show($"Saída de {quantidade} unidades de '{produtoSelecionado.Nome}' registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nudSaida.Value = 1; // Reseta o campo de quantidade
                CarregarProdutos(); // Recarrega para atualizar a lista (e a quantidade em estoque)
            }
            catch (Exception ex)
            {
                // O DAO já logou o erro detalhado.
                Logger.LogError($"Erro capturado no FormSaida ao tentar registrar saída do produto ID: {idProduto}.", ex);
                MessageBox.Show("Erro ao registrar a saída. Verifique o log de erros para detalhes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}