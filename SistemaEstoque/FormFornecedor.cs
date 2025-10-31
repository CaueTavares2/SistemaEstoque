// Arquivo: FormFornecedor.cs (CÓDIGO COMPLETO E ATUALIZADO)

using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using System.Linq;
using SistemaEstoque.Utils;

namespace SistemaEstoque
{
    public partial class FormFornecedor : Form
    {
        private FornecedorDAO dao = new FornecedorDAO();
        private int fornecedorIdSelecionado = 0;

        public FormFornecedor()
        {
            InitializeComponent();
            CarregarFornecedores();
            LimparCampos();
        }

        // ------------------------------------------
        // LÓGICA DE DADOS
        // ------------------------------------------
        private void CarregarFornecedores()
        {
            try
            {
                dgvFornecedores.DataSource = dao.ObterTodos();

                if (dgvFornecedores.Columns.Count > 0)
                {
                    dgvFornecedores.Columns["Id"].Visible = false;
                    dgvFornecedores.Columns["RazaoSocial"].HeaderText = "Razão Social";
                    dgvFornecedores.Columns["Cnpj"].HeaderText = "CNPJ";
                    dgvFornecedores.Columns["NomeFantasia"].HeaderText = "Nome Fantasia";
                    dgvFornecedores.Columns["Email"].HeaderText = "E-mail";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Opcional: definir DataSource nulo em caso de erro
                dgvFornecedores.DataSource = null;
            }
        }

        private void LimparCampos()
        {
            txtRazaoSocial.Clear();
            txtCnpj.Clear(); // MaskedTextBox limpa automaticamente
            txtNomeFantasia.Clear();
            txtEmail.Clear();
            btnSalvar.Text = "Inserir";
            btnExcluir.Enabled = false;
            fornecedorIdSelecionado = 0;
            txtRazaoSocial.Focus();
        }

        private void CarregarCamposEdicao(DataGridViewRow row)
        {
            fornecedorIdSelecionado = Convert.ToInt32(row.Cells["Id"].Value);
            txtRazaoSocial.Text = row.Cells["RazaoSocial"].Value.ToString();
            // IMPORTANTE: Para MaskedTextBox, lemos a propriedade Text
            txtCnpj.Text = row.Cells["Cnpj"].Value.ToString();
            txtNomeFantasia.Text = row.Cells["NomeFantasia"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();

            btnSalvar.Text = "Atualizar";
            btnExcluir.Enabled = true;
        }

        private void ValidarFormatoCNPJ()
        {
            if (txtCnpj.MaskCompleted == false)
            {
                throw new Exception("O campo CNPJ está incompleto.");
            }

            // NOVA VALIDAÇÃO: Verifica se o CNPJ é válido
            string cnpjLimpo = ValidacaoHelper.LimparCNPJ(txtCnpj.Text);
            if (!ValidacaoHelper.ValidarCNPJ(cnpjLimpo))
            {
                throw new Exception("CNPJ inválido.");
            }
        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtRazaoSocial.Text) ||
                string.IsNullOrWhiteSpace(txtNomeFantasia.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Razão Social, Nome Fantasia e E-mail são obrigatórios.",
                               "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // NOVA VALIDAÇÃO DE EMAIL
            if (!ValidacaoHelper.ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("E-mail inválido.", "Validação",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                ValidarFormatoCNPJ();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validação",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        // ------------------------------------------
        // EVENTOS DE BOTÃO
        // ------------------------------------------

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Fornecedor f = new Fornecedor
            {
                Id = fornecedorIdSelecionado,
                RazaoSocial = txtRazaoSocial.Text.Trim(),
                Cnpj = txtCnpj.Text,
                NomeFantasia = txtNomeFantasia.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            try
            {
                if (f.Id == 0)
                {
                    dao.Inserir(f);
                    MessageBox.Show("Fornecedor inserido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dao.Atualizar(f);
                    MessageBox.Show("Fornecedor atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CarregarFornecedores();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (fornecedorIdSelecionado == 0) return;

            var resposta = MessageBox.Show($"Deseja realmente excluir o fornecedor '{txtRazaoSocial.Text}'?",
                                          "Confirmação de Exclusão",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                try
                {
                    dao.Excluir(fornecedorIdSelecionado);
                    MessageBox.Show("Fornecedor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarFornecedores();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir o fornecedor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ------------------------------------------
        // EVENTOS DE DATAGRIDVIEW
        // ------------------------------------------

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFornecedores.Rows[e.RowIndex];
                CarregarCamposEdicao(row);
            }
        }

        private void FormFornecedor_Load(object sender, EventArgs e)
        {

        }

        
    }
}