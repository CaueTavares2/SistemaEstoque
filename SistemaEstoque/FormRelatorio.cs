using System;
using System.Data;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Utils; // NOVO: Importa o Logger
using MySqlConnector;

namespace SistemaEstoque
{
    public partial class FormRelatorio : Form
    {
        public FormRelatorio()
        {
            InitializeComponent();
            GerarRelatorio(); // Gera o relatório ao carregar a tela
        }

        /// <summary>
        /// Gera dois relatórios: Estoque Baixo e Valor Total em Estoque.
        /// Utiliza try-catch e logging para capturar erros de BD.
        /// </summary>
        private void GerarRelatorio()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // 1. Relatório: Produtos com estoque baixo 
                    // (quantidade abaixo do estoque mínimo)
                    string sqlBaixo = @"
                        SELECT 
                            p.nome_produto, 
                            p.quantidade, 
                            p.estoque_minimo, 
                            p.preco_venda 
                        FROM produto p
                        WHERE p.quantidade < p.estoque_minimo
                        ORDER BY p.quantidade ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sqlBaixo, conn);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgvRelatorio.DataSource = dt;
                    lblTituloRelatorio.Text = $"Produtos com Estoque Baixo ({dt.Rows.Count} itens):";


                    // 2. Relatório: Valor total em estoque (Soma de: Quantidade * Preço de Venda) 
                    string sqlTotal = "SELECT SUM(quantidade * preco_venda) AS total FROM produto";
                    MySqlCommand cmd = new MySqlCommand(sqlTotal, conn);

                    object result = cmd.ExecuteScalar();

                    // Trata o resultado, caso seja nulo (inventário vazio) 
                    decimal total = (result != DBNull.Value && result != null) ? Convert.ToDecimal(result) : 0;

                    // Exibe o valor total no Label formatado como moeda
                    lblValorTotal.Text = $"Valor total em estoque: {total:C2}";

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Loga o erro e exibe uma mensagem amigável ao usuário.
                Logger.LogError("Erro capturado no FormRelatorio ao gerar relatórios de estoque.", ex);
                MessageBox.Show("Erro ao gerar o relatório. Verifique o log de erros para detalhes.", "Erro de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvRelatorio.DataSource = null; // Limpa o grid em caso de falha
                lblValorTotal.Text = "Valor total em estoque: R$ 0,00"; // Reseta o label
                lblTituloRelatorio.Text = "Não foi possível carregar os produtos em estoque baixo.";
            }
        }

        private void btnAtualizarRel_Click(object sender, EventArgs e)
        {
            // Recarrega o relatório
            GerarRelatorio();
        }
    }
}