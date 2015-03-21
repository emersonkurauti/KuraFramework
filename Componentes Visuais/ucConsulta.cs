using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace KuraFrameWork.Componentes_Visuais
{
    public delegate void AoConsultarRegistroEventHandler();

    public partial class ucConsulta : UserControl
    {
        private bool _bCadastrar = true;
        public bool bCadastrar
        {
            get { return _bCadastrar; }
            set
            {
                _bCadastrar = value;
                SetBCadastrar(value);
            }
        }

        private string _Rotulo;
        public string Rotulo
        {
            get { return _Rotulo; }
            set
            {
                _Rotulo = value;
                lblRotulo.Text = value;
            }
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

        private string _TelaConsulta;
        public string TelaConsulta
        {
            get { return _TelaConsulta; }
            set { _TelaConsulta = value; }
        }

        private int cdAnterior = 0;

        private bool _bMudouCodigo = false;
        public bool bMudouCodigo
        {
            get { return _bMudouCodigo; }
            set { _bMudouCodigo = value; }
        }

        public event AoConsultarRegistroEventHandler AoConsultarRegistro;

        protected virtual void OnAoConsultarRegistro()
        {
            if (AoConsultarRegistro != null)
                AoConsultarRegistro();
        }

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

        private Type _tfrmConsulta;
        public Type tfrmConsulta
        {
            get { return _tfrmConsulta; }
            set { _tfrmConsulta = value; }
        }

        private int _cdRegistro;
        public int cdRegistro
        {
            get { return _cdRegistro; }
            set { _cdRegistro = value; }
        }

        private string _deRegistro;
        public string deRegistro
        {
            get { return _deRegistro; }
            set { _deRegistro = value; }
        }

        public ucConsulta()
        {
            InitializeComponent();
        }

        public void SetBCadastrar(bool bVisible)
        {
            btnCadastrar.Visible = bVisible;
        }

        public void LimparCampos()
        {
            txtCodigo.Text = "";
            _cdRegistro = 0;
            txtDescricao.Text = "";
            _deRegistro = "";
            cdAnterior = 0;
            bMudouCodigo = false;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                btnConsultar_Click(null, null);
        }

        public virtual void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                object form = Activator.CreateInstance(_tfrmConsulta);
                ((Form)form).ShowDialog();

                object cdRegistro = form.GetType().GetProperty("cdRegistro").GetValue(form, null);
                object deRegistro = form.GetType().GetProperty("deRegistro").GetValue(form, null);

                if ((int)cdRegistro != 0)
                {
                    txtCodigo.Text = cdRegistro.ToString();
                    _cdRegistro = Convert.ToInt32(txtCodigo.Text);
                    txtDescricao.Text = deRegistro.ToString();
                    _deRegistro = txtDescricao.Text;
                }

                AtualizaCodigo();
            }
            catch 
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucConsulta.btnConsultar_Click");
            }
        }

        public virtual void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (Convert.ToInt32(txtCodigo.Text) > 0)
                {
                    try
                    {
                        Type tobjCon = _objCon.GetType();

                        object vobjCon = Activator.CreateInstance(tobjCon);
                        PropertyInfo pobjCo = vobjCon.GetType().GetProperty("objCo");

                        object objCo = tobjCon.GetProperty("objCo").GetValue(_objCon, null);
                        Type tobjCo = objCo.GetType();

                        //Código
                        PropertyInfo cdRegistro = objCo.GetType().GetProperty("CC_cdRegistro");
                        cdRegistro.SetValue(objCo, Convert.ToInt32(txtCodigo.Text), null);

                        MethodInfo Select = tobjCon.GetMethod("Select");
                        Select.Invoke(Select, new object[] { });

                        PropertyInfo pdtDados = tobjCon.GetProperty("dtDados");
                        DataTable dtDados = (DataTable)pdtDados.GetValue(_objCon, null);

                        object campoChave = _tobjCa.GetProperty("nmCampoChave").GetValue(_tobjCa, null);
                        object campoDescricao = _tobjCa.GetProperty("dePrincipal").GetValue(_tobjCa, null);

                        if (dtDados.Rows.Count > 0)
                        {
                            txtCodigo.Text = dtDados.Rows[0][campoChave.ToString()].ToString();
                            _cdRegistro = Convert.ToInt32(txtCodigo.Text);
                            txtDescricao.Text = dtDados.Rows[0][campoDescricao.ToString()].ToString();
                            _deRegistro = txtDescricao.Text;
                        }
                        else
                        {
                            LimparCampos();
                            MessageBox.Show(csMensagem.msgErroConsultar);
                        }

                        AtualizaCodigo();
                    }
                    catch 
                    {
                        //throw new Exception("Erro no FrameWork KuraSoft: ucConsulta.txtCodigo_Leave");
                    }
                }
                else
                {
                    LimparCampos();
                    MessageBox.Show(csMensagem.msgErroValorInvalido);
                }
            }
            else
            {
                LimparCampos();
            }
        }

        private void txtCodigo_DoubleClick(object sender, EventArgs e)
        {
            btnConsultar_Click(null, null);
        }

        private void ucConsulta_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip.SetToolTip(this.txtCodigo, "Dois cliques ou F5 para abrir a pesquisa");
        }

        private void AtualizaCodigo()
        {
            int iCodigo;
            bMudouCodigo = false;
            int.TryParse(txtCodigo.Text, out iCodigo);

            if (cdAnterior != iCodigo)
            {
                cdAnterior = Convert.ToInt32(txtCodigo.Text);
                bMudouCodigo = true;
            }

            OnAoConsultarRegistro();
        }
    }
}
