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
            this.btnFechar = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.AllowUserToAddRows = false;
            this.dgvRelatorio.AllowUserToDeleteRows = false;
            this.dgvRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelatorio.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.Location = new System.Drawing.Point(10, 150); // Posição abaixo do cabeçalho
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.ReadOnly = true;
            this.dgvRelatorio.RowTemplate.Height = 25;
            this.dgvRelatorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelatorio.Size = new System.Drawing.Size(780, 440); // Tamanho adaptável
            this.dgvRelatorio.TabIndex = 1; // TabIndex 1
            // 
            // lblTituloRelatorio
            // 
            this.lblTituloRelatorio.AutoSize = true;
            this.lblTituloRelatorio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTituloRelatorio.Location = new System.Drawing.Point(15, 50);
            this.lblTituloRelatorio.Name = "lblTituloRelatorio";
            this.lblTituloRelatorio.Size = new System.Drawing.Size(306, 21);
            this.lblTituloRelatorio.TabIndex = 1;
            this.lblTituloRelatorio.Text = "Relatório: Produtos com Estoque Crítico";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblValorTotal.ForeColor = System.Drawing.Color.DarkRed; // Cor para destaque de alerta
            this.lblValorTotal.Location = new System.Drawing.Point(15, 80);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(256, 19);
            this.lblValorTotal.TabIndex = 2;
            this.lblValorTotal.Text = "Total de itens em falta: X (R$ 0,00)";
            // 
            // btnAtualizarRel
            // 
            this.btnAtualizarRel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarRel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAtualizarRel.FlatAppearance.BorderSize = 0;
            this.btnAtualizarRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarRel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtualizarRel.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarRel.Location = new System.Drawing.Point(500, 70); // Alinhado à direita
            this.btnAtualizarRel.Name = "btnAtualizarRel";
            this.btnAtualizarRel.Size = new System.Drawing.Size(150, 35);
            this.btnAtualizarRel.TabIndex = 2; // TabIndex 2
            this.btnAtualizarRel.Text = "Atualizar Relatório";
            this.btnAtualizarRel.UseVisualStyleBackColor = false;
            this.btnAtualizarRel.Click += new System.EventHandler(this.btnAtualizarRel_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(660, 70);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 35);
            this.btnFechar.TabIndex = 3; // TabIndex 3
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.Controls.Add(this.lblMainTitle);
            this.panelHeader.Controls.Add(this.lblTituloRelatorio);
            this.panelHeader.Controls.Add(this.btnFechar);
            this.panelHeader.Controls.Add(this.lblValorTotal);
            this.panelHeader.Controls.Add(this.btnAtualizarRel);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 130);
            this.panelHeader.TabIndex = 4;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMainTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMainTitle.Location = new System.Drawing.Point(15, 10);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(227, 30);
            this.lblMainTitle.TabIndex = 4;
            this.lblMainTitle.Text = "MÓDULO RELATÓRIO";
            // 
            // FormRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600); // Tamanho padrão para relatórios (800x600)
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dgvRelatorio);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "FormRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios de Estoque";
            this.Load += new System.EventHandler(this.FormRelatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRelatorio;
        private System.Windows.Forms.Label lblTituloRelatorio;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnAtualizarRel;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblMainTitle;
    }
}