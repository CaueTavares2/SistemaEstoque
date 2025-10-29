namespace SistemaEstoque
{
    partial class FormConfiguracaoAcessibilidade
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
            this.grpFonte = new System.Windows.Forms.GroupBox();
            this.cmbTamanhoFonte = new System.Windows.Forms.ComboBox();
            this.lblTamanho = new System.Windows.Forms.Label();
            this.grpContraste = new System.Windows.Forms.GroupBox();
            this.chkAltoContraste = new System.Windows.Forms.CheckBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpFonte.SuspendLayout();
            this.grpContraste.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFonte
            // 
            this.grpFonte.Controls.Add(this.cmbTamanhoFonte);
            this.grpFonte.Controls.Add(this.lblTamanho);
            this.grpFonte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpFonte.Location = new System.Drawing.Point(30, 25);
            this.grpFonte.Name = "grpFonte";
            this.grpFonte.Size = new System.Drawing.Size(420, 90);
            this.grpFonte.TabIndex = 0;
            this.grpFonte.TabStop = false;
            this.grpFonte.Text = "Configurações de Texto";
            // 
            // cmbTamanhoFonte
            // 
            this.cmbTamanhoFonte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTamanhoFonte.FormattingEnabled = true;
            this.cmbTamanhoFonte.Items.AddRange(new object[] {
            "Pequeno",
            "Médio",
            "Grande"});
            this.cmbTamanhoFonte.Location = new System.Drawing.Point(170, 40);
            this.cmbTamanhoFonte.Name = "cmbTamanhoFonte";
            this.cmbTamanhoFonte.Size = new System.Drawing.Size(220, 23);
            this.cmbTamanhoFonte.TabIndex = 1;
            // 
            // lblTamanho
            // 
            this.lblTamanho.AutoSize = true;
            this.lblTamanho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTamanho.Location = new System.Drawing.Point(30, 42);
            this.lblTamanho.Name = "lblTamanho";
            this.lblTamanho.Size = new System.Drawing.Size(120, 19);
            this.lblTamanho.TabIndex = 0;
            this.lblTamanho.Text = "Tamanho da Fonte:";
            // 
            // grpContraste
            // 
            this.grpContraste.Controls.Add(this.chkAltoContraste);
            this.grpContraste.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpContraste.Location = new System.Drawing.Point(30, 130);
            this.grpContraste.Name = "grpContraste";
            this.grpContraste.Size = new System.Drawing.Size(420, 70);
            this.grpContraste.TabIndex = 1;
            this.grpContraste.TabStop = false;
            this.grpContraste.Text = "Visão e Cores";
            // 
            // chkAltoContraste
            // 
            this.chkAltoContraste.AutoSize = true;
            this.chkAltoContraste.Location = new System.Drawing.Point(30, 32);
            this.chkAltoContraste.Name = "chkAltoContraste";
            this.chkAltoContraste.Size = new System.Drawing.Size(157, 19);
            this.chkAltoContraste.TabIndex = 0;
            this.chkAltoContraste.Text = "Habilitar Alto Contraste";
            this.chkAltoContraste.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAplicar.FlatAppearance.BorderSize = 0;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(120, 230);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(150, 40);
            this.btnAplicar.TabIndex = 2;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(270, 230);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(150, 40);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "FECHAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormConfiguracaoAcessibilidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 295);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.grpContraste);
            this.Controls.Add(this.grpFonte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguracaoAcessibilidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Acessibilidade";
            this.Load += new System.EventHandler(this.FormConfiguracaoAcessibilidade_Load);
            this.grpFonte.ResumeLayout(false);
            this.grpFonte.PerformLayout();
            this.grpContraste.ResumeLayout(false);
            this.grpContraste.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFonte;
        private System.Windows.Forms.Label lblTamanho;
        private System.Windows.Forms.ComboBox cmbTamanhoFonte;
        private System.Windows.Forms.GroupBox grpContraste;
        private System.Windows.Forms.CheckBox chkAltoContraste;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnFechar;
    }
}