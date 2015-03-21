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
    public partial class ucParametroRelatorio : UserControl
    {
        private string _strParamtros;
        public string strParamtros
        {
            get { return _strParamtros; }
            set { _strParamtros = value; }
        }

        public ucParametroRelatorio()
        {
            InitializeComponent();
        }

        public virtual string GetParametros()
        {
            return "";
        }
    }
}
