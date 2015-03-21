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
    public partial class ucTextBoxMaskTelefone : ucTextBoxMask
    {
        public ucTextBoxMaskTelefone()
        {
            InitializeComponent();
            Mask = "(99) 0000-0000";
        }
    }
}
