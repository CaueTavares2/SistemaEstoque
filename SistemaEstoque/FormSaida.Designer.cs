
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
            ((System.ComponentModel.ISupportInitialize)(this.nudSaida)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(123, 63);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(116, 15);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.Text = "Selecione o Produto:";
            // 
            // lblQtdSaida
            // 
            this.lblQtdSaida.AutoSize = true;
            this.lblQtdSaida.Location = new System.Drawing.Point(123, 118);
            this.lblQtdSaida.Name = "lblQtdSaida";
            this.lblQtdSaida.Size = new System.Drawing.Size(119, 15);
            this.lblQtdSaida.TabIndex = 1;
            this.lblQtdSaida.Text = "Quantidade da Saída:";
            // 
            // nudSaida
            // 
            this.nudSaida.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nudSaida.Location = new System.Drawing.Point(323, 116);
            this.nudSaida.Maximum = new decimal(new int[] {
            1000,
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
            this.nudSaida.TabIndex = 2;
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
            this.cmbProduto.Location = new System.Drawing.Point(322, 60);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(121, 23);
            this.cmbProduto.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(249, 175);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(104, 23);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar saída";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // FormSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 277);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.cmbProduto);
            this.Controls.Add(this.nudSaida);
            this.Controls.Add(this.lblQtdSaida);
            this.Controls.Add(this.lblProduto);
            this.Name = "FormSaida";
            this.Text = "FormSaida";
            ((System.ComponentModel.ISupportInitialize)(this.nudSaida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblQtdSaida;
        private System.Windows.Forms.NumericUpDown nudSaida;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Button btnConfirmar;
    }
}