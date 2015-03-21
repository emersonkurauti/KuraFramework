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
    public partial class ucTextBoxMask : MaskedTextBox
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

        public ucTextBoxMask()
        {
            InitializeComponent();
        }

        public virtual string PegaTexto()
        {
            return Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", ""); ;
        }
    }
}
