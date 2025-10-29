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
            this.btnFornecedores = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCadastro
            // 
            this.btnCadastro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCadastro.Location = new System.Drawing.Point(93, 30);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(120, 40);
            this.btnCadastro.TabIndex = 1; // TabIndex 1
            this.btnCadastro.Text = "Cadastro (Prod.)";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnListagem
            // 
            this.btnListagem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnListagem.Location = new System.Drawing.Point(233, 30);
            this.btnListagem.Name = "btnListagem";
            this.btnListagem.Size = new System.Drawing.Size(120, 40);
            this.btnListagem.TabIndex = 2; // TabIndex 2
            this.btnListagem.Text = "Listagem";
            this.btnListagem.UseVisualStyleBackColor = true;
            this.btnListagem.Click += new System.EventHandler(this.btnListagem_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRelatorio.Location = new System.Drawing.Point(93, 90);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(120, 40);
            this.btnRelatorio.TabIndex = 4; // TabIndex 4
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnSairMenu
            // 
            this.btnSairMenu.BackColor = System.Drawing.Color.LightCoral;
            this.btnSairMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSairMenu.ForeColor = System.Drawing.Color.White;
            this.btnSairMenu.Location = new System.Drawing.Point(260, 212); // Posição centralizada abaixo do GroupBox
            this.btnSairMenu.Name = "btnSairMenu";
            this.btnSairMenu.Size = new System.Drawing.Size(90, 35);
            this.btnSairMenu.TabIndex = 6; // TabIndex 6 (Último)
            this.btnSairMenu.Text = "Sair do Menu";
            this.btnSairMenu.UseVisualStyleBackColor = false;
            this.btnSairMenu.Click += new System.EventHandler(this.btnSairMenu_Click);
            // 
            // btnSaida
            // 
            this.btnSaida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaida.Location = new System.Drawing.Point(373, 30);
            this.btnSaida.Name = "btnSaida";
            this.btnSaida.Size = new System.Drawing.Size(120, 40);
            this.btnSaida.TabIndex = 3; // TabIndex 3
            this.btnSaida.Text = "Saída";
            this.btnSaida.UseVisualStyleBackColor = true;
            this.btnSaida.Click += new System.EventHandler(this.btnSaida_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnFornecedores);
            this.groupBox1.Controls.Add(this.btnSaida);
            this.groupBox1.Controls.Add(this.btnRelatorio);
            this.groupBox1.Controls.Add(this.btnCadastro);
            this.groupBox1.Controls.Add(this.btnListagem);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.groupBox1.Size = new System.Drawing.Size(586, 160); // Aumentamos a altura
            this.groupBox1.TabIndex = 0; // TabIndex 0
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Painel de Ações"; // Nome mais descritivo
            // 
            // btnFornecedores
            // 
            this.btnFornecedores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFornecedores.Location = new System.Drawing.Point(233, 90);
            this.btnFornecedores.Name = "btnFornecedores";
            this.btnFornecedores.Size = new System.Drawing.Size(120, 40);
            this.btnFornecedores.TabIndex = 5; // TabIndex 5
            this.btnFornecedores.Text = "Fornecedores";
            this.btnFornecedores.UseVisualStyleBackColor = true;
            this.btnFornecedores.Click += new System.EventHandler(this.btnFornecedores_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 270); // Ajustamos a altura
            this.Controls.Add(this.btnSairMenu);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Controle de Estoque - Menu Principal";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnListagem;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnSairMenu;
        private System.Windows.Forms.Button btnSaida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFornecedores;
    }
}