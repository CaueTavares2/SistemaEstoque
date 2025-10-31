using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaEstoque.DAO;

namespace SistemaEstoque.Classes
{
    public static class AcessibilidadeGlobal
    {
        private static ConfigAcessibilidade _configuracaoAtual;
        private static ConfigAcessibilidadeDAO _dao = new ConfigAcessibilidadeDAO();

        public static ConfigAcessibilidade ConfiguracaoAtual
        {
            get { return _configuracaoAtual ?? new ConfigAcessibilidade(); }
        }

        public static void CarregarConfiguracoesUsuario(int usuarioId)
        {
            if (usuarioId > 0)
            {
                _configuracaoAtual = _dao.ObterConfiguracao(usuarioId);
            }
        }

        public static void AplicarConfiguracoes(Form form, ConfigAcessibilidade config = null)
        {
            var configParaAplicar = config ?? _configuracaoAtual;

            if (configParaAplicar == null) return;

            ApplyConfigurationRecursive(form, configParaAplicar);
        }

        private static void ApplyConfigurationRecursive(Control control, ConfigAcessibilidade config)
        {
            ApplyToControl(control, config);

            foreach (Control childControl in control.Controls)
            {
                ApplyConfigurationRecursive(childControl, config);
            }
        }

        private static void ApplyToControl(Control control, ConfigAcessibilidade config)
        {
            // Tamanho da fonte
            if (config.FonteTamanho > 0)
            {
                control.Font = new Font(control.Font.FontFamily, config.FonteTamanho, control.Font.Style);
            }

            // Tema escuro
            if (config.TemaEscuro)
            {
                ApplyDarkTheme(control);
            }

            // Alto contraste
            if (config.AltoContraste)
            {
                ApplyHighContrast(control);
            }
        }

        private static void ApplyDarkTheme(Control control)
        {
            if (control is Button btn)
            {
                btn.BackColor = Color.FromArgb(45, 45, 48);
                btn.ForeColor = Color.White;
            }
            else if (control is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(30, 30, 30);
                txt.ForeColor = Color.White;
            }
            else if (control is ComboBox cmb)
            {
                cmb.BackColor = Color.FromArgb(30, 30, 30);
                cmb.ForeColor = Color.White;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.FromArgb(45, 45, 48);
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            else if (control is Form form)
            {
                form.BackColor = Color.FromArgb(45, 45, 48);
                form.ForeColor = Color.White;
            }
            else if (control is Panel panel)
            {
                panel.BackColor = Color.FromArgb(45, 45, 48);
                panel.ForeColor = Color.White;
            }
            else if (control is GroupBox groupBox)
            {
                groupBox.BackColor = Color.FromArgb(45, 45, 48);
                groupBox.ForeColor = Color.White;
            }
        }

        private static void ApplyHighContrast(Control control)
        {
            if (control is Button btn)
            {
                btn.BackColor = Color.Black;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
            }
            else if (control is TextBox txt)
            {
                txt.BackColor = Color.Black;
                txt.ForeColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Form form)
            {
                form.BackColor = Color.Black;
                form.ForeColor = Color.White;
            }
        }

        public static bool NavegacaoPorTecladoAtiva()
        {
            return ConfiguracaoAtual?.NavegacaoTeclado ?? true;
        }

        public static bool LeitorTelaAtivo()
        {
            return ConfiguracaoAtual?.LeitorTela ?? false;
        }
    }
}