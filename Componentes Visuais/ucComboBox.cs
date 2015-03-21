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
    public partial class ucComboBox : ComboBox
    {
        private bool _bCampoObrigatorio;

        public bool CampoObrigatorio
        {
            get { return _bCampoObrigatorio; }
            set { _bCampoObrigatorio = value; }
        }

        private string _strMensagemCampoObrigatorio;

        public string MensagemCampoObrigatorio
        {
            get { return _strMensagemCampoObrigatorio; }
            set { _strMensagemCampoObrigatorio = value; }
        }

        public ucComboBox()
        {
            InitializeComponent();
            Height = 20;
        }
    }
}
