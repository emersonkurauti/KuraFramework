using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuraFrameWork.Componentes_Visuais
{
    public partial class ucTextBoxNumero : ucTextBox
    {
        public ucTextBoxNumero()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (char.IsLetter(e.KeyChar) ||  char.IsSymbol(e.KeyChar) || 
                char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar)) 
                e.Handled = true; 
        }
    }
}
