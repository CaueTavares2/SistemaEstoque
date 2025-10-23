using System;
using System.Windows.Forms;
namespace SistemaEstoque
{
    public partial class FormMenu : Form
    {
        public FormMenu() { InitializeComponent(); }

        private void btnCadastro_Click(object sender, EventArgs e) { new FormCadastro().ShowDialog(); }

        private void btnListagem_Click(object sender, EventArgs e) { new FormListagem().ShowDialog(); }

        private void btnSaida_Click(object sender, EventArgs e) { new FormSaida().ShowDialog(); }

        private void btnRelatorio_Click(object sender, EventArgs e) { new FormRelatorio().ShowDialog(); }

        private void btnSairMenu_Click(object sender, EventArgs e) { this.Close(); }

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            // Abre a nova tela de cadastro de usuários
            new FormCadastroUsuario().ShowDialog();
        }
    }
}