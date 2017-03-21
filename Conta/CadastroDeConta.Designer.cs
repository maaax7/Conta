namespace MaaaX.CaixaEletronico.CadastroConta
{
    partial class CadastroDeConta
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
            this.lblTitular = new System.Windows.Forms.Label();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.lblNumeroConta = new System.Windows.Forms.Label();
            this.txtNumeroConta = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lblTipoConta = new System.Windows.Forms.Label();
            this.cbTipoConta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(13, 13);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(85, 13);
            this.lblTitular.TabIndex = 0;
            this.lblTitular.Text = "Nome do Titular:";
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(113, 12);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(120, 20);
            this.txtTitular.TabIndex = 1;
            // 
            // lblNumeroConta
            // 
            this.lblNumeroConta.AutoSize = true;
            this.lblNumeroConta.Location = new System.Drawing.Point(13, 50);
            this.lblNumeroConta.Name = "lblNumeroConta";
            this.lblNumeroConta.Size = new System.Drawing.Size(93, 13);
            this.lblNumeroConta.TabIndex = 2;
            this.lblNumeroConta.Text = "Numero da Conta:";
            // 
            // txtNumeroConta
            // 
            this.txtNumeroConta.Location = new System.Drawing.Point(113, 50);
            this.txtNumeroConta.Name = "txtNumeroConta";
            this.txtNumeroConta.Size = new System.Drawing.Size(120, 20);
            this.txtNumeroConta.TabIndex = 3;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(76, 131);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 4;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lblTipoConta
            // 
            this.lblTipoConta.AutoSize = true;
            this.lblTipoConta.Location = new System.Drawing.Point(12, 87);
            this.lblTipoConta.Name = "lblTipoConta";
            this.lblTipoConta.Size = new System.Drawing.Size(77, 13);
            this.lblTipoConta.TabIndex = 5;
            this.lblTipoConta.Text = "Tipo de Conta:";
            // 
            // cbTipoConta
            // 
            this.cbTipoConta.DisplayMember = "Text";
            this.cbTipoConta.FormattingEnabled = true;
            this.cbTipoConta.Location = new System.Drawing.Point(113, 87);
            this.cbTipoConta.Name = "cbTipoConta";
            this.cbTipoConta.Size = new System.Drawing.Size(121, 21);
            this.cbTipoConta.TabIndex = 6;
            // 
            // CadastroDeConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 171);
            this.Controls.Add(this.cbTipoConta);
            this.Controls.Add(this.lblTipoConta);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtNumeroConta);
            this.Controls.Add(this.lblNumeroConta);
            this.Controls.Add(this.txtTitular);
            this.Controls.Add(this.lblTitular);
            this.Name = "CadastroDeConta";
            this.Text = "CadastroDeConta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label lblNumeroConta;
        private System.Windows.Forms.TextBox txtNumeroConta;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label lblTipoConta;
        private System.Windows.Forms.ComboBox cbTipoConta;
    }
}