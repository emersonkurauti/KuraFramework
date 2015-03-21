namespace KuraFrameWork.Formularios
{
    partial class ucLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLogin));
            this.ssmLogin = new System.Windows.Forms.StatusStrip();
            this.tssmObsLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbSenha = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pcbFundoLogin = new System.Windows.Forms.PictureBox();
            this.ssmLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFundoLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // ssmLogin
            // 
            this.ssmLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssmObsLogin});
            this.ssmLogin.Location = new System.Drawing.Point(0, 156);
            this.ssmLogin.Name = "ssmLogin";
            this.ssmLogin.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ssmLogin.Size = new System.Drawing.Size(255, 22);
            this.ssmLogin.TabIndex = 4;
            // 
            // tssmObsLogin
            // 
            this.tssmObsLogin.Name = "tssmObsLogin";
            this.tssmObsLogin.Size = new System.Drawing.Size(0, 17);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Location = new System.Drawing.Point(68, 57);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(157, 20);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenha.Location = new System.Drawing.Point(68, 83);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(157, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenha_KeyDown);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(12, 64);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(50, 13);
            this.lbUsuario.TabIndex = 5;
            this.lbUsuario.Text = "Usuário";
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSenha.Location = new System.Drawing.Point(19, 90);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(43, 13);
            this.lbSenha.TabIndex = 6;
            this.lbSenha.Text = "Senha";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Image = global::KuraFrameWork.Properties.Resources.Finaliza;
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinalizar.Location = new System.Drawing.Point(149, 109);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(76, 28);
            this.btnFinalizar.TabIndex = 3;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Image = global::KuraFrameWork.Properties.Resources.Confirma;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.Location = new System.Drawing.Point(68, 109);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 28);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "&Confirmar";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pcbFundoLogin
            // 
            this.pcbFundoLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbFundoLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbFundoLogin.ErrorImage = null;
            this.pcbFundoLogin.InitialImage = null;
            this.pcbFundoLogin.Location = new System.Drawing.Point(0, 0);
            this.pcbFundoLogin.Name = "pcbFundoLogin";
            this.pcbFundoLogin.Size = new System.Drawing.Size(255, 178);
            this.pcbFundoLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbFundoLogin.TabIndex = 3;
            this.pcbFundoLogin.TabStop = false;
            // 
            // ucLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(255, 178);
            this.ControlBox = false;
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.ssmLogin);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.pcbFundoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(303, 202);
            this.MinimumSize = new System.Drawing.Size(257, 202);
            this.Name = "ucLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ssmLogin.ResumeLayout(false);
            this.ssmLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFundoLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnConfirmar;
        public System.Windows.Forms.Button btnFinalizar;
        public System.Windows.Forms.StatusStrip ssmLogin;
        public System.Windows.Forms.PictureBox pcbFundoLogin;
        private System.Windows.Forms.ToolStripStatusLabel tssmObsLogin;
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.TextBox txtSenha;
        public System.Windows.Forms.Label lbUsuario;
        public System.Windows.Forms.Label lbSenha;

    }
}