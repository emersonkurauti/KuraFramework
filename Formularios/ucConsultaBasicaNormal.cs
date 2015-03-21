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
    public partial class ucConsultaBasicaNormal : KuraFrameWork.Formularios.ucCadastroBasico
    {
        private Type _tobjCa;
        public Type objCa
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

        public string strFields = "", strVisivel = "", strNome = "";

        public ucConsultaBasicaNormal()
        {
            InitializeComponent();
            this.ControleFiltro(null, null);
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
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtDados = SortDataTable(dtDados, dgvDados.Columns[e.ColumnIndex].DataPropertyName);
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
                    PropertyInfo strMensagemErro = tobjCon.GetProperty("strMensagemErro");
                    MessageBox.Show(strMensagemErro.ToString());
                }
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucConsultaBasicaNormal.btnConsultar_Click");
            }
        }

        public virtual void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbSelecionar_Click(null, null);
        }

        private void ucConsultaBasicaNormal_Load(object sender, EventArgs e)
        {
            MontaGridViewDinamico();
            PreencheDadosGridView();
            PreencheDadosGridViewFiltro();

            try
            {
                Type tobjCon = _objCon.GetType();
                PropertyInfo pdtDados = tobjCon.GetProperty("dtDados");
                pdtDados.SetValue(_objCon, dtDados, null);
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucConsultaBasicaNormal.dgvDados_CellDoubleClick");
            }         
        }

        public override void MontaGridViewDinamico()
        {
            try
            {
                PropertyInfo[] properties = _tobjCa.GetProperties();
                MethodInfo RetornarFields = _tobjCa.GetMethod("RetornarFields");
                RetornarFields.Invoke(RetornarFields, new object[] { });

                foreach (var property in properties)
                {
                    string name = property.Name;
                    object temp = _tobjCa.GetProperty(name).GetValue(_tobjCa, null);

                    if (property.Name.Equals("strFields"))
                        strFields = temp.ToString();
                    else if (property.Name.Equals("strVisivel"))
                        strVisivel = temp.ToString();
                    else if (property.Name.Equals("strNome"))
                        strNome = temp.ToString();
                }

                MontarDataGridView(dgvDados, strFields, strVisivel, strNome);
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucConsultaBasicaNormal.MontaGridViewDinamico");
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
                    PropertyInfo strMensagemErro = tobjCon.GetProperty("strMensagemErro");
                    MessageBox.Show(strMensagemErro.ToString());
                }
            }
            catch
            {
                //throw new Exception("Erro no FrameWork KuraSoft: ucConsultaBasicaNormal.PreencheDadosGridView");
            }
        }
    }
}
