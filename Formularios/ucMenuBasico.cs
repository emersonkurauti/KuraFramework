using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuraFrameWork.Formularios
{
    public partial class ucMenuBasico : Form
    {
        private bool _bMostraToolStripMenu;
        public bool bMostraToolStripMenu
        {
            get { return _bMostraToolStripMenu; }
            set { SetbMostraToolStripMenu(value); }
        }

        private int _childFormNumber = 0;
        public int ChildFormNumber
        {
            get { return _childFormNumber; }
            set { _childFormNumber = value; }
        }

        public ucMenuBasico()
        {
            InitializeComponent();
        }

        private void SetbMostraToolStripMenu(bool bValor)
        {
            _bMostraToolStripMenu = bValor;
            tsMenu.Visible = bValor;
        }

        public ToolStripMenuItem RetornarItemMenuCriado(MenuStrip Menu, string Texto, System.Drawing.Bitmap Imagem, EventHandler Evento, string Nome)
        {
            ToolStripMenuItem ItemMenu = new ToolStripMenuItem(Texto, Imagem, Evento, Nome);
            Menu.Items.Add(ItemMenu);

            return ItemMenu;
        }

        public void AddItemMenu(MenuStrip Menu, string Texto, System.Drawing.Bitmap Imagem, EventHandler Evento, string Nome)
        {
            ToolStripMenuItem ItemMenu = new ToolStripMenuItem(Texto, Imagem, Evento, Nome);
            Menu.Items.Add(ItemMenu);
        }

        public void CriarSubItemMenu(ToolStripMenuItem MenuPai, string Texto, System.Drawing.Bitmap Imagem, EventHandler Evento, string Nome)
        {
            ToolStripMenuItem SubItemMenu = new ToolStripMenuItem(Texto, Imagem, Evento, Nome);

            MenuPai.DropDownItems.Add(SubItemMenu);
        }

        public void AddToolStripItem(ToolStrip tsMenu, System.Drawing.Bitmap Imagem, EventHandler Evento, string Nome)
        {
            tsMenu.Items.Add(new ToolStripButton("", Imagem, Evento, Nome));
        }

        public virtual void ItemMenu_onClick(object sender, EventArgs e)
        {
            //Código para o filho

            //Type tipo = Type.GetType(((ToolStripMenuItem)sender).Name);

            //if (tipo != null)
            //{
            //    System.Windows.Forms.Form form = (System.Windows.Forms.Form)Activator.CreateInstance(tipo);
            //    form.MdiParent = this;
            //    form.Show();
            //}
        }

        public virtual void ItemMenuStrip()
        {
            //Exemplo
            //ToolStripMenuItem menu = new ToolStripMenuItem("&Cadastros", null, null, "btnCadastros");
            //ToolStripMenuItem SSMenu = new ToolStripMenuItem("Teste", null, ItemMenu_onClick, "appTeste.frmCadastro");
            //menu.DropDownItems.Add(SSMenu);

            //menuStrip.Items.Add(menu);
            //menuStrip.Items.Add(new ToolStripMenuItem("&Sair", null, btnSair_onClick, "btnSair"));
        }

        public virtual void ItemToolStrip()
        {
            //tsMenu.Items.Add(new ToolStripButton("", Properties.Resources.Fechar, btnSair_onClick, "btnSair"));
        }

        public void btnSair_onClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ucMenuBasico_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (this.ActiveMdiChild == null || this.ActiveMdiChild.WindowState == FormWindowState.Minimized)
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\Manual usuário.pdf");
            }
        }
    }
}
