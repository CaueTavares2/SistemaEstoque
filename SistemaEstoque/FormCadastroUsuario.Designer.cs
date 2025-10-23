
namespace SistemaEstoque
{
    partial class FormCadastroUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmaSenha = new System.Windows.Forms.TextBox();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLogin.Location = new System.Drawing.Point(184, 85);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(155, 23);
            this.txtLogin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSenha.Location = new System.Drawing.Point(184, 167);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(155, 23);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirmar senha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtConfirmaSenha
            // 
            this.txtConfirmaSenha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConfirmaSenha.Location = new System.Drawing.Point(184, 249);
            this.txtConfirmaSenha.Name = "txtConfirmaSenha";
            this.txtConfirmaSenha.Size = new System.Drawing.Size(155, 23);
            this.txtConfirmaSenha.TabIndex = 5;
            this.txtConfirmaSenha.UseSystemPasswordChar = true;
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(161, 358);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrarUsuario.TabIndex = 6;
            this.btnCadastrarUsuario.Text = "Cadastrar";
            this.btnCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click_1);
            // 
            // FormCadastroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(416, 450);
            this.Controls.Add(this.btnCadastrarUsuario);
            this.Controls.Add(this.txtConfirmaSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label1);
            this.Name = "FormCadastroUsuario";
            this.Text = "FormCadastroUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmaSenha;
        private System.Windows.Forms.Button btnCadastrarUsuario;
    }
}