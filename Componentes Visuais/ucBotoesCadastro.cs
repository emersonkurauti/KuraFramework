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
    public partial class ucBotoesCadastro : UserControl
    {
        public ucBotoesCadastro()
        {
            InitializeComponent();
            IniciarStatusBotoes();
        }

        private void IniciarStatusBotoes()
        {
            ControleBotoes("I");
        }

        private void ControleBotoes(string strOperacao)
        {
            btnExcluir.Enabled = strOperacao.Contains("S");
            btnLimpar.Enabled = strOperacao.Contains("N") || strOperacao.Contains("S");
            btnSalvar.Enabled = strOperacao.Contains("N");
            btnNovo.Enabled = strOperacao.Contains("I") || strOperacao.Contains("S");
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ControleBotoes("N");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ControleBotoes("S");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ControleBotoes("I");
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            ControleBotoes("I");
        }
    }
}
