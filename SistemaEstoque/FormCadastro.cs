using System;
using System.Windows.Forms;
using SistemaEstoque.DAO;
using SistemaEstoque.Logger;


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

        
        public FormCadastro(Produto p) : this()
        {
            produtoEditando = p;
            CarregarProdutoParaEdicao();
        }

        private void PreencherCategorias()
        {
            // Puxa as categorias do banco de dados e popula o ComboBox
            CategoriaDAO dao = new CategoriaDAO();
            try
            {
                cmbCategoria.DataSource = dao.ObterCategorias();
            }
            catch (Exception ex)
            {
                // O DAO já logou o erro. Aqui logamos o contexto do Formulário (opcional, mas bom).
                LogManager.WriteLog(ex.Message, "Erro capturado no FormCadastro ao carregar categorias.");
                MessageBox.Show("Erro ao carregar categorias. Verifique o log de erros.", "Erro de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Opcional: Desabilitar botões se a falha for crítica (ex: falha de conexão).
            }
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
            // 1. Validação de campos obrigatórios
            if (string.IsNullOrWhiteSpace(txtNome.Text) || cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Nome e Categoria são campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validação e conversão de preço
            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                MessageBox.Show("Preço de venda inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Criação/Atualização do Objeto Produto
            var p = new Produto
            {
                Nome = txtNome.Text.Trim(),
                Quantidade = (int)nudQuantidade.Value,
                Preco = preco,
                Categoria = cmbCategoria.SelectedItem.ToString()
            };

            ProdutoDAO dao = new ProdutoDAO();
            // Atenção: Aqui assumimos que o ID da categoria no banco é o índice + 1
            // (Isso é uma prática comum quando a listagem retorna nomes na ordem do ID 1, 2, 3...)
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
            catch (Exception ex) // Captura qualquer erro do DAO (que já logou o erro detalhado)
            {
                // Loga o erro no contexto do formulário e exibe uma mensagem amigável ao usuário.
                LogManager.WriteLog(ex.Message, "Erro capturado no FormCadastro ao tentar salvar/atualizar o produto {p.Nome}.");
                MessageBox.Show("Erro ao salvar o produto. Verifique o log de erros para detalhes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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