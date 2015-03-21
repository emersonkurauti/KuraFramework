namespace KuraFrameWork.Formularios
{
    partial class ucCadastroBasico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCadastroBasico));
            this.tsBotoes = new System.Windows.Forms.ToolStrip();
            this.tsbSelecionar = new System.Windows.Forms.ToolStripButton();
            this.tsbNovo = new System.Windows.Forms.ToolStripButton();
            this.tsbSalvar = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluir = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpar = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiResultadoSimples = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResultadoCompleto = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbFechar = new System.Windows.Forms.ToolStripButton();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsBotoes.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsBotoes
            // 
            this.tsBotoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelecionar,
            this.tsbNovo,
            this.tsbSalvar,
            this.tsbEditar,
            this.tsbExcluir,
            this.tsbLimpar,
            this.tsbImprimir,
            this.tsbFechar});
            this.tsBotoes.Location = new System.Drawing.Point(0, 0);
            this.tsBotoes.Name = "tsBotoes";
            this.tsBotoes.Size = new System.Drawing.Size(684, 25);
            this.tsBotoes.TabIndex = 0;
            this.tsBotoes.Text = "Menu";
            // 
            // tsbSelecionar
            // 
            this.tsbSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("tsbSelecionar.Image")));
            this.tsbSelecionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelecionar.Name = "tsbSelecionar";
            this.tsbSelecionar.Size = new System.Drawing.Size(81, 22);
            this.tsbSelecionar.Text = "Selecionar";
            this.tsbSelecionar.Click += new System.EventHandler(this.tsbSelecionar_Click);
            // 
            // tsbNovo
            // 
            this.tsbNovo.Image = global::KuraFrameWork.Properties.Resources.Novo;
            this.tsbNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNovo.Name = "tsbNovo";
            this.tsbNovo.Size = new System.Drawing.Size(56, 22);
            this.tsbNovo.Text = "Novo";
            this.tsbNovo.ToolTipText = "Novo";
            this.tsbNovo.Click += new System.EventHandler(this.tsbNovo_Click);
            // 
            // tsbSalvar
            // 
            this.tsbSalvar.Image = global::KuraFrameWork.Properties.Resources.Salvar;
            this.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalvar.Name = "tsbSalvar";
            this.tsbSalvar.Size = new System.Drawing.Size(58, 22);
            this.tsbSalvar.Text = "Salvar";
            this.tsbSalvar.Click += new System.EventHandler(this.tsbSalvar_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.Image = global::KuraFrameWork.Properties.Resources.Editar;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(57, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbExcluir
            // 
            this.tsbExcluir.Image = global::KuraFrameWork.Properties.Resources.Excluir;
            this.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluir.Name = "tsbExcluir";
            this.tsbExcluir.Size = new System.Drawing.Size(61, 22);
            this.tsbExcluir.Text = "Excluir";
            this.tsbExcluir.Click += new System.EventHandler(this.tsbExcluir_Click);
            // 
            // tsbLimpar
            // 
            this.tsbLimpar.Image = global::KuraFrameWork.Properties.Resources.Limpar;
            this.tsbLimpar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpar.Name = "tsbLimpar";
            this.tsbLimpar.Size = new System.Drawing.Size(64, 22);
            this.tsbLimpar.Text = "Limpar";
            this.tsbLimpar.Click += new System.EventHandler(this.tsbLimpar_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResultadoSimples,
            this.tsmiResultadoCompleto});
            this.tsbImprimir.Image = global::KuraFrameWork.Properties.Resources.Imprimir2;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(85, 22);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.ButtonClick += new System.EventHandler(this.tsbImprimir_ButtonClick);
            // 
            // tsmiResultadoSimples
            // 
            this.tsmiResultadoSimples.Name = "tsmiResultadoSimples";
            this.tsmiResultadoSimples.Size = new System.Drawing.Size(182, 22);
            this.tsmiResultadoSimples.Text = "Resultado Simples";
            this.tsmiResultadoSimples.Click += new System.EventHandler(this.tsmiResultadoSimples_Click);
            // 
            // tsmiResultadoCompleto
            // 
            this.tsmiResultadoCompleto.Name = "tsmiResultadoCompleto";
            this.tsmiResultadoCompleto.Size = new System.Drawing.Size(182, 22);
            this.tsmiResultadoCompleto.Text = "Resultado Completo";
            this.tsmiResultadoCompleto.Click += new System.EventHandler(this.tsmiResultadoCompleto_Click);
            // 
            // tsbFechar
            // 
            this.tsbFechar.Image = global::KuraFrameWork.Properties.Resources.Fechar;
            this.tsbFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFechar.Name = "tsbFechar";
            this.tsbFechar.Size = new System.Drawing.Size(62, 22);
            this.tsbFechar.Text = "Fechar";
            this.tsbFechar.Click += new System.EventHandler(this.tsbFechar_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.ssStatus.Location = new System.Drawing.Point(0, 440);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(684, 22);
            this.ssStatus.TabIndex = 2;
            this.ssStatus.Text = "StatusBar";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(39, 17);
            this.tslStatus.Text = "Status";
            // 
            // ucCadastroBasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.tsBotoes);
            this.MinimumSize = new System.Drawing.Size(700, 250);
            this.Name = "ucCadastroBasico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ucFormBasico";
            this.Load += new System.EventHandler(this.ucCadastroBasico_Load);
            this.tsBotoes.ResumeLayout(false);
            this.tsBotoes.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip ssStatus;
        public System.Windows.Forms.ToolStripButton tsbSalvar;
        public System.Windows.Forms.ToolStripButton tsbExcluir;
        public System.Windows.Forms.ToolStripButton tsbLimpar;
        public System.Windows.Forms.ToolStripButton tsbFechar;
        public System.Windows.Forms.ToolStripStatusLabel tslStatus;
        public System.Windows.Forms.ToolStripButton tsbEditar;
        public System.Windows.Forms.ToolStripButton tsbNovo;
        public System.Windows.Forms.ToolStrip tsBotoes;
        private System.Windows.Forms.ToolStripSplitButton tsbImprimir;
        private System.Windows.Forms.ToolStripMenuItem tsmiResultadoSimples;
        private System.Windows.Forms.ToolStripMenuItem tsmiResultadoCompleto;
        private System.Windows.Forms.ToolStripButton tsbSelecionar;


    }
}