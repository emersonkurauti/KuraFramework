namespace KuraFrameWork.Formularios
{
    partial class ucConsultaBasicaNormal
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
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.pnFiltro = new System.Windows.Forms.Panel();
            this.pnBotoes = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.dgvFiltro = new System.Windows.Forms.DataGridView();
            this.nmCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ValorInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEncolherExpandir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.pnFiltro.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDados.Location = new System.Drawing.Point(0, 112);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(684, 328);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // pnFiltro
            // 
            this.pnFiltro.BackColor = System.Drawing.Color.White;
            this.pnFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFiltro.Controls.Add(this.pnBotoes);
            this.pnFiltro.Controls.Add(this.dgvFiltro);
            this.pnFiltro.Controls.Add(this.btnEncolherExpandir);
            this.pnFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFiltro.Location = new System.Drawing.Point(0, 25);
            this.pnFiltro.Name = "pnFiltro";
            this.pnFiltro.Size = new System.Drawing.Size(684, 90);
            this.pnFiltro.TabIndex = 4;
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btnConsultar);
            this.pnBotoes.Controls.Add(this.btnLimparFiltro);
            this.pnBotoes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnBotoes.Location = new System.Drawing.Point(594, 0);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(88, 68);
            this.pnBotoes.TabIndex = 6;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsultar.Image = global::KuraFrameWork.Properties.Resources.Buscar;
            this.btnConsultar.Location = new System.Drawing.Point(0, 0);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 39);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Buscar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnLimparFiltro
            // 
            this.btnLimparFiltro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLimparFiltro.Image = global::KuraFrameWork.Properties.Resources.LimparMini;
            this.btnLimparFiltro.Location = new System.Drawing.Point(0, 39);
            this.btnLimparFiltro.Name = "btnLimparFiltro";
            this.btnLimparFiltro.Size = new System.Drawing.Size(88, 29);
            this.btnLimparFiltro.TabIndex = 5;
            this.btnLimparFiltro.Text = "Limpar";
            this.btnLimparFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparFiltro.UseVisualStyleBackColor = true;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.AllowUserToAddRows = false;
            this.dgvFiltro.AllowUserToDeleteRows = false;
            this.dgvFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nmCampo,
            this.Campo,
            this.Condicao,
            this.ValorInicial,
            this.ValorFinal});
            this.dgvFiltro.Location = new System.Drawing.Point(0, 0);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.Size = new System.Drawing.Size(594, 68);
            this.dgvFiltro.TabIndex = 5;
            this.dgvFiltro.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiltro_CellEndEdit);
            // 
            // nmCampo
            // 
            this.nmCampo.HeaderText = "nmCampo";
            this.nmCampo.Name = "nmCampo";
            this.nmCampo.ReadOnly = true;
            this.nmCampo.Visible = false;
            // 
            // Campo
            // 
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            this.Campo.ReadOnly = true;
            this.Campo.Width = 150;
            // 
            // Condicao
            // 
            this.Condicao.HeaderText = "Condição";
            this.Condicao.Items.AddRange(new object[] {
            "Igual",
            "Diferente",
            "Contém",
            "Maior",
            "Menor",
            "Maior Igual",
            "Menor Igual",
            "Entre",
            "Dentre",
            "Exceto"});
            this.Condicao.Name = "Condicao";
            // 
            // ValorInicial
            // 
            this.ValorInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValorInicial.HeaderText = "Valor Inicial";
            this.ValorInicial.Name = "ValorInicial";
            // 
            // ValorFinal
            // 
            this.ValorFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValorFinal.HeaderText = "Valor Final";
            this.ValorFinal.Name = "ValorFinal";
            this.ValorFinal.ReadOnly = true;
            // 
            // btnEncolherExpandir
            // 
            this.btnEncolherExpandir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEncolherExpandir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncolherExpandir.Image = global::KuraFrameWork.Properties.Resources.Encolher;
            this.btnEncolherExpandir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncolherExpandir.Location = new System.Drawing.Point(0, 68);
            this.btnEncolherExpandir.Name = "btnEncolherExpandir";
            this.btnEncolherExpandir.Size = new System.Drawing.Size(682, 20);
            this.btnEncolherExpandir.TabIndex = 0;
            this.btnEncolherExpandir.Text = "Esconder Filtros";
            this.btnEncolherExpandir.UseVisualStyleBackColor = true;
            this.btnEncolherExpandir.Click += new System.EventHandler(this.ControleFiltro);
            // 
            // ucConsultaBasicaNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.bBNovo = false;
            this.bEditar = false;
            this.bExcluir = false;
            this.bLimpar = false;
            this.bSalvar = false;
            this.bSelecionar = true;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.pnFiltro);
            this.Controls.Add(this.dgvDados);
            this.Name = "ucConsultaBasicaNormal";
            this.Text = "ucConsultaBasicaNormal";
            this.Load += new System.EventHandler(this.ucConsultaBasicaNormal_Load);
            this.Controls.SetChildIndex(this.dgvDados, 0);
            this.Controls.SetChildIndex(this.pnFiltro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.pnFiltro.ResumeLayout(false);
            this.pnBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvDados;
        public System.Windows.Forms.Panel pnFiltro;
        private System.Windows.Forms.Button btnEncolherExpandir;
        public System.Windows.Forms.Panel pnBotoes;
        public System.Windows.Forms.DataGridView dgvFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewComboBoxColumn Condicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorFinal;
        public System.Windows.Forms.Button btnConsultar;
        public System.Windows.Forms.Button btnLimparFiltro;

    }
}
