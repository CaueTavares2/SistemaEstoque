
namespace SistemaEstoque
{
    partial class FormMenu
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
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnListagem = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnSairMenu = new System.Windows.Forms.Button();
            this.btnSaida = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAlertaEstoque = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(61, 22);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(75, 23);
            this.btnCadastro.TabIndex = 0;
            this.btnCadastro.Text = "Cadastrar";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnListagem
            // 
            this.btnListagem.Location = new System.Drawing.Point(176, 22);
            this.btnListagem.Name = "btnListagem";
            this.btnListagem.Size = new System.Drawing.Size(75, 23);
            this.btnListagem.TabIndex = 1;
            this.btnListagem.Text = "Listagem";
            this.btnListagem.UseVisualStyleBackColor = true;
            this.btnListagem.Click += new System.EventHandler(this.btnListagem_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(431, 22);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(75, 23);
            this.btnRelatorio.TabIndex = 2;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnSairMenu
            // 
            this.btnSairMenu.Location = new System.Drawing.Point(242, 219);
            this.btnSairMenu.Name = "btnSairMenu";
            this.btnSairMenu.Size = new System.Drawing.Size(90, 23);
            this.btnSairMenu.TabIndex = 3;
            this.btnSairMenu.Text = "Sair do Menu";
            this.btnSairMenu.UseVisualStyleBackColor = true;
            this.btnSairMenu.Click += new System.EventHandler(this.btnSairMenu_Click);
            // 
            // btnSaida
            // 
            this.btnSaida.Location = new System.Drawing.Point(295, 22);
            this.btnSaida.Name = "btnSaida";
            this.btnSaida.Size = new System.Drawing.Size(75, 23);
            this.btnSaida.TabIndex = 4;
            this.btnSaida.Text = "Saída";
            this.btnSaida.UseVisualStyleBackColor = true;
            this.btnSaida.Click += new System.EventHandler(this.btnSaida_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnSaida);
            this.groupBox1.Controls.Add(this.btnRelatorio);
            this.groupBox1.Controls.Add(this.btnCadastro);
            this.groupBox1.Controls.Add(this.btnListagem);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 116);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // lblAlertaEstoque
            // 

            this.lblAlertaEstoque.AutoSize = true;
            this.lblAlertaEstoque.ForeColor = System.Drawing.Color.Red;
            this.lblAlertaEstoque.Location = new System.Drawing.Point(12, 290);
            this.lblAlertaEstoque.Name = "lblAlertaEstoque";
            this.lblAlertaEstoque.Size = new System.Drawing.Size(300, 20);
            this.lblAlertaEstoque.TabIndex = 6;
            this.lblAlertaEstoque.Text = "Nenhum alerta.";
            this.lblAlertaEstoque.Visible = false;
            this.lblAlertaEstoque = new System.Windows.Forms.Label();
            this.Controls.Add(this.lblAlertaEstoque);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 324);
            this.Controls.Add(this.lblAlertaEstoque);
            this.Controls.Add(this.btnSairMenu);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnListagem;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnSairMenu;
        private System.Windows.Forms.Button btnSaida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAlertaEstoque;
    }
}