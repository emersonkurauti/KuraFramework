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
    public partial class ucTextBoxMaxCEP : ucTextBoxMask
    {
        public ucTextBoxMaxCEP()
        {
            InitializeComponent();
            Mask = "00000-999";
        }
    }
}
