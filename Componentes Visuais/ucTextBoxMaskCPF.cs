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
    public partial class ucTextBoxMaskCPF : ucTextBoxMask
    {
        public ucTextBoxMaskCPF()
        {
            InitializeComponent();
            Mask = "999,999,999-AA";
        }
    }
}
