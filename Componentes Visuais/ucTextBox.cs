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
    public partial class ucTextBox : TextBox
    {
        private bool _bCampoDesabilitado = false;
        public bool CampoDesabilitado
        {
            get { return _bCampoDesabilitado; }
            set { _bCampoDesabilitado = value; }
        }

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

        private bool _bAceitaEspaco = true;
        public bool AceitaEspaco
        {
            get { return _bAceitaEspaco; }
            set { _bAceitaEspaco = value; }
        }

        public ucTextBox()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!_bAceitaEspaco && char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
