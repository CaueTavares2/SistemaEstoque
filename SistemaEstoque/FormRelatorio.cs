using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using SistemaEstoque.DAO; // Necessário para acessar o Database.GetConnection

namespace SistemaEstoque
{
    public partial class FormRelatorio : Form
    {
        public FormRelatorio()
        {
            InitializeComponent();
            GerarRelatorio(); // Gera o relatório ao carregar a tela
        }

        private void GerarRelatorio()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Relatório 1: Produtos com Estoque Baixo (Quantidade < Estoque Mínimo)
                    string sqlBaixo = "SELECT idproduto, nome_produto, quantidade, estoque_minimo, preco_venda FROM produto WHERE quantidade < estoque_minimo";

                    MySqlDataAdapter da = new MySqlDataAdapter(sqlBaixo, conn);
                    DataTable dt = new DataTable();

                    // Preenche o DataTable com os resultados da query
                    da.Fill(dt);

                    // Define o DataTable como fonte de dados da DataGridView
                    dgvRelatorio.DataSource = dt;

                    // Relatório 2: Valor total em estoque (Soma de: Quantidade * Preço de Venda)
                    string sqlTotal = "SELECT SUM(quantidade * preco_venda) AS total FROM produto";
                    MySqlCommand cmd = new MySqlCommand(sqlTotal, conn);

                    object result = cmd.ExecuteScalar();

                    // Trata o resultado, caso seja nulo (estoque vazio)
                    decimal total = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                    // Exibe o valor total em um Label formatado como moeda
                    // Assumindo que você tem um Label chamado lblValorTotal na sua tela
                    lblValorTotal.Text = $"Valor total em estoque: {total:C2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar relatório: " + ex.Message);
            }
        }

        private void btnAtualizarRel_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        private void lblValorTotal_Click(object sender, EventArgs e)
        {

        }

        private void lblTituloRelatorio_Click(object sender, EventArgs e)
        {

        }
    }
}