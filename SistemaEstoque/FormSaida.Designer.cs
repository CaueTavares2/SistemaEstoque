namespace SistemaEstoque
{
    partial class FormSaida
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
            this.lblProduto = new System.Windows.Forms.Label();
            this.lblQtdSaida = new System.Windows.Forms.Label();
            this.nudSaida = new System.Windows.Forms.NumericUpDown();
            this.cmbProduto = new System.Windows.Forms.ComboBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBoxSaida = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaida)).BeginInit();
            this.groupBoxSaida.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProduto.Location = new System.Drawing.Point(20, 35);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(140, 19);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.Text = "Produto para Retirada:";
            // 
            // lblQtdSaida
            // 
            this.lblQtdSaida.AutoSize = true;
            this.lblQtdSaida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQtdSaida.Location = new System.Drawing.Point(20, 85);
            this.lblQtdSaida.Name = "lblQtdSaida";
            this.lblQtdSaida.Size = new System.Drawing.Size(155, 19);
            this.lblQtdSaida.TabIndex = 1;
            this.lblQtdSaida.Text = "Quantidade da Saída (*):";
            // 
            // nudSaida
            // 
            this.nudSaida.Location = new System.Drawing.Point(190, 83);
            this.nudSaida.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSaida.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSaida.Name = "nudSaida";
            this.nudSaida.Size = new System.Drawing.Size(120, 23);
            this.nudSaida.TabIndex = 2; // TabIndex 2
            this.nudSaida.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbProduto
            // 
            this.cmbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.Location = new System.Drawing.Point(190, 33);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(320, 23);
            this.cmbProduto.TabIndex = 1; // TabIndex 1
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(170, 210);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(150, 40);
            this.btnConfirmar.TabIndex = 3; // TabIndex 3
            this.btnConfirmar.Text = "CONFIRMAR SAÍDA";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(330, 210);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(150, 40);
            this.btnFechar.TabIndex = 4; // TabIndex 4
            this.btnFechar.Text = "FECHAR";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // groupBoxSaida
            // 
            this.groupBoxSaida.Controls.Add(this.lblProduto);
            this.groupBoxSaida.Controls.Add(this.cmbProduto);
            this.groupBoxSaida.Controls.Add(this.lblQtdSaida);
            this.groupBoxSaida.Controls.Add(this.nudSaida);
            this.groupBoxSaida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSaida.Location = new System.Drawing.Point(50, 40);
            this.groupBoxSaida.Name = "groupBoxSaida";
            this.groupBoxSaida.Size = new System.Drawing.Size(540, 130);
            this.groupBoxSaida.TabIndex = 0;
            this.groupBoxSaida.TabStop = false;
            this.groupBoxSaida.Text = "Registro de Saída de Estoque";
            // 
            // FormSaida
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 290); // Tamanho ajustado
            this.Controls.Add(this.groupBoxSaida);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnConfirmar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saída de Produtos do Estoque";
            this.Load += new System.EventHandler(this.FormSaida_Load); // Adicionado evento Load
            ((System.ComponentModel.ISupportInitialize)(this.nudSaida)).EndInit();
            this.groupBoxSaida.ResumeLayout(false);
            this.groupBoxSaida.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblQtdSaida;
        private System.Windows.Forms.NumericUpDown nudSaida;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnFechar; // Novo botão de fechar
        private System.Windows.Forms.GroupBox groupBoxSaida; // Novo GroupBox
    }
}