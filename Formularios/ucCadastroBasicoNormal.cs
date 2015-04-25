using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace KuraFrameWork.Formularios
{
    public partial class ucCadastroBasicoNormal : KuraFrameWork.Formularios.ucCadastroBasico
    {
        private Type _tobjCa;
        public Type tobjCa
        {
            get { return _tobjCa; }
            set { _tobjCa = value; }
        }

        private object _objCon;
        public object objCon
        {
            get { return _objCon; }
            set { _objCon = value; }
        }

        public string strFields = "", strVisivel = "", strNome = "";

        private int _PosCursorDt;
        private DataRow _drLinha;

        public DataRow drLinha
        {
            get { return _drLinha; }
            set { _drLinha = value; }
        }

        public int PosCursorDt
        {
            get { return _PosCursorDt; }
            set { _PosCursorDt = value; }
        }
        private TabPage _tpCorrente;

        public TabPage TpCorrente
        {
            get { return _tpCorrente; }
            set { _tpCorrente = value; }
        }

        public ucCadastroBasicoNormal()
        {
            InitializeComponent();

            try
            {
                _tpCorrente = tcCadastro.SelectedTab;
                _PosCursorDt = 0;
                LimparCampos(pnForm.Controls);
                this.ControleFiltro(null, null);
                ControleCampos(pnForm.Controls, false);
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucCadastroBasicoNormal.Constructor");
            }
        }

        public void ControleFiltro(object sender, EventArgs e)
        {
            if (pnFiltro.Height != 20)
            {
                pnFiltro.Height = 20;
                btnEncolherExpandir.Text = "Mostrar Filtros";
                btnEncolherExpandir.Image = KuraFrameWork.Properties.Resources.Expandir;
                dgvDados.Height = dgvDados.Height + 70;
            }
            else
            {
                pnFiltro.Height = 90;
                btnEncolherExpandir.Text = "Esconder Filtros";
                btnEncolherExpandir.Image = KuraFrameWork.Properties.Resources.Encolher;
                dgvDados.Height = dgvDados.Height - 70;
            }
        }

        public override void tsbNovo_Click(object sender, EventArgs e)
        {
            base.tsbNovo_Click(sender, e);
            tcCadastro.SelectedIndex = 1;
            LimparCampos(pnForm.Controls);
            ControleCampos(pnForm.Controls, true);
        }

        public override void tsbEditar_Click(object sender, EventArgs e)
        {
            base.tsbEditar_Click(sender, e);
            tcCadastro.SelectedIndex = 1;
            ControleCampos(pnForm.Controls, true);
        }

        public override void tsbLimpar_Click(object sender, EventArgs e)
        {
            base.tsbLimpar_Click(sender, e);
            LimparCampos(pnForm.Controls);
            ControleCampos(pnForm.Controls, false);
        }

        public override void tsbSalvar_Click(object sender, EventArgs e)
        {
            if (!CampoObrigatorioNaoPreenchido(pnForm.Controls))
            {
                object vobjCon;

                CarregaObjeto(out vobjCon);

                Type tobjCon = vobjCon.GetType();

                if (Status == csConstantes.sInserindo)
                {
                    MethodInfo Inserir = tobjCon.GetMethod("Inserir");
                    object bInserir = Inserir.Invoke(Inserir, new object[] { });

                    if ((bool)bInserir)
                    {
                        object nmCampoChave = _tobjCa.GetProperty("nmCampoChave").GetValue(_tobjCa, null);

                        PropertyInfo pobjCo = vobjCon.GetType().GetProperty("objCo");

                        object objCo = tobjCon.GetProperty("objCo").GetValue(_objCon, null);
                        Type tobjCo = objCo.GetType();

                        object oCodigo = tobjCo.GetProperty(nmCampoChave.ToString()).GetValue(objCo, null);

                        base.tsbSalvar_Click(sender, e);
                        ControleCampos(pnForm.Controls, false);
                        PreencheDadosGridView();
                        AtualizaCodigo(oCodigo.ToString(), nmCampoChave.ToString());
                        btnConsultar_Click(null, null);
                    }
                    else
                    {
                        object strMensagemErro = vobjCon.GetType().GetProperty("strMensagemErro").GetValue(vobjCon, null);
                        MessageBox.Show(strMensagemErro.ToString());
                    }
                }
                else
                    if (Status == csConstantes.sAlterando)
                    {
                        MethodInfo Alterar = tobjCon.GetMethod("Alterar");
                        object bAlterar = Alterar.Invoke(Alterar, new object[] { });

                        if ((bool)bAlterar)
                        {
                            base.tsbSalvar_Click(sender, e);
                            ControleCampos(pnForm.Controls, false);
                            PreencheDadosGridView();
                            btnConsultar_Click(null, null);
                        }
                        else
                        {
                            object strMensagemErro = vobjCon.GetType().GetProperty("strMensagemErro").GetValue(vobjCon, null);
                            MessageBox.Show(strMensagemErro.ToString());
                        }
                    }
            }
        }

        public override void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(csMensagem.msgConfirmaRemocao, "",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No)
                return;


            object vobjCon;

            CarregaObjeto(out vobjCon);

            Type tobjCon = vobjCon.GetType();

            MethodInfo Excluir = tobjCon.GetMethod("Excluir");
            object bExcluir = Excluir.Invoke(Excluir, new object[] { });

            if (!(bool)bExcluir)
            {
                object strMensagemErro = vobjCon.GetType().GetProperty("strMensagemErro").GetValue(vobjCon, null);
                MessageBox.Show(strMensagemErro.ToString());
            }
            else
            {
                PreencheDadosGridView();
                base.tsbExcluir_Click(sender, e);
                tsbLimpar_Click(null, null);
            }

            btnConsultar_Click(null, null);
        }

        public virtual void btnFirst_Click(object sender, EventArgs e)
        {
            if (dtDados != null && dtDados.Rows.Count > 0)
            {
                drLinha = dtDados.NewRow();
                if (ControleRegistroNaoSalvoContinua())
                {
                    _PosCursorDt = 0;
                    drLinha = dtDados.Rows[_PosCursorDt];
                    CarregaDados(drLinha);
                }
            }
        }

        public virtual void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dtDados != null && dtDados.Rows.Count > 0)
            {
                drLinha = dtDados.NewRow();
                if (ControleRegistroNaoSalvoContinua() && _PosCursorDt > 0)
                {
                    drLinha = dtDados.Rows[--_PosCursorDt];
                    CarregaDados(drLinha);
                }
            }
        }

        public virtual void btnNext_Click(object sender, EventArgs e)
        {
            if (dtDados != null && dtDados.Rows.Count > 0)
            {
                drLinha = dtDados.NewRow();
                if (ControleRegistroNaoSalvoContinua() && _PosCursorDt < dtDados.Rows.Count - 1)
                {
                    drLinha = dtDados.Rows[++_PosCursorDt];
                    CarregaDados(drLinha);
                }
            }
        }

        public virtual void btnLast_Click(object sender, EventArgs e)
        {
            if (dtDados != null && dtDados.Rows.Count > 0)
            {
                drLinha = dtDados.NewRow();
                if (ControleRegistroNaoSalvoContinua())
                {
                    _PosCursorDt = dtDados.Rows.Count - 1;
                    drLinha = dtDados.Rows[_PosCursorDt];
                    CarregaDados(drLinha);
                }
            }
        }

        private void tcCadastro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tpCorrente == tpFormulario && tcCadastro.SelectedTab == tpConsulta)
            {
                ControleRegistroNaoSalvoContinua();
            }

            _tpCorrente = tcCadastro.SelectedTab;
        }

        public override bool ControleRegistroNaoSalvoContinua()
        {
            if (Status.ToString().Trim() != "")
            {
                if (MessageBox.Show(csMensagem.msgRegistroEmEdicao, csMensagem.msgNomeSistema,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tsbLimpar_Click(null, null);
                }
                else
                {
                    tcCadastro.SelectedTab = tpFormulario;
                    return false;
                }
            }

            return true;
        }

        public virtual void CarregaDados(DataRow drDados)
        {
            tsbEditar.Enabled = true;
            tsbExcluir.Enabled = true;

            PreencheComponentesTela(pnForm.Controls, drDados);
        }

        public virtual void PreencheComponentesTela(Control.ControlCollection Controles, DataRow drDados)
        {
            foreach (var control in Controles)
            {
                if (control is KuraFrameWork.Componentes_Visuais.ucTextBox)
                    ((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Text = drDados[((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Name].ToString();
                if (control is KuraFrameWork.Componentes_Visuais.ucTextBoxMask)
                    ((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).Text = drDados[((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).Name].ToString();
                if (control is KuraFrameWork.Componentes_Visuais.ucConsulta)
                {
                    ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).txtCodigo.Text = drDados[((KuraFrameWork.Componentes_Visuais.ucConsulta)control).Name].ToString();
                    ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).txtCodigo_Leave(null, null);
                }
            }

            //CarregaObjeto();
        }

        public virtual void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDados.DataSource != null && dgvDados.Rows.Count > 0)
            {
                _PosCursorDt = dgvDados.CurrentRow.Index;
                drLinha = dtDados.Rows[_PosCursorDt];
                CarregaDados(drLinha);
            }
        }

        public virtual void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDados_CellClick(sender, e);
            tcCadastro.SelectedTab = tpFormulario;
        }

        public virtual void PreencheDadosGridViewFiltro()
        {
            for (int i = 0; i < dgvDados.ColumnCount; i++)
            {
                if (dgvDados.Columns[i].Visible)
                    dgvFiltro.Rows.Add(dgvDados.Columns[i].DataPropertyName, dgvDados.Columns[i].HeaderText, "", "", "");
            }
        }

        private void dgvFiltro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFiltro.CurrentCell.ColumnIndex == 2 && dgvFiltro.CurrentCell.Value.ToString() == "Entre")
            {
                dgvFiltro.CurrentRow.Cells[4].ReadOnly = false;
            }
            else
                if (dgvFiltro.CurrentCell.ColumnIndex == 2 && dgvFiltro.CurrentCell.Value.ToString() != "Entre")
                {
                    dgvFiltro.CurrentRow.Cells[4].ReadOnly = true;
                    dgvFiltro.CurrentRow.Cells[4].Value = "";
                }
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvFiltro.Rows.Count; i++)
            {
                dgvFiltro.Rows[i].Cells[2].Value = "";
                dgvFiltro.Rows[i].Cells[3].Value = "";
                dgvFiltro.Rows[i].Cells[4].Value = "";
                dgvFiltro.Rows[i].Cells[4].ReadOnly = true;
            }

            btnConsultar_Click(null, null);
        }

        public override void ControleCampos(Control.ControlCollection Controles, bool bStatus)
        {
            base.ControleCampos(Controles, bStatus);

            btnFirst.Enabled = true;
            btnLast.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = true;
        }

        public override bool CampoObrigatorioNaoPreenchido(Control.ControlCollection Controles)
        {
            return base.CampoObrigatorioNaoPreenchido(Controles);
        }

        public virtual void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Type tobjCon = _objCon.GetType();

                object vobjCon = Activator.CreateInstance(tobjCon);
                PropertyInfo pobjCo = vobjCon.GetType().GetProperty("objCo");

                object objCo = tobjCon.GetProperty("objCo").GetValue(_objCon, null);
                Type tobjCo = objCo.GetType();

                //Busca o Filtro do objCa
                object nmTabela = _tobjCa.GetProperty("nmTabela").GetValue(_tobjCa, null);

                //Seta o Filtro
                PropertyInfo strFiltro = tobjCo.GetProperty("strFiltro");
                strFiltro.SetValue(objCo, MontarFiltroConsulta(dgvFiltro, nmTabela.ToString()), null);

                MethodInfo Select = vobjCon.GetType().GetMethod("Select");
                object bSelect = Select.Invoke(Select, new object[] { });

                if ((bool)bSelect)
                {
                    PropertyInfo pdtDados = tobjCon.GetProperty("dtDados");
                    dtDados = (DataTable)pdtDados.GetValue(_objCon, null);
                    dgvDados.DataSource = dtDados;
                }
                else
                {
                    object strMensagemErro = vobjCon.GetType().GetProperty("strMensagemErro").GetValue(vobjCon, null);
                    MessageBox.Show(strMensagemErro.ToString());
                }
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucConsultaBasicaNormal.btnConsultar_Click");
            }
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtDados = SortDataTable(dtDados, dgvDados.Columns[e.ColumnIndex].DataPropertyName);
        }

        private void ucCadastroBasicoNormal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Help\\HELP - " + this.Text + ".pdf");
            }
        }

        public virtual void ucCadastroBasicoNormal_Load(object sender, EventArgs e)
        {
            MontaGridViewDinamico();
            PreencheDadosGridView();
            PreencheDadosGridViewFiltro();
            ControleCampos(pnForm.Controls, false);

            try
            {
                Type type = _objCon.GetType();
                PropertyInfo propertySet = type.GetProperty("dtDados");
                propertySet.SetValue(_objCon, dtDados, null);
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucCadastroBasicoNormal.ucCadastroBasicoNormal_Load");
            }                    
        }

        public override void MontaGridViewDinamico()
        {
            try
            {
                PropertyInfo[] properties = _tobjCa.GetProperties();
                MethodInfo RetornarFields = _tobjCa.GetMethod("RetornarFields");
                RetornarFields.Invoke(RetornarFields, new object[] {});

                foreach (var property in properties)
                {
                    string name = property.Name;
                    object temp = _tobjCa.GetProperty(name).GetValue(_tobjCa, null);

                    if (property.Name.Equals("strFields"))
                        strFields = temp.ToString();
                    else if(property.Name.Equals("strVisivel"))
                        strVisivel = temp.ToString();
                    else if (property.Name.Equals("strNome"))
                        strNome = temp.ToString();
                }

                MontarDataGridView(dgvDados, strFields, strVisivel, strNome);
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucCadastroBasicoNormal.MontaGridViewDinamico");
            }
        }

        public virtual void PreencheDadosGridView()
        {
            try
            {
                Type tobjCon = _objCon.GetType();
                MethodInfo Select = tobjCon.GetMethod("Select");
                object bSelect = Select.Invoke(Select, new object[] { });

                if ((bool)bSelect)
                {
                    PropertyInfo pdtDados = tobjCon.GetProperty("dtDados");
                    dtDados = (DataTable)pdtDados.GetValue(_objCon, null);
                    dgvDados.DataSource = dtDados;
                }
                else
                {
                    object strMensagemErro = _objCon.GetType().GetProperty("strMensagemErro").GetValue(_objCon, null);
                    MessageBox.Show(strMensagemErro.ToString());
                }
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucCadastroBasicoNormal.PreencheDadosGridView");
            }
        }

        public virtual void CarregaObjeto(out object pObjCon)
        {
            object nmCampoChave = _tobjCa.GetProperty("nmCampoChave").GetValue(_tobjCa, null);

            Type tobjCon = _objCon.GetType();

            object vobjCon = Activator.CreateInstance(tobjCon);
            PropertyInfo pobjCo = vobjCon.GetType().GetProperty("objCo");

            object objCo = tobjCon.GetProperty("objCo").GetValue(_objCon, null);
            Type tobjCo = objCo.GetType();

            PropertyInfo pCampo;
            object temp;

            foreach (var control in pnForm.Controls)
            {
                if (control is KuraFrameWork.Componentes_Visuais.ucTextBox)
                {
                    if (((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Name != nmCampoChave.ToString() || Status != csConstantes.sInserindo)
                    {
                        pCampo = tobjCo.GetProperty(((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Name);

                        temp = tobjCo.GetProperty(((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Name).GetValue(objCo, null);

                        if (temp is int)
                            pCampo.SetValue(objCo, Convert.ToInt32(((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Text), null);
                        else
                            if (temp is string)
                                pCampo.SetValue(objCo, ((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Text, null);
                    }
                }
                else
                    if (control is KuraFrameWork.Componentes_Visuais.ucTextBoxMask)
                    {
                        if (((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).Name != nmCampoChave.ToString() || Status != csConstantes.sInserindo)
                        {
                            pCampo = tobjCo.GetProperty(((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).Name);

                            temp = tobjCo.GetProperty(((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).Name).GetValue(objCo, null);

                            if (temp is int)
                                pCampo.SetValue(objCo, Convert.ToInt32(((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).PegaTexto()), null);
                            else
                                if (temp is string)
                                    pCampo.SetValue(objCo, ((KuraFrameWork.Componentes_Visuais.ucTextBoxMask)control).Text, null);
                        }
                    }
                    else
                        if (control is KuraFrameWork.Componentes_Visuais.ucConsulta)
                        {
                            if (((KuraFrameWork.Componentes_Visuais.ucConsulta)control).Name != nmCampoChave.ToString() || Status != csConstantes.sInserindo)
                            {
                                pCampo = tobjCo.GetProperty(((KuraFrameWork.Componentes_Visuais.ucConsulta)control).Name);

                                temp = tobjCo.GetProperty(((KuraFrameWork.Componentes_Visuais.ucConsulta)control).Name).GetValue(objCo, null);

                                if (temp is int)
                                    pCampo.SetValue(objCo, ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).cdRegistro, null);
                                else
                                    if (temp is string)
                                        pCampo.SetValue(objCo, ((KuraFrameWork.Componentes_Visuais.ucConsulta)control).txtCodigo.Text, null);
                            }
                        }
            }

            pObjCon = vobjCon;
        }

        public virtual void AtualizaCodigo(string pCodigo, string pCampoChave)
        {
            foreach (var control in pnForm.Controls)
            {
                if (control is KuraFrameWork.Componentes_Visuais.ucTextBox)
                {
                    if (((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Name == pCampoChave.ToString())
                    {
                        ((KuraFrameWork.Componentes_Visuais.ucTextBox)control).Text = pCodigo;
                    }
                }
            }
        }

        /// <summary>
        /// Implementar dinamicamente após a integração do gerenciador de relatórios com o KuraFremeWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void tsbImprimir_ButtonClick(object sender, EventArgs e)
        {
            //conRelatorio objConRelatorio = new conRelatorio();
            //caRelatorios objCaRelatorios = new caRelatorios();

            //objConRelatorio.objCoRelatorios.nmRelatorio = "crAcoes.rpt";

            //if (!objConRelatorio.Select())
            //{
            //    MessageBox.Show(objConRelatorio.strMensagemErro);
            //    return;
            //}

            //base.tsbImprimir_ButtonClick(sender, e);
            //appRelatorios.frmGerenciadorRPT frm = new appRelatorios.frmGerenciadorRPT();
            //frm.GerarRelatorio(Convert.ToInt32(objConRelatorio.dtDados.Rows[0][objCaRelatorios.cdRelatorio].ToString()), dtDados);
        }
    }
}
