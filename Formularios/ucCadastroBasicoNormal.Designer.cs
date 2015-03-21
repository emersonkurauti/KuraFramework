namespace KuraFrameWork.Formularios
{
    partial class ucCadastroBasicoNormal
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
            this.tcCadastro = new System.Windows.Forms.TabControl();
            this.tpConsulta = new System.Windows.Forms.TabPage();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.pnFiltro = new System.Windows.Forms.Panel();
            this.pnGridFiltro = new System.Windows.Forms.Panel();
            this.dgvFiltro = new System.Windows.Forms.DataGridView();
            this.nmCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ValorInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnBotoes = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.btnEncolherExpandir = new System.Windows.Forms.Button();
            this.tpFormulario = new System.Windows.Forms.TabPage();
            this.pnForm = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.tcCadastro.SuspendLayout();
            this.tpConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.pnFiltro.SuspendLayout();
            this.pnGridFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            this.pnBotoes.SuspendLayout();
            this.tpFormulario.SuspendLayout();
            this.pnForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCadastro
            // 
            this.tcCadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcCadastro.Controls.Add(this.tpConsulta);
            this.tcCadastro.Controls.Add(this.tpFormulario);
            this.tcCadastro.Location = new System.Drawing.Point(0, 25);
            this.tcCadastro.Name = "tcCadastro";
            this.tcCadastro.SelectedIndex = 0;
            this.tcCadastro.Size = new System.Drawing.Size(684, 320);
            this.tcCadastro.TabIndex = 1;
            this.tcCadastro.SelectedIndexChanged += new System.EventHandler(this.tcCadastro_SelectedIndexChanged);
            // 
            // tpConsulta
            // 
            this.tpConsulta.Controls.Add(this.dgvDados);
            this.tpConsulta.Controls.Add(this.pnFiltro);
            this.tpConsulta.Location = new System.Drawing.Point(4, 22);
            this.tpConsulta.Name = "tpConsulta";
            this.tpConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsulta.Size = new System.Drawing.Size(676, 294);
            this.tpConsulta.TabIndex = 0;
            this.tpConsulta.Text = "Consulta";
            this.tpConsulta.UseVisualStyleBackColor = true;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowDrop = true;
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToResizeRows = false;
            this.dgvDados.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(3, 93);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(670, 198);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellClick);
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_ColumnHeaderMouseClick);
            // 
            // pnFiltro
            // 
            this.pnFiltro.BackColor = System.Drawing.Color.White;
            this.pnFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFiltro.Controls.Add(this.pnGridFiltro);
            this.pnFiltro.Controls.Add(this.pnBotoes);
            this.pnFiltro.Controls.Add(this.btnEncolherExpandir);
            this.pnFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFiltro.Location = new System.Drawing.Point(3, 3);
            this.pnFiltro.Name = "pnFiltro";
            this.pnFiltro.Size = new System.Drawing.Size(670, 90);
            this.pnFiltro.TabIndex = 0;
            // 
            // pnGridFiltro
            // 
            this.pnGridFiltro.Controls.Add(this.dgvFiltro);
            this.pnGridFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGridFiltro.Location = new System.Drawing.Point(0, 0);
            this.pnGridFiltro.Name = "pnGridFiltro";
            this.pnGridFiltro.Size = new System.Drawing.Size(580, 68);
            this.pnGridFiltro.TabIndex = 5;
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.AllowUserToAddRows = false;
            this.dgvFiltro.AllowUserToDeleteRows = false;
            this.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nmCampo,
            this.Campo,
            this.Condicao,
            this.ValorInicial,
            this.ValorFinal});
            this.dgvFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiltro.Location = new System.Drawing.Point(0, 0);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.Size = new System.Drawing.Size(580, 68);
            this.dgvFiltro.TabIndex = 3;
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
            "Contém",
            "Dentre",
            "Diferente",
            "Entre",
            "Exceto",
            "Igual",
            "Maior",
            "Maior Igual",
            "Menor",
            "Menor Igual"});
            this.Condicao.Name = "Condicao";
            this.Condicao.Sorted = true;
            // 
            // ValorInicial
            // 
            this.ValorInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValorInicial.HeaderText = "Valor Inicial";
            this.ValorInicial.Name = "ValorInicial";
            this.ValorInicial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValorInicial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValorFinal
            // 
            this.ValorFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValorFinal.HeaderText = "Valor Final";
            this.ValorFinal.Name = "ValorFinal";
            this.ValorFinal.ReadOnly = true;
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btnConsultar);
            this.pnBotoes.Controls.Add(this.btnLimparFiltro);
            this.pnBotoes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnBotoes.Location = new System.Drawing.Point(580, 0);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(88, 68);
            this.pnBotoes.TabIndex = 4;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsultar.Image = global::KuraFrameWork.Properties.Resources.Buscar;
            this.btnConsultar.Location = new System.Drawing.Point(0, 0);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(88, 39);
            this.btnConsultar.TabIndex = 2;
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
            this.btnLimparFiltro.TabIndex = 3;
            this.btnLimparFiltro.Text = "Limpar";
            this.btnLimparFiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparFiltro.UseVisualStyleBackColor = true;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // btnEncolherExpandir
            // 
            this.btnEncolherExpandir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEncolherExpandir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncolherExpandir.Image = global::KuraFrameWork.Properties.Resources.Encolher;
            this.btnEncolherExpandir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncolherExpandir.Location = new System.Drawing.Point(0, 68);
            this.btnEncolherExpandir.Name = "btnEncolherExpandir";
            this.btnEncolherExpandir.Size = new System.Drawing.Size(668, 20);
            this.btnEncolherExpandir.TabIndex = 0;
            this.btnEncolherExpandir.Text = "Esconder Filtros";
            this.btnEncolherExpandir.UseVisualStyleBackColor = true;
            this.btnEncolherExpandir.Click += new System.EventHandler(this.ControleFiltro);
            // 
            // tpFormulario
            // 
            this.tpFormulario.Controls.Add(this.pnForm);
            this.tpFormulario.Location = new System.Drawing.Point(4, 22);
            this.tpFormulario.Name = "tpFormulario";
            this.tpFormulario.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormulario.Size = new System.Drawing.Size(676, 294);
            this.tpFormulario.TabIndex = 1;
            this.tpFormulario.Text = "Formulário";
            this.tpFormulario.UseVisualStyleBackColor = true;
            // 
            // pnForm
            // 
            this.pnForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnForm.Controls.Add(this.btnNext);
            this.pnForm.Controls.Add(this.btnLast);
            this.pnForm.Controls.Add(this.btnFirst);
            this.pnForm.Controls.Add(this.btnPrevious);
            this.pnForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnForm.Location = new System.Drawing.Point(3, 3);
            this.pnForm.Name = "pnForm";
            this.pnForm.Size = new System.Drawing.Size(670, 288);
            this.pnForm.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::KuraFrameWork.Properties.Resources.Next;
            this.btnNext.Location = new System.Drawing.Point(599, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 28);
            this.btnNext.TabIndex = 10;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Image = global::KuraFrameWork.Properties.Resources.Last;
            this.btnLast.Location = new System.Drawing.Point(634, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(29, 28);
            this.btnLast.TabIndex = 11;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Image = global::KuraFrameWork.Properties.Resources.First;
            this.btnFirst.Location = new System.Drawing.Point(529, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(29, 28);
            this.btnFirst.TabIndex = 8;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Image = global::KuraFrameWork.Properties.Resources.Previous;
            this.btnPrevious.Location = new System.Drawing.Point(564, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(29, 28);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // ucCadastroBasicoNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 367);
            this.Controls.Add(this.tcCadastro);
            this.HelpButton = true;
            this.MinimumSize = new System.Drawing.Size(700, 405);
            this.Name = "ucCadastroBasicoNormal";
            this.Text = "ucCadastroBasicoNormal";
            this.Load += new System.EventHandler(this.ucCadastroBasicoNormal_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ucCadastroBasicoNormal_KeyUp);
            this.Controls.SetChildIndex(this.tcCadastro, 0);
            this.tcCadastro.ResumeLayout(false);
            this.tpConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.pnFiltro.ResumeLayout(false);
            this.pnGridFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            this.pnBotoes.ResumeLayout(false);
            this.tpFormulario.ResumeLayout(false);
            this.pnForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tpConsulta;
        public System.Windows.Forms.Panel pnFiltro;
        public System.Windows.Forms.DataGridView dgvDados;
        public System.Windows.Forms.Panel pnForm;
        public System.Windows.Forms.Button btnLimparFiltro;
        public System.Windows.Forms.Button btnConsultar;
        public System.Windows.Forms.Panel pnBotoes;
        public System.Windows.Forms.TabControl tcCadastro;
        public System.Windows.Forms.DataGridView dgvFiltro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewComboBoxColumn Condicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorFinal;
        public System.Windows.Forms.Panel pnGridFiltro;
        public System.Windows.Forms.Button btnEncolherExpandir;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnLast;
        public System.Windows.Forms.Button btnFirst;
        public System.Windows.Forms.Button btnPrevious;
        public System.Windows.Forms.TabPage tpFormulario;
    }
}
