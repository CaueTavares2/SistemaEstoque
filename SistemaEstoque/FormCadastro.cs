using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
namespace SistemaEstoque
{
    public partial class FormCadastro : Form
    {
        private Produto produtoEditando;

        // Construtor padrão (para novo cadastro)
        public FormCadastro()
        {
            InitializeComponent();
            PreencherCategorias();
        }

        // Construtor para EDIÇÃO
        public FormCadastro(Produto p) : this()
        {
            produtoEditando = p;
            CarregarProdutoParaEdicao();
        }

        private void PreencherCategorias()
        {
            // Puxa as categorias do banco de dados e popula o ComboBox
            CategoriaDAO dao = new CategoriaDAO();
            cmbCategoria.DataSource = dao.ObterCategorias();
        }

        private void CarregarProdutoParaEdicao()
        {
            // Preenche os campos do formulário com os dados do produto a ser editado
            txtNome.Text = produtoEditando.Nome;
            nudQuantidade.Value = produtoEditando.Quantidade;
            txtPreco.Text = produtoEditando.Preco.ToString("F2");
            cmbCategoria.SelectedItem = produtoEditando.Categoria;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // 1. Validação
            if (string.IsNullOrWhiteSpace(txtNome.Text) || cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }
            if (!decimal.TryParse(txtPreco.Text, out decimal preco))
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            // 2. Criação do objeto Produto
            var p = new Produto
            {
                Nome = txtNome.Text.Trim(),
                Quantidade = (int)nudQuantidade.Value,
                Preco = preco,
                Categoria = cmbCategoria.SelectedItem.ToString()
            };

            ProdutoDAO dao = new ProdutoDAO();
            // Atenção: Aqui assumimos que o ID da categoria no banco é o índice + 1
            int idCategoria = cmbCategoria.SelectedIndex + 1;

            try
            {
                if (produtoEditando == null) // Inserindo novo
                {
                    dao.Inserir(p, idCategoria);
                    MessageBox.Show("Produto salvo com sucesso!");
                    LimparCampos();
                }
                else // Atualizando existente
                {
                    p.Id = produtoEditando.Id; // Mantém o ID original
                    dao.Atualizar(p, idCategoria);
                    MessageBox.Show("Produto atualizado!");
                    this.Close(); // Fecha a tela após a edição
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            nudQuantidade.Value = 1;
            txtPreco.Clear();
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
        }

        private void btnLimpar_Click(object sender, EventArgs e) { LimparCampos(); }


    }
}