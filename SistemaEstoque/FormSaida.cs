using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using System.Collections.Generic; // Necessário se a versão anterior do FormSaida usava

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

            // O ObterTodos retorna uma lista de objetos Produto.
            cmbProduto.DataSource = dao.ObterTodos();

            // Define o que será exibido (o nome) e o que será o valor real (o ID)
            cmbProduto.DisplayMember = "Nome";
            cmbProduto.ValueMember = "Id";
        }

        // REMOVIDO: O método btnRegistrarSaida_Click agora está vazio ou deve ser excluído se não estiver ligado a um botão.
        // Se este método estiver ligado ao botão, APAGUE o método vazio abaixo e RENOMEIE este para btnConfirmar_Click.

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // 1. Validação e obtenção de dados
            if (cmbProduto.SelectedValue == null)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            // Obtém o objeto Produto completo para pegar o preço de venda e verificar o estoque
            Produto produtoSelecionado = cmbProduto.SelectedItem as Produto;

            // O ID e a Quantidade são obtidos dos componentes
            int idProduto = (int)cmbProduto.SelectedValue;
            int quantidade = (int)nudSaida.Value; // O NumericUpDown é 'nudSaida' 
            decimal precoVenda = produtoSelecionado?.Preco ?? 0;

            //
            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.");
                return;
            }

            // Adiciona a verificação de estoque [cite: 529]
            if (quantidade > produtoSelecionado.Quantidade)
            {
                MessageBox.Show("Estoque insuficiente.");
                return;
            }

            if (precoVenda <= 0)
            {
                MessageBox.Show("Não foi possível obter o preço de venda do produto.");
                return;
            }

            // 2. Execução da transação
            MovimentacaoDAO dao = new MovimentacaoDAO();

            try
            {
                dao.RegistrarSaida(idProduto, quantidade, precoVenda);

                MessageBox.Show($"Saída de {quantidade} unidades de '{produtoSelecionado.Nome}' registrada com sucesso!");
                nudSaida.Value = 1; // Reseta o campo de quantidade [cite: 535]

                CarregarProdutos(); // Recarrega para atualizar a quantidade em estoque [cite: 535]
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar saída: " + ex.Message);
            }
        }

        

        // Remove ou renomeie o método btnRegistrarSaida_Click se ele não estiver associado ao botão.
    }
}