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
    public partial class ucTextBoxMaskCPFCNPJ : ucTextBoxMask
    {
        //private bool _bAtualizaMascara;

        private string _strTipoDocumento;
        public string strTipoDocumento
        {
            get { return _strTipoDocumento; }
            set { SetTipoDocumento(value); }
        }

        private void SetTipoDocumento(string strValue)
        {
            _strTipoDocumento = strValue;
            AtualizaMascara();
        }

        public ucTextBoxMaskCPFCNPJ()
        {
            InitializeComponent();
        }

        private void ucTextBoxMaskCPFCNPJ_Leave(object sender, EventArgs e)
        {
            AtualizaMascara();
        }

        private void AtualizaMascara()
        {
            Mask = "";

            this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (_strTipoDocumento == "CPF")
            {
                if ((Text.Length < 11) && (Text.Length > 0))
                {
                    this.Text = Text.PadLeft(11, '0');
                }
                else
                {
                    this.Text = Text.Substring(Text.Length - 11, 11);
                }
                Mask = "999,999,999-AA";
            }
            else if (_strTipoDocumento == "CNPJ")
            {
                if ((Text.Length < 14)  && (Text.Length > 0))
                {
                    this.Text = Text.PadLeft(14, '0');
                }
                Mask = "99,999,999/9999-99";
            }
            this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
        }
    }
}
