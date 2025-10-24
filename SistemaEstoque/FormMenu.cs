using System;
using System.Windows.Forms;
namespace SistemaEstoque
{
    public partial class FormMenu : Form
    {
        public FormMenu() { InitializeComponent(); }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            using (var f = new FormCadastro())
            {
                f.ShowDialog();
            }
        }

        private void btnListagem_Click(object sender, EventArgs e)
        {
            using (var f = new FormListagem())
            {
                f.ShowDialog();
            }
        }


        private void btnSaida_Click(object sender, EventArgs e)
        {
            using (var f = new FormSaida())
            {
                f.ShowDialog();

            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e) 
        { 
            using (var f = new FormRelatorio())
            {
                f.ShowDialog();
            } }

        private void btnSairMenu_Click(object sender, EventArgs e) 
        { Application.Exit();}

        private void btnCadastroUsuario_Click(object sender, EventArgs e)
        {
            // Abre a nova tela de cadastro de usuários
            new FormCadastroUsuario().ShowDialog();
        }
    }
}