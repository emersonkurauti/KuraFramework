using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KuraFrameWork.Componentes_Visuais;
using KuraFrameWork.Banco;

namespace KuraFrameWork.Formularios
{
    public partial class ucCadastroBasico : Form
    {
        private string _ColunaOrdenada = "";
        public string colunaOrdenada
        {
            get { return _ColunaOrdenada; }
            set { _ColunaOrdenada = value; }
        }

        private string _Order = "";
        public string order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        private char _Status;
        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private DataTable _dtDados;
        public DataTable dtDados
        {
            get { return _dtDados; }
            set { _dtDados = value; }
        }

        private bool _bSelecionar = false;
        public bool bSelecionar
        {
            get { return _bSelecionar; }
            set { _bSelecionar = value; }
        }

        private bool _bNovo = true;
        public bool bBNovo
        {
            get { return _bNovo; }
            set { _bNovo = value; }
        }

        private bool _bSalvar = true;
        public bool bSalvar
        {
            get { return _bSalvar; }
            set { _bSalvar = value; }
        }

        private bool _bEditar = true;
        public bool bEditar
        {
            get { return _bEditar; }
            set { _bEditar = value; }
        }

        private bool _bExcluir = true;
        public bool bExcluir
        {
            get { return _bExcluir; }
            set { _bExcluir = value; }
        }

        private bool _bLimpar = true;
        public bool bLimpar
        {
            get { return _bLimpar; }
            set { _bLimpar = value; }
        }

        private bool _bImprimir = true;
        public bool bImprimir
        {
            get { return _bImprimir; }
            set { _bImprimir = value; }
        }

        private bool _bFechar = true;
        public bool bFechar
        {
            get { return _bFechar; }
            set { _bFechar = value; }
        }

        private bool _bMostrarMenu = true;
        public bool bMostrarMenu
        {
            get { return _bMostrarMenu; }
            set { SetBMostrarMenu(value); }
        }

        private bool _bImprimeRelSimples = true;
        public bool bImprimeRelSimples
        {
            get { return _bImprimeRelSimples; }
            set { _bImprimeRelSimples = value; }
        }

        private bool _bImprimeRelCompleto = true;
        public bool bImprimeRelCompleto
        {
            get { return _bImprimeRelCompleto; }
            set { _bImprimeRelCompleto = value; }
        }

        public void SetBMostrarMenu(bool bValor)
        {
            tsBotoes.Visible = bValor;
            _bMostrarMenu = bValor;
        }

        public ucCadastroBasico()
        {
            InitializeComponent();
            IniciarStatusBotoes();
        }

        private void IniciarStatusBotoes()
        {
            ControleBotoes("I");
            tslStatus.Text = "";
            _Status = ' ';
        }

        public void ControleBotoes(string strOperacao)
        {
            tsbExcluir.Enabled = strOperacao.Contains("S") || strOperacao.Contains("E");
            tsbLimpar.Enabled = strOperacao.Contains("N") || strOperacao.Contains("S") || strOperacao.Contains("E");
            tsbSalvar.Enabled = strOperacao.Contains("N") || strOperacao.Contains("E");
            tsbNovo.Enabled = strOperacao.Contains("I") || strOperacao.Contains("S");
            tsbEditar.Enabled = strOperacao.Contains("E") || strOperacao.Contains("S");
        }

        public virtual void tsbNovo_Click(object sender, EventArgs e)
        {
            ControleBotoes("N");
            tslStatus.Text = "Inserindo...";
            _Status = 'I';
        }

        public virtual void tsbSalvar_Click(object sender, EventArgs e)
        {
            ControleBotoes("S");
            tslStatus.Text = "Registro salvo.";
            _Status = ' ';
        }

        public virtual void tsbEditar_Click(object sender, EventArgs e)
        {
            ControleBotoes("N");
            tslStatus.Text = "Editando...";
            _Status = 'A';
        }

        public virtual void tsbExcluir_Click(object sender, EventArgs e)
        {
            ControleBotoes("I");
            tslStatus.Text = "Registro excluído.";
            _Status = ' ';
        }

        public virtual void tsbLimpar_Click(object sender, EventArgs e)
        {
            ControleBotoes("I");
            tslStatus.Text = "";
            _Status = ' ';
        }

        public virtual bool ControleRegistroNaoSalvoContinua()
        {
            if (Status.ToString().Trim() != "")
            {
                if (MessageBox.Show(csMensagem.msgRegistroEmEdicao, csMensagem.msgNomeSistema,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tsbLimpar_Click(null, null);
                    return true;
                }
            }

            return false;
        }

        public virtual void ControleCampos(Control.ControlCollection Controles, bool bStatus)
        {
            foreach (var control in Controles)
            {
                if (control is KuraFrameWork.Componentes_Visuais.ucImagens)
                {
                    ControleCampos(((KuraFrameWork.Componentes_Visuais.ucImagens)control).Controls, bStatus);
                }
                else
                    if (control is UserControl)
                    {
                        ControleCampos(((UserControl)control).Controls, bStatus);
                    }
                    else
                        if (control is ucTextBox)
                        {
                            ((ucTextBox)control).Enabled = bStatus;

                            if (((ucTextBox)control).CampoDesabilitado)
                                ((ucTextBox)control).Enabled = !((ucTextBox)control).CampoDesabilitado;
                        }
                        else
                            if (control is MaskedTextBox)
                            {
                                ((MaskedTextBox)control).Enabled = bStatus;
                            }
                            else
                                if (control is Button)
                                {
                                    ((Button)control).Enabled = bStatus;
                                }
                                else
                                    if (control is TextBox)
                                    {
                                        ((TextBox)control).Enabled = bStatus;
                                    }
                                    else
                                        if (control is RadioButton)
                                        {
                                            ((RadioButton)control).Enabled = bStatus;
                                        }
                                        else
                                            if (control is DataGridView)
                                            {
                                                //((DataGridView)control).Enabled = bStatus;
                                                //((DataGridView)control).ReadOnly = !bStatus;
                                            }
                                            else
                                                if (control is DateTimePicker)
                                                {
                                                    ((DateTimePicker)control).Enabled = bStatus;
                                                }
                                                else
                                                    if (control is ComboBox)
                                                    {
                                                        ((ComboBox)control).Enabled = bStatus;
                                                    }
                                                    else
                                                        if (control is DataGridView)
                                                        {
                                                            ((DataGridView)control).Enabled = bStatus;
                                                        }
                                                        else
                                                            if (control is CheckBox)
                                                            {
                                                                ((CheckBox)control).Enabled = bStatus;
                                                            }
                                                            else
                                                                if (control is TabPage)
                                                                {
                                                                    ControleCampos(((TabPage)control).Controls, bStatus);
                                                                }
                                                                else
                                                                    if (control is TabControl)
                                                                    {
                                                                        ControleCampos(((TabControl)control).Controls, bStatus);
                                                                        //((TabControl)control).Enabled = bStatus;
                                                                    }
                                                                    else
                                                                        if (control is GroupBox)
                                                                        {
                                                                            ControleCampos(((GroupBox)control).Controls, bStatus);
                                                                        }
            }
        }

        public virtual void LimparCampos(Control.ControlCollection Controles)
        {
            foreach (var control in Controles)
            {
                if (control is KuraFrameWork.Componentes_Visuais.ucImagens)
                {
                    ((KuraFrameWork.Componentes_Visuais.ucImagens)control).btnLimparLista_Click(null, null);
                }
                else
                    if (control is KuraFrameWork.Componentes_Visuais.ucConsulta)
                    {
                        ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).txtCodigo.Text = "";
                        ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).txtDescricao.Text = "";
                    }
                    else
                        if (control is MaskedTextBox)
                        {
                            ((MaskedTextBox)control).Text = "";
                        }
                        else
                            if (control is TextBox)
                            {
                                ((TextBox)control).Text = "";
                            }
                            else
                                if (control is DateTimePicker)
                                {
                                    ((DateTimePicker)control).Text = "";
                                }
                                else
                                    if (control is ComboBox)
                                    {
                                        ((ComboBox)control).SelectedIndex = -1;
                                    }
                                    else
                                        if (control is DataGridView)
                                        {
                                            ((DataGridView)control).DataSource = null;
                                        }
                                        else
                                            if (control is CheckBox)
                                            {
                                                ((CheckBox)control).Checked = false;
                                            }
                                            else
                                                if (control is TabPage)
                                                {
                                                    LimparCampos(((TabPage)control).Controls);
                                                }
                                                else
                                                    if (control is TabControl)
                                                    {
                                                        LimparCampos(((TabControl)control).Controls);
                                                    }
                                                    else
                                                        if (control is GroupBox)
                                                        {
                                                            LimparCampos(((GroupBox)control).Controls);
                                                        }
            }
        }

        private void tsbFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public virtual void tsbImprimir_ButtonClick(object sender, EventArgs e)
        {
            
        }

        public virtual void tsmiResultadoSimples_Click(object sender, EventArgs e)
        {

        }

        public virtual void tsmiResultadoCompleto_Click(object sender, EventArgs e)
        {

        }

        public void MontarDataGridView(DataGridView dgvDados, string strFields, string strVisibilidade, string strNome)
        {
            DataGridViewTextBoxColumn dgvColumn;
            DataGridViewTextBoxCell dgvCell;

            string[] vstrFields;
            vstrFields = strFields.Split(',');

            string[] vstrVisibilidade;
            vstrVisibilidade = strVisibilidade.Split(',');

            string[] vstrNome;
            vstrNome = strNome.Split(',');

            for (int i = 0; i < vstrFields.Length; i++)
            {
                dgvColumn = new DataGridViewTextBoxColumn();
                dgvCell = new DataGridViewTextBoxCell();

                dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvColumn.CellTemplate = dgvCell;
                dgvColumn.HeaderText = vstrNome[i].ToString();
                dgvColumn.Visible = Convert.ToBoolean(Convert.ToInt32(vstrVisibilidade[i].ToString()));
                dgvColumn.Name = vstrFields[i].ToString();
                dgvColumn.DataPropertyName = vstrFields[i].ToString();

                switch (vstrFields[i].ToString())
                {
                    case "nuCNPJ": dgvColumn.DefaultCellStyle.Format = @"00\.000\.000/0000-00";
                        break;
                    case "nuCPF": dgvColumn.DefaultCellStyle.Format = @"000\.000\.000-00";
                        break;
                    case "nuCEP": dgvColumn.DefaultCellStyle.Format = "#####-###";
                        break;
                    case "nuTelefone": dgvColumn.DefaultCellStyle.Format = "(00) 00000-0000";
                        break;
                }

                dgvDados.Columns.Add(dgvColumn);
            }
        }

        public virtual void MontaGridViewDinamico()
        {
        }

        public string AddCondicao(string sComando, string sCampo, string sValor = " ", int nCondicao = 0, bool bUsaAspas = false,
            bool bAbre = false, bool bFecha = false, string sValor2 = " ", bool bAnd = true)
        {
            string sCondicao = "";

            if (bAbre)
                sCondicao = "(";

            if (bUsaAspas && nCondicao != csConstantes.nContem && nCondicao != csConstantes.nDentre && nCondicao != csConstantes.nExceto)
            {
                sValor = "'" + sValor + "'";
                sValor2 = "'" + sValor2 + "'";
            }

            if (bUsaAspas && (nCondicao == csConstantes.nDentre || nCondicao == csConstantes.nExceto))
            {
                string[] vstrValor = sValor.Split(',');
                sValor = "";

                foreach (string strValor in vstrValor)
                    sValor += "'" + strValor + "',";

                sValor = sValor.Substring(0, sValor.Length - 1);
            }

            switch (nCondicao)
            {
                case csConstantes.nIgual: sCondicao = sCampo + "=" + sValor;
                    break;
                case csConstantes.nDiferente: sCondicao = sCampo + "<>" + sValor;
                    break;
                case csConstantes.nMaior: sCondicao = sCampo + ">" + sValor;
                    break;
                case csConstantes.nMenor: sCondicao = sCampo + "<" + sValor;
                    break;
                case csConstantes.nMaiorIgual: sCondicao = sCampo + ">=" + sValor;
                    break;
                case csConstantes.nMenorIgual: sCondicao = sCampo + "<=" + sValor;
                    break;
                case csConstantes.nBetween: sCondicao = sCampo + " BETWEEN " + sValor + " AND " + sValor2;
                    break;
                case csConstantes.nContem: sCondicao = sCampo + " LIKE '%" + sValor + "%'";
                    break;
                case csConstantes.nDentre: sCondicao = sCampo + " IN (" + sValor + ")";
                    break;
                case csConstantes.nExceto: sCondicao = sCampo + " NOT IN (" + sValor + ")";
                    break;
            }

            if (bFecha)
                sCondicao += ")";

            if (sComando.Contains("WHERE"))
            {
                if (bAnd)
                    return " AND " + sCondicao;
                else
                    return " OR " + sCondicao;
            }
            else
                return " WHERE " + sCondicao;
        }

        public string MontarFiltroConsulta(DataGridView dgvFiltro, string nmTabela)
        {
            csBanco objBanco = csBanco.Instance;
            string strFiltro = "";
            bool bUsaAspas;

            for (int i = 0; i < dgvFiltro.Rows.Count; i++)
            {
                bUsaAspas = objBanco.UsarAspas(nmTabela, dgvFiltro.Rows[i].Cells[0].Value.ToString());

                switch ((dgvFiltro.Rows[i].Cells[2] as DataGridViewComboBoxCell).Value.ToString())
                {
                    case "Entre":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nBetween, bUsaAspas, false, false, dgvFiltro.Rows[i].Cells[4].Value.ToString());
                        break;
                    case "Contém":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nContem, bUsaAspas);
                        break;
                    case "Diferente":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nDiferente, bUsaAspas);
                        break;
                    case "Igual":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nIgual, bUsaAspas);
                        break;
                    case "Maior":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nMaior, bUsaAspas);
                        break;
                    case "Maior Igual":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nMaiorIgual, bUsaAspas);
                        break;
                    case "Menor":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nMenor, bUsaAspas);
                        break;
                    case "Menor Igual":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nMenorIgual, bUsaAspas);
                        break;
                    case "Dentre":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nDentre, bUsaAspas);
                        break;
                    case "Exceto":
                        strFiltro += AddCondicao(strFiltro, dgvFiltro.Rows[i].Cells[0].Value.ToString(), dgvFiltro.Rows[i].Cells[3].Value.ToString(),
                                     csConstantes.nExceto, bUsaAspas);
                        break;
                }
            }

            return strFiltro;
        }

        public virtual bool CampoObrigatorioNaoPreenchido(Control.ControlCollection Controles)
        {
            foreach (var control in Controles)
            {
                if (control is KuraFrameWork.Componentes_Visuais.ucConsulta)
                {
                    if (((KuraFrameWork.Componentes_Visuais.ucConsulta)control).CampoObrigatorio && ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).txtCodigo.Text == "")
                    {
                        MessageBox.Show(((KuraFrameWork.Componentes_Visuais.ucConsulta)control).MensagemCampoObrigatorio);
                        return true;
                    }
                }
                else
                    if (control is TabPage)
                    {
                        if (CampoObrigatorioNaoPreenchido(((TabPage)control).Controls))
                            return true;
                    }
                    else
                        if (control is TabControl)
                        {
                            if (CampoObrigatorioNaoPreenchido(((TabControl)control).Controls))
                                return true;
                        }
                        else
                            if (control is GroupBox)
                            {
                                if (CampoObrigatorioNaoPreenchido(((GroupBox)control).Controls))
                                    return true;
                            }
                            else
                                if (control is ucTextBox)
                                {
                                    if (((ucTextBox)control).CampoObrigatorio && ((ucTextBox)control).Text == "")
                                    {
                                        MessageBox.Show(((ucTextBox)control).MensagemCampoObrigatorio);
                                        return true;
                                    }
                                }
                                else
                                    if (control is ucTextBoxMask)
                                    {
                                        if (((ucTextBoxMask)control).CampoObrigatorio && ((ucTextBoxMask)control).PegaTexto() == "")
                                        {
                                            MessageBox.Show(((ucTextBoxMask)control).MensagemCampoObrigatorio);
                                            return true;
                                        }
                                    }
                                    else
                                        if (control is ucComboBox)
                                        {
                                            if (((ucComboBox)control).CampoObrigatorio && ((ucComboBox)control).SelectedIndex == -1)
                                            {
                                                MessageBox.Show(((ucComboBox)control).MensagemCampoObrigatorio);
                                                return true;
                                            }
                                        }

            }
            return false;
        }

        public virtual void ucCadastroBasico_Load(object sender, EventArgs e)
        {
            tsbSelecionar.Visible = _bSelecionar;
            tsbNovo.Visible = _bNovo;
            tsbSalvar.Visible = _bSalvar;
            tsbEditar.Visible = _bEditar;
            tsbExcluir.Visible = _bExcluir;
            tsbLimpar.Visible = _bLimpar;
            tsbImprimir.Visible = _bImprimir;
            tsbFechar.Visible = _bFechar;

            tsmiResultadoSimples.Visible = _bImprimeRelSimples;
            tsmiResultadoCompleto.Visible = _bImprimeRelCompleto;
        }

        public DataTable SortDataTable(DataTable oDtt, string Sort)
        {
            if (_ColunaOrdenada == "")
                _ColunaOrdenada = Sort;

            if (_ColunaOrdenada == Sort && (_Order == "" || _Order == " ASC"))
                _Order = " DESC";
            else
            {
                _ColunaOrdenada = Sort;
                _Order = " ASC";
            }

            if (oDtt == null)
                return null;

            if (String.IsNullOrEmpty(Sort))
                return oDtt;

            oDtt.DefaultView.Sort = Sort + _Order;
            DataTable oDttTemp = oDtt.DefaultView.ToTable();

            return oDttTemp;
        }

        public virtual void tsbSelecionar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
