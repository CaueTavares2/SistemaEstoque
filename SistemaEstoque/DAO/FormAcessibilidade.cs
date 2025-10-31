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

            // Tenta criar a tabela se não existir
            try
            {
                configDAO.CriarTabelaSeNaoExiste();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Aviso: Não foi possível verificar/criar a tabela de acessibilidade. Erro: {ex.Message}",
                              "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                // Cria uma configuração temporária para preview
                var previewConfig = new ConfigAcessibilidade
                {
                    TemaEscuro = chkTemaEscuro.Checked,
                    AltoContraste = chkAltoContraste.Checked,
                    FonteTamanho = trackBarFonte.Value,
                    ContrasteCores = cmbContraste.SelectedItem?.ToString() ?? "normal"
                };

                // Aplica no panel de preview e label
                AplicarConfiguracoesPreview(pnlPreview, lblPreview, previewConfig);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro na preview: {ex.Message}");
            }
        }

        private void AplicarConfiguracoesPreview(Panel panel, Label label, ConfigAcessibilidade config)
        {
            // Aplica tamanho da fonte
            label.Font = new Font(label.Font.FontFamily, config.FonteTamanho, label.Font.Style);

            // **CORREÇÃO: Reseta as cores primeiro**
            panel.BackColor = SystemColors.Window;
            label.BackColor = SystemColors.Window;
            label.ForeColor = SystemColors.WindowText;
            panel.BorderStyle = BorderStyle.FixedSingle;

            // **CORREÇÃO: Aplica ALTO CONTRASTE primeiro (tem prioridade)**
            if (config.AltoContraste)
            {
                panel.BackColor = Color.Black;
                label.BackColor = Color.Black;
                label.ForeColor = Color.White;
                panel.BorderStyle = BorderStyle.Fixed3D;

                // **CORREÇÃO: Adiciona borda branca para melhor visibilidade**
                label.BorderStyle = BorderStyle.FixedSingle;
            }
            // **CORREÇÃO: Tema escuro só aplica se alto contraste não estiver ativo**
            else if (config.TemaEscuro)
            {
                panel.BackColor = Color.FromArgb(45, 45, 48);
                label.BackColor = Color.FromArgb(45, 45, 48);
                label.ForeColor = Color.White;
                label.BorderStyle = BorderStyle.None;
            }

            AplicarEsquemaCoresPreview(label, config.ContrasteCores, config.AltoContraste);
        }

        private void AplicarEsquemaCoresPreview(Label label, string esquema, bool altoContrasteAtivo)
        {
            // **CORREÇÃO: Só aplica esquemas de cores se não estiver em alto contraste**
            if (altoContrasteAtivo) return;

            switch (esquema)
            {
                case "protanopia":
                    label.ForeColor = Color.FromArgb(0, 100, 200); // Azul forte
                    break;
                case "deuteranopia":
                    label.ForeColor = Color.FromArgb(200, 100, 0); // Laranja/vermelho
                    break;
                case "tritanopia":
                    label.ForeColor = Color.FromArgb(150, 150, 0); // Amarelo esverdeado
                    break;
                case "normal":
                default:
                    // Mantém a cor definida pelo tema
                    break;
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