namespace KuraFrameWork.Componentes_Visuais
{
    partial class ucImagens
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
            this.components = new System.ComponentModel.Container();
            this.imgListaImagens = new System.Windows.Forms.ImageList(this.components);
            this.dlgImagem = new System.Windows.Forms.OpenFileDialog();
            this.pnListaImagem = new System.Windows.Forms.Panel();
            this.lsvImagens = new System.Windows.Forms.ListView();
            this.Imagem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnBotoes = new System.Windows.Forms.Panel();
            this.btnLimparLista = new System.Windows.Forms.Button();
            this.btnRemoverImagem = new System.Windows.Forms.Button();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.pnListaImagem.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListaImagens
            // 
            this.imgListaImagens.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListaImagens.ImageSize = new System.Drawing.Size(128, 128);
            this.imgListaImagens.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dlgImagem
            // 
            this.dlgImagem.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            this.dlgImagem.Multiselect = true;
            // 
            // pnListaImagem
            // 
            this.pnListaImagem.Controls.Add(this.lsvImagens);
            this.pnListaImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListaImagem.Location = new System.Drawing.Point(0, 0);
            this.pnListaImagem.Name = "pnListaImagem";
            this.pnListaImagem.Size = new System.Drawing.Size(657, 203);
            this.pnListaImagem.TabIndex = 4;
            // 
            // lsvImagens
            // 
            this.lsvImagens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvImagens.CheckBoxes = true;
            this.lsvImagens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Imagem});
            this.lsvImagens.HideSelection = false;
            this.lsvImagens.LabelEdit = true;
            this.lsvImagens.LargeImageList = this.imgListaImagens;
            this.lsvImagens.Location = new System.Drawing.Point(0, 0);
            this.lsvImagens.Name = "lsvImagens";
            this.lsvImagens.Size = new System.Drawing.Size(657, 171);
            this.lsvImagens.SmallImageList = this.imgListaImagens;
            this.lsvImagens.TabIndex = 1;
            this.lsvImagens.UseCompatibleStateImageBehavior = false;
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btnLimparLista);
            this.pnBotoes.Controls.Add(this.btnRemoverImagem);
            this.pnBotoes.Controls.Add(this.btnCarregar);
            this.pnBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBotoes.Location = new System.Drawing.Point(0, 173);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(657, 30);
            this.pnBotoes.TabIndex = 5;
            // 
            // btnLimparLista
            // 
            this.btnLimparLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimparLista.Location = new System.Drawing.Point(364, 4);
            this.btnLimparLista.Name = "btnLimparLista";
            this.btnLimparLista.Size = new System.Drawing.Size(293, 23);
            this.btnLimparLista.TabIndex = 6;
            this.btnLimparLista.Text = "Limpar Lista de Imagens...";
            this.btnLimparLista.UseVisualStyleBackColor = true;
            this.btnLimparLista.Click += new System.EventHandler(this.btnLimparLista_Click);
            // 
            // btnRemoverImagem
            // 
            this.btnRemoverImagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoverImagem.Location = new System.Drawing.Point(145, 4);
            this.btnRemoverImagem.Name = "btnRemoverImagem";
            this.btnRemoverImagem.Size = new System.Drawing.Size(213, 23);
            this.btnRemoverImagem.TabIndex = 5;
            this.btnRemoverImagem.Text = "Remover Imagens Selecionadas...";
            this.btnRemoverImagem.UseVisualStyleBackColor = true;
            this.btnRemoverImagem.Click += new System.EventHandler(this.btnRemoverImagem_Click);
            // 
            // btnCarregar
            // 
            this.btnCarregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCarregar.Location = new System.Drawing.Point(0, 4);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(139, 23);
            this.btnCarregar.TabIndex = 4;
            this.btnCarregar.Text = "Carregar Imagem...";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // ucImagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnBotoes);
            this.Controls.Add(this.pnListaImagem);
            this.Name = "ucImagens";
            this.Size = new System.Drawing.Size(657, 203);
            this.pnListaImagem.ResumeLayout(false);
            this.pnBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.OpenFileDialog dlgImagem;
        public System.Windows.Forms.Panel pnListaImagem;
        public System.Windows.Forms.ListView lsvImagens;
        public System.Windows.Forms.ColumnHeader Imagem;
        private System.Windows.Forms.Button btnLimparLista;
        private System.Windows.Forms.Button btnRemoverImagem;
        private System.Windows.Forms.Button btnCarregar;
        public System.Windows.Forms.Panel pnBotoes;
        public System.Windows.Forms.ImageList imgListaImagens;
    }
}
