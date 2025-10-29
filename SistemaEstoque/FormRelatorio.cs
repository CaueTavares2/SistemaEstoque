// Arquivo: FormRelatorio.cs (CÓDIGO PRINCIPAL)

using System;
using System.Windows.Forms;
// Adicione 'usings' necessários, como para a camada DAO/Model

namespace SistemaEstoque
{
    public partial class FormRelatorio : Form
    {
        public FormRelatorio()
        {
            InitializeComponent();
        }

        // 1. Método requerido pelo Designer (Erro CS1061)
        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            // Lógica a ser executada quando o formulário é carregado.
            // É comum chamar o método de atualização aqui para mostrar dados iniciais.
            btnAtualizarRel_Click(sender, e);
        }

        // 2. Método requerido pelo Designer (Erro CS1061)
        private void btnFechar_Click(object sender, EventArgs e)
        {
            // Ação: Fechar o formulário de relatório.
            this.Close();
        }

        // 3. Método para gerar/atualizar o relatório
        private void btnAtualizarRel_Click(object sender, EventArgs e)
        {
            // **********************************************
            // COLOQUE AQUI SUA LÓGICA DE NEGÓCIO:
            // 1. Chamar o método na sua DAO que busca o relatório de estoque crítico.
            // 2. Atribuir os dados retornados ao dgvRelatorio.DataSource.
            // 3. Calcular e atualizar o lblValorTotal.
            // **********************************************

            // Exemplo de como você atualizaria o label de total:
            // double valorTotalCalculado = 1250.75; 
            // int itensEmFalta = 15;
            // lblValorTotal.Text = $"Total de itens em falta: {itensEmFalta} (R$ {valorTotalCalculado:N2})";
        }
    }
}