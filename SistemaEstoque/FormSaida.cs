// Arquivo: FormSaida.cs (CORRIGIDO)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaEstoque.DAO;
// Ajuste o namespace abaixo se a classe Produto não estiver em SistemaEstoque.Classes
using Produto = SistemaEstoque;

using SistemaEstoque.Classes; // Para UserSession (necessário para MovimentacaoDAO)

namespace SistemaEstoque
{
    public partial class FormSaida : Form
    {
        public FormSaida()
        {
            InitializeComponent();
        }

        // Método de evento disparado quando o formulário é carregado (CORREÇÃO APLICADA AQUI)
        private void FormSaida_Load(object sender, EventArgs e)
        {
            CarregarProdutosNoComboBox();
        }

        private void CarregarProdutosNoComboBox()
        {
            try
            {
                // INSTANCIA A SUA CLASSE DE ACESSO A DADOS
                ProdutoDAO produtoDAO = new ProdutoDAO();

                // CHAVE DA CORREÇÃO: Usa o método ObterTodos() da ProdutoDAO, que sabemos que funciona.
                List<Produto> listaProdutos = produtoDAO.ObterTodos(); //

                if (listaProdutos != null && listaProdutos.Count > 0)
                {
                    cmbProduto.DataSource = listaProdutos;

                    // Configurações baseadas no seu Produto.cs
                    cmbProduto.DisplayMember = "Nome"; // Propriedade Nome do Produto
                    cmbProduto.ValueMember = "Id";     // Propriedade Id do Produto

                    cmbProduto.SelectedIndex = -1; // Sem seleção inicial
                }
                else
                {
                    MessageBox.Show("Nenhum produto cadastrado para registrar saída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConfirmar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos para a saída. Verifique a conexão com o banco de dados. Detalhe: {ex.Message}", "Erro de Carregamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConfirmar.Enabled = false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedValue == null)
            {
                MessageBox.Show("Selecione um produto para registrar a saída.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtém o objeto Produto completo selecionado
            Produto produtoSelecionado = cmbProduto.SelectedItem as Produto;

            if (produtoSelecionado == null) return;

            int idProduto = produtoSelecionado.Id;
            int quantidade = (int)nudSaida.Value;
            decimal precoVenda = produtoSelecionado.Preco; // Necessário para MovimentacaoDAO

            // Validação de estoque (Se a quantidade for maior que o estoque atual)
            if (quantidade > produtoSelecionado.Quantidade)
            {
                MessageBox.Show($"Estoque insuficiente! Máximo disponível: {produtoSelecionado.Quantidade}.", "Erro de Estoque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MovimentacaoDAO movimentacaoDAO = new MovimentacaoDAO();
                // Chama o DAO para registrar a saída (ID, Quantidade, Preço)
                movimentacaoDAO.RegistrarSaida(idProduto, quantidade, precoVenda); //

                MessageBox.Show($"Saída de {quantidade} unidades de '{produtoSelecionado.Nome}' registrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                // Captura a exceção interna do DAO se houver rollback
                MessageBox.Show($"Falha ao registrar a saída. Detalhes: {ex.InnerException?.Message ?? ex.Message}", "Erro de Transação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}