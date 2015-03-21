namespace KuraFrameWork.Componentes_Visuais
{
    partial class ucConsulta
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConsulta));
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblRotulo = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtDescricao = new KuraFrameWork.Componentes_Visuais.ucTextBox();
            this.txtCodigo = new KuraFrameWork.Componentes_Visuais.ucTextBoxNumero();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(0, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código :";
            // 
            // lblRotulo
            // 
            this.lblRotulo.AutoSize = true;
            this.lblRotulo.Location = new System.Drawing.Point(76, 0);
            this.lblRotulo.Name = "lblRotulo";
            this.lblRotulo.Size = new System.Drawing.Size(61, 13);
            this.lblRotulo.TabIndex = 3;
            this.lblRotulo.Text = "Descrição :";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.Location = new System.Drawing.Point(377, 15);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(22, 22);
            this.btnCadastrar.TabIndex = 5;
            this.btnCadastrar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(353, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(22, 22);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.AceitaEspaco = true;
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.CampoObrigatorio = false;
            this.txtDescricao.Location = new System.Drawing.Point(79, 16);
            this.txtDescricao.MensagemCampoObrigatorio = null;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(268, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AceitaEspaco = true;
            this.txtCodigo.CampoObrigatorio = false;
            this.txtCodigo.Location = new System.Drawing.Point(0, 16);
            this.txtCodigo.MensagemCampoObrigatorio = null;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(73, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.DoubleClick += new System.EventHandler(this.txtCodigo_DoubleClick);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // ucConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.lblRotulo);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "ucConsulta";
            this.Size = new System.Drawing.Size(399, 36);
            this.Load += new System.EventHandler(this.ucConsulta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ucTextBoxNumero txtCodigo;
        public ucTextBox txtDescricao;
        public System.Windows.Forms.Button btnConsultar;
        public System.Windows.Forms.Button btnCadastrar;
        public System.Windows.Forms.Label lblCodigo;
        public System.Windows.Forms.Label lblRotulo;
    }
}
