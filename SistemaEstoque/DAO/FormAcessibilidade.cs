using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaEstoque.Classes;
using SistemaEstoque.DAO;

namespace SistemaEstoque
{
    public partial class FormAcessibilidade : Form
    {
        private ConfigAcessibilidadeDAO configDAO;
        private ConfigAcessibilidade configAtual;

        public FormAcessibilidade()
        {
            InitializeComponent();
            configDAO = new ConfigAcessibilidadeDAO();
            configAtual = new ConfigAcessibilidade();
        }

        private void FormAcessibilidade_Load(object sender, EventArgs e)
        {
            CarregarConfiguracoes();
            AplicarPrevisualizacao();
        }

        private void CarregarConfiguracoes()
        {
            if (UserSession.IdUsuario == 0)
            {
                MessageBox.Show("Nenhum usuário logado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                configAtual = configDAO.ObterConfiguracao(UserSession.IdUsuario);

                chkTemaEscuro.Checked = configAtual.TemaEscuro;
                chkAltoContraste.Checked = configAtual.AltoContraste;
                chkLeitorTela.Checked = configAtual.LeitorTela;
                chkNavegacaoTeclado.Checked = configAtual.NavegacaoTeclado;
                chkDescricaoImagens.Checked = configAtual.DescricaoImagens;

                trackBarFonte.Value = configAtual.FonteTamanho;
                lblTamanhoFonte.Text = $"Tamanho da Fonte: {configAtual.FonteTamanho}pt";

                cmbContraste.SelectedItem = configAtual.ContrasteCores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar configurações: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                configAtual.UsuarioId = UserSession.IdUsuario;
                configAtual.TemaEscuro = chkTemaEscuro.Checked;
                configAtual.AltoContraste = chkAltoContraste.Checked;
                configAtual.LeitorTela = chkLeitorTela.Checked;
                configAtual.NavegacaoTeclado = chkNavegacaoTeclado.Checked;
                configAtual.DescricaoImagens = chkDescricaoImagens.Checked;
                configAtual.FonteTamanho = trackBarFonte.Value;
                configAtual.ContrasteCores = cmbContraste.SelectedItem?.ToString() ?? "normal";

                configDAO.SalvarConfiguracao(configAtual);
                AcessibilidadeGlobal.CarregarConfiguracoesUsuario(UserSession.IdUsuario);

                MessageBox.Show("Configurações de acessibilidade salvas com sucesso!\n" +
                              "As configurações serão aplicadas em todos os formulários.",
                              "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configurações: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBarFonte_Scroll(object sender, EventArgs e)
        {
            lblTamanhoFonte.Text = $"Tamanho da Fonte: {trackBarFonte.Value}pt";
            AplicarPrevisualizacao();
        }

        private void chkTemaEscuro_CheckedChanged(object sender, EventArgs e)
        {
            AplicarPrevisualizacao();
        }

        private void chkAltoContraste_CheckedChanged(object sender, EventArgs e)
        {
            AplicarPrevisualizacao();
        }

        private void chkLeitorTela_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeitorTela.Checked)
            {
                MessageBox.Show("Leitor de tela ativado. Use o narrador do Windows para navegar.",
                              "Leitor de Tela", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbContraste_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarPrevisualizacao();
        }

        private void AplicarPrevisualizacao()
        {
            try
            {
                var previewConfig = new ConfigAcessibilidade
                {
                    TemaEscuro = chkTemaEscuro.Checked,
                    AltoContraste = chkAltoContraste.Checked,
                    FonteTamanho = trackBarFonte.Value,
                    ContrasteCores = cmbContraste.SelectedItem?.ToString() ?? "normal"
                };

                AplicarConfiguracoesPreview(pnlPreview, previewConfig);
                AplicarConfiguracoesPreview(lblPreview, previewConfig);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro na preview: {ex.Message}");
            }
        }

        private void AplicarConfiguracoesPreview(Control control, ConfigAcessibilidade config)
        {
            if (control is Label label)
            {
                label.Font = new Font(label.Font.FontFamily, config.FonteTamanho, label.Font.Style);
            }

            if (config.TemaEscuro)
            {
                if (control is Panel panel) panel.BackColor = Color.FromArgb(45, 45, 48);
                if (control is Label lbl) lbl.BackColor = Color.FromArgb(45, 45, 48);
            }
            else
            {
                if (control is Panel panel) panel.BackColor = SystemColors.Window;
                if (control is Label lbl) lbl.BackColor = SystemColors.Window;
            }

            if (config.AltoContraste)
            {
                if (control is Panel panel) panel.BackColor = Color.Black;
                if (control is Label lbl) lbl.BackColor = Color.Black;
            }
        }

        private void btnRestaurarPadrao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja restaurar todas as configurações para os valores padrão?",
                              "Restaurar Padrão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                chkTemaEscuro.Checked = false;
                chkAltoContraste.Checked = false;
                chkLeitorTela.Checked = false;
                chkNavegacaoTeclado.Checked = true;
                chkDescricaoImagens.Checked = false;
                trackBarFonte.Value = 9;
                cmbContraste.SelectedIndex = 0;

                AplicarPrevisualizacao();
                MessageBox.Show("Configurações restauradas para os valores padrão.",
                              "Padrão Restaurado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}