
namespace SistemaEstoque
{
    partial class FormAcessibilidade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpVisual = new System.Windows.Forms.GroupBox();
            this.cmbContraste = new System.Windows.Forms.ComboBox();
            this.lblContraste = new System.Windows.Forms.Label();
            this.lblTamanhoFonte = new System.Windows.Forms.Label();
            this.trackBarFonte = new System.Windows.Forms.TrackBar();
            this.chkAltoContraste = new System.Windows.Forms.CheckBox();
            this.chkTemaEscuro = new System.Windows.Forms.CheckBox();
            this.grpFuncionalidades = new System.Windows.Forms.GroupBox();
            this.chkDescricaoImagens = new System.Windows.Forms.CheckBox();
            this.chkNavegacaoTeclado = new System.Windows.Forms.CheckBox();
            this.chkLeitorTela = new System.Windows.Forms.CheckBox();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnRestaurarPadrao = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpVisual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFonte)).BeginInit();
            this.grpFuncionalidades.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVisual
            // 
            this.grpVisual.Controls.Add(this.cmbContraste);
            this.grpVisual.Controls.Add(this.lblContraste);
            this.grpVisual.Controls.Add(this.lblTamanhoFonte);
            this.grpVisual.Controls.Add(this.trackBarFonte);
            this.grpVisual.Controls.Add(this.chkAltoContraste);
            this.grpVisual.Controls.Add(this.chkTemaEscuro);
            this.grpVisual.Location = new System.Drawing.Point(12, 12);
            this.grpVisual.Name = "grpVisual";
            this.grpVisual.Size = new System.Drawing.Size(460, 180);
            this.grpVisual.TabIndex = 0;
            this.grpVisual.TabStop = false;
            this.grpVisual.Text = "Configurações Visuais";
            // 
            // cmbContraste
            // 
            this.cmbContraste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContraste.FormattingEnabled = true;
            this.cmbContraste.Items.AddRange(new object[] {
            "normal",
            "protanopia",
            "deuteranopia",
            "tritanopia"});
            this.cmbContraste.Location = new System.Drawing.Point(20, 145);
            this.cmbContraste.Name = "cmbContraste";
            this.cmbContraste.Size = new System.Drawing.Size(150, 23);
            this.cmbContraste.TabIndex = 5;
            this.cmbContraste.SelectedIndexChanged += new System.EventHandler(this.cmbContraste_SelectedIndexChanged);
            // 
            // lblContraste
            // 
            this.lblContraste.AutoSize = true;
            this.lblContraste.Location = new System.Drawing.Point(20, 125);
            this.lblContraste.Name = "lblContraste";
            this.lblContraste.Size = new System.Drawing.Size(107, 15);
            this.lblContraste.TabIndex = 4;
            this.lblContraste.Text = "Esquema de Cores:";
            // 
            // lblTamanhoFonte
            // 
            this.lblTamanhoFonte.AutoSize = true;
            this.lblTamanhoFonte.Location = new System.Drawing.Point(20, 75);
            this.lblTamanhoFonte.Name = "lblTamanhoFonte";
            this.lblTamanhoFonte.Size = new System.Drawing.Size(128, 15);
            this.lblTamanhoFonte.TabIndex = 3;
            this.lblTamanhoFonte.Text = "Tamanho da Fonte: 9pt";
            // 
            // trackBarFonte
            // 
            this.trackBarFonte.Location = new System.Drawing.Point(20, 95);
            this.trackBarFonte.Maximum = 16;
            this.trackBarFonte.Minimum = 8;
            this.trackBarFonte.Name = "trackBarFonte";
            this.trackBarFonte.Size = new System.Drawing.Size(300, 45);
            this.trackBarFonte.TabIndex = 2;
            this.trackBarFonte.Value = 9;
            this.trackBarFonte.Scroll += new System.EventHandler(this.trackBarFonte_Scroll);
            // 
            // chkAltoContraste
            // 
            this.chkAltoContraste.AutoSize = true;
            this.chkAltoContraste.Location = new System.Drawing.Point(20, 50);
            this.chkAltoContraste.Name = "chkAltoContraste";
            this.chkAltoContraste.Size = new System.Drawing.Size(102, 19);
            this.chkAltoContraste.TabIndex = 1;
            this.chkAltoContraste.Text = "Alto Contraste";
            this.chkAltoContraste.UseVisualStyleBackColor = true;
            this.chkAltoContraste.CheckedChanged += new System.EventHandler(this.chkAltoContraste_CheckedChanged);
            // 
            // chkTemaEscuro
            // 
            this.chkTemaEscuro.AutoSize = true;
            this.chkTemaEscuro.Location = new System.Drawing.Point(20, 25);
            this.chkTemaEscuro.Name = "chkTemaEscuro";
            this.chkTemaEscuro.Size = new System.Drawing.Size(92, 19);
            this.chkTemaEscuro.TabIndex = 0;
            this.chkTemaEscuro.Text = "Tema Escuro";
            this.chkTemaEscuro.UseVisualStyleBackColor = true;
            this.chkTemaEscuro.CheckedChanged += new System.EventHandler(this.chkTemaEscuro_CheckedChanged);
            // 
            // grpFuncionalidades
            // 
            this.grpFuncionalidades.Controls.Add(this.chkDescricaoImagens);
            this.grpFuncionalidades.Controls.Add(this.chkNavegacaoTeclado);
            this.grpFuncionalidades.Controls.Add(this.chkLeitorTela);
            this.grpFuncionalidades.Location = new System.Drawing.Point(12, 198);
            this.grpFuncionalidades.Name = "grpFuncionalidades";
            this.grpFuncionalidades.Size = new System.Drawing.Size(460, 120);
            this.grpFuncionalidades.TabIndex = 1;
            this.grpFuncionalidades.TabStop = false;
            this.grpFuncionalidades.Text = "Funcionalidades de Acessibilidade";
            // 
            // chkDescricaoImagens
            // 
            this.chkDescricaoImagens.AutoSize = true;
            this.chkDescricaoImagens.Location = new System.Drawing.Point(20, 80);
            this.chkDescricaoImagens.Name = "chkDescricaoImagens";
            this.chkDescricaoImagens.Size = new System.Drawing.Size(141, 19);
            this.chkDescricaoImagens.TabIndex = 2;
            this.chkDescricaoImagens.Text = "Descrição de Imagens";
            this.chkDescricaoImagens.UseVisualStyleBackColor = true;
            // 
            // chkNavegacaoTeclado
            // 
            this.chkNavegacaoTeclado.AutoSize = true;
            this.chkNavegacaoTeclado.Checked = true;
            this.chkNavegacaoTeclado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNavegacaoTeclado.Location = new System.Drawing.Point(20, 55);
            this.chkNavegacaoTeclado.Name = "chkNavegacaoTeclado";
            this.chkNavegacaoTeclado.Size = new System.Drawing.Size(128, 19);
            this.chkNavegacaoTeclado.TabIndex = 1;
            this.chkNavegacaoTeclado.Text = "Navegação Teclado";
            this.chkNavegacaoTeclado.UseVisualStyleBackColor = true;
            // 
            // chkLeitorTela
            // 
            this.chkLeitorTela.AutoSize = true;
            this.chkLeitorTela.Location = new System.Drawing.Point(20, 30);
            this.chkLeitorTela.Name = "chkLeitorTela";
            this.chkLeitorTela.Size = new System.Drawing.Size(154, 19);
            this.chkLeitorTela.TabIndex = 0;
            this.chkLeitorTela.Text = "Leitor de Tela (Narração)";
            this.chkLeitorTela.UseVisualStyleBackColor = true;
            this.chkLeitorTela.CheckedChanged += new System.EventHandler(this.chkLeitorTela_CheckedChanged);
            // 
            // pnlPreview
            // 
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Controls.Add(this.lblPreview);
            this.pnlPreview.Location = new System.Drawing.Point(12, 324);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(460, 80);
            this.pnlPreview.TabIndex = 2;
            // 
            // lblPreview
            // 
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreview.Location = new System.Drawing.Point(0, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(458, 78);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Prévia: Texto de exemplo com as configurações atuais";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(12, 420);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(140, 35);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar Configurações";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnRestaurarPadrao
            // 
            this.btnRestaurarPadrao.Location = new System.Drawing.Point(172, 420);
            this.btnRestaurarPadrao.Name = "btnRestaurarPadrao";
            this.btnRestaurarPadrao.Size = new System.Drawing.Size(140, 35);
            this.btnRestaurarPadrao.TabIndex = 4;
            this.btnRestaurarPadrao.Text = "&Restaurar Padrão";
            this.btnRestaurarPadrao.UseVisualStyleBackColor = true;
            this.btnRestaurarPadrao.Click += new System.EventHandler(this.btnRestaurarPadrao_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(332, 420);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(140, 35);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormAcessibilidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 467);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnRestaurarPadrao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.grpFuncionalidades);
            this.Controls.Add(this.grpVisual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAcessibilidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Acessibilidade";
            this.Load += new System.EventHandler(this.FormAcessibilidade_Load);
            this.grpVisual.ResumeLayout(false);
            this.grpVisual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFonte)).EndInit();
            this.grpFuncionalidades.ResumeLayout(false);
            this.grpFuncionalidades.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVisual;
        private System.Windows.Forms.ComboBox cmbContraste;
        private System.Windows.Forms.Label lblContraste;
        private System.Windows.Forms.Label lblTamanhoFonte;
        private System.Windows.Forms.TrackBar trackBarFonte;
        private System.Windows.Forms.CheckBox chkAltoContraste;
        private System.Windows.Forms.CheckBox chkTemaEscuro;
        private System.Windows.Forms.GroupBox grpFuncionalidades;
        private System.Windows.Forms.CheckBox chkDescricaoImagens;
        private System.Windows.Forms.CheckBox chkNavegacaoTeclado;
        private System.Windows.Forms.CheckBox chkLeitorTela;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRestaurarPadrao;
        private System.Windows.Forms.Button btnFechar;
    }
}