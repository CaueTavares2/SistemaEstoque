// Arquivo: FormSaida.cs (CÓDIGO PRINCIPAL)

using System;
using System.Windows.Forms;
// Adicione 'usings' necessários, como para a camada DAO/Model

namespace SistemaEstoque
{
    public partial class FormSaida : Form
    {
        public FormSaida()
        {
            InitializeComponent();
        }

        // 1. Método requerido pelo Designer (LOAD)
        private void FormSaida_Load(object sender, EventArgs e)
        {
            // Lógica para carregar os produtos no ComboBox (cmbProduto)
            // Exemplo: CarregarProdutosNoCombo();
        }

        // 2. Método requerido pelo Designer (btnConfirmar)
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // **********************************************
            // COLOQUE AQUI SUA LÓGICA DE NEGÓCIO:
            // 1. Obter o produto selecionado (cmbProduto.SelectedValue).
            // 2. Obter a quantidade (nudSaida.Value).
            // 3. Chamar a DAO para registrar a saída e atualizar o estoque.
            // 4. Exibir mensagem de sucesso/erro e fechar o formulário.
            // **********************************************
        }

        // 3. Método requerido pelo Designer (btnFechar)
        private void btnFechar_Click(object sender, EventArgs e)
        {
            // Ação: Fechar o formulário de Saída.
            this.Close();
        }

        // Métodos auxiliares (se precisar):
        /*
        private void CarregarProdutosNoCombo()
        {
             // Implemente o DAO para buscar produtos
             // cmbProduto.DisplayMember = "Nome";
             // cmbProduto.ValueMember = "ID";
             // cmbProduto.DataSource = listaDeProdutos;
        }
        */
    }
}