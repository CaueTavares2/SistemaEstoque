
namespace SistemaEstoque
{
    partial class FormRelatorio
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
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            this.lblTituloRelatorio = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnAtualizarRel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.AllowUserToAddRows = false;
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.Location = new System.Drawing.Point(12, 180);
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.ReadOnly = true;
            this.dgvRelatorio.RowTemplate.Height = 25;
            this.dgvRelatorio.Size = new System.Drawing.Size(370, 270);
            this.dgvRelatorio.TabIndex = 0;
            // 
            // lblTituloRelatorio
            // 
            this.lblTituloRelatorio.AutoSize = true;
            this.lblTituloRelatorio.Location = new System.Drawing.Point(22, 9);
            this.lblTituloRelatorio.Name = "lblTituloRelatorio";
            this.lblTituloRelatorio.Size = new System.Drawing.Size(215, 15);
            this.lblTituloRelatorio.TabIndex = 1;
            this.lblTituloRelatorio.Text = "Relatório: Produtos com Estoque Baixo ";
            this.lblTituloRelatorio.Click += new System.EventHandler(this.lblTituloRelatorio_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(23, 153);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(171, 15);
            this.lblValorTotal.TabIndex = 2;
            this.lblValorTotal.Text = "Valor total em estoque: R$ 0,00 ";
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            // 
            // btnAtualizarRel
            // 
            this.btnAtualizarRel.Location = new System.Drawing.Point(97, 76);
            this.btnAtualizarRel.Name = "btnAtualizarRel";
            this.btnAtualizarRel.Size = new System.Drawing.Size(199, 23);
            this.btnAtualizarRel.TabIndex = 3;
            this.btnAtualizarRel.Text = "Gerar / Atualizar Relatório";
            this.btnAtualizarRel.UseVisualStyleBackColor = true;
            this.btnAtualizarRel.Click += new System.EventHandler(this.btnAtualizarRel_Click);
            // 
            // FormRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 462);
            this.Controls.Add(this.btnAtualizarRel);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTituloRelatorio);
            this.Controls.Add(this.dgvRelatorio);
            this.Name = "FormRelatorio";
            this.Text = "FormRelatorio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRelatorio;
        private System.Windows.Forms.Label lblTituloRelatorio;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnAtualizarRel;
    }
}