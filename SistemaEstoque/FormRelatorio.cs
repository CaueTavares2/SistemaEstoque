// Arquivo: FormRelatorio.cs (COMPLETO)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaEstoque.DAO;
// Ajuste o namespace abaixo se a classe Produto não estiver em SistemaEstoque.Classes
using Produto = SistemaEstoque;

namespace SistemaEstoque
{
    public partial class FormRelatorio : Form
    {
        public FormRelatorio()
        {
            InitializeComponent();
        }

        // Chamado no carregamento inicial para exibir os dados (CORREÇÃO APLICADA AQUI)
        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            // O carregamento inicial apenas chama o método de atualização
            AtualizarDadosRelatorio();
        }

        // Lógica para o botão Atualizar
        private void btnAtualizarRel_Click(object sender, EventArgs e)
        {
            AtualizarDadosRelatorio();
        }

        // Lógica central para gerar/atualizar o relatório
        private void AtualizarDadosRelatorio()
        {
            try
            {
                ProdutoDAO produtoDAO = new ProdutoDAO();

                // CHAVE DA CORREÇÃO: Usa o método específico para o relatório de estoque crítico
                List<Produto> listaCritica = produtoDAO.ObterProdutosComEstoqueBaixo(); //

                // 3. Vincule a lista à DataGridView
                dgvRelatorio.DataSource = listaCritica;

                // 4. Cálculo e exibição do sumário
                int itensEmFalta = listaCritica.Count;
                decimal valorTotalEmEstoqueCritico = 0;

                // Cálculo do valor total
                foreach (var item in listaCritica)
                {
                    // Usa as propriedades Quantidade e Preco do objeto Produto
                    valorTotalEmEstoqueCritico += (item.Quantidade * item.Preco);
                }

                lblValorTotal.Text = $"Total de itens críticos: {itensEmFalta} (Valor em estoque: R$ {valorTotalEmEstoqueCritico:N2})";

                if (itensEmFalta == 0)
                {
                    // Limpa a DGV se não houver dados
                    dgvRelatorio.DataSource = null;
                    MessageBox.Show("Nenhum produto com estoque crítico encontrado.", "Relatório Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório. Verifique a query SQL no ProdutoDAO. Detalhe: {ex.Message}", "Erro de Relatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}