using System;
using System.Data;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using MySqlConnector; // Necessário para MySqlConnection e MySqlDataAdapter

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

                    // Relatório 1: Produtos com estoque baixo (quantidade abaixo do estoque mínimo) [cite: 570, 571]
                    string sqlBaixo = "SELECT nome_produto, quantidade, estoque_minimo, preco_venda FROM produto WHERE quantidade < estoque_minimo";
                    
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlBaixo, conn);
                    DataTable dt = new DataTable();
                    
                    da.Fill(dt);
                    dgvRelatorio.DataSource = dt;

                    // Relatório 2: Valor total em estoque (Soma de: Quantidade * Preço de Venda) 
                    string sqlTotal = "SELECT SUM(quantidade * preco_venda) AS total FROM produto";
                    MySqlCommand cmd = new MySqlCommand(sqlTotal, conn);
                    
                    object result = cmd.ExecuteScalar();
                    
                    // Trata o resultado, caso seja nulo (inventário vazio) 
                    decimal total = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    
                    // Exibe o valor total no Label formatado como moeda [cite: 581]
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
    }
}