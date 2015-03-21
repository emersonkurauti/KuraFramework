using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using System.Reflection;
using System.Text;

namespace KuraFrameWork.Personalizado.Banco
{
    /// <summary>
    /// Classe de Banco
    /// </summary>
    public class csBancoTask
    {
        private static volatile csBancoTask instance;

        private string _strStringConexao = "";
        public string strStringConexao
        {
            get { return _strStringConexao; }
            set { _strStringConexao = value; }
        }

        /// <summary>
        /// Usuário ativo para gravar log de operações
        /// </summary>
        private int _cdUsuario;
        public int cdUsuario
        {
            get { return _cdUsuario; }
            set { _cdUsuario = value; }
        }

        /// <summary>
        /// Tabela que será utilizada
        /// </summary>
        private string _strTabela;
        public string strTabela
        {
            get { return _strTabela; }
            set { _strTabela = value; }
        }

        /// <summary>
        /// Campo chave primária auto incremento
        /// </summary>
        private string _strCampoChave;
        public string strCampoChave
        {
            get { return _strCampoChave; }
            set { _strCampoChave = value; }
        }

        /// <summary>
        /// Campo chave primária estrangeira
        /// </summary>
        private string _strCampoChaveFK = "";
        public string strCampoChaveFK
        {
            get { return _strCampoChaveFK; }
            set { _strCampoChaveFK = value; }
        }

        /// <summary>
        /// Valor string da chave estrangeira 
        /// </summary>
        private string _strValorCampoChaveFK = "";
        public string strValorCampoChaveFK
        {
            get { return _strValorCampoChaveFK; }
            set { _strValorCampoChaveFK = value; }
        }

        /// <summary>
        /// Filtro avançado
        /// </summary>
        private string _strFiltro;
        public string strFiltro
        {
            get { return _strFiltro; }
            set { _strFiltro = value; }
        }

        /// <summary>
        /// Variável que armazena a transação
        /// </summary>
        private OracleTransaction _Transacao;
        public OracleTransaction transacao
        {
            get { return _Transacao; }
            set { _Transacao = value; }
        }

        /// <summary>
        /// Define se vai controlar a conxao automático
        /// </summary>
        private bool _bControlaConxao;
        public bool bControlaConxao
        {
            get { return _bControlaConxao; }
            set { _bControlaConxao = value; }
        }

        /// <summary>
        /// Armazena a ultima chave gerada
        /// </summary>
        private int _cdChave;
        public int cdChave
        {
            get { return _cdChave; }
            set { _cdChave = value; }
        }

        /// <summary>
        /// Define a necessidade de de gerar código
        /// </summary>
        private bool _bGerarChave = true;
        public bool bGerarChave
        {
            get { return _bGerarChave; }
            set { _bGerarChave = value; }
        }

        /// <summary>
        /// Variável de conexão com o SGDB
        /// </summary>
        private OracleConnection _conexao;

        /// <summary>
        /// Variável de comando do sql
        /// </summary>
        private OracleCommand _comando;

        /// <summary>
        /// Objeto a ser manipulado pelo banco
        /// </summary>
        private object _obj;
        public object obj
        {
            get { return _obj; }
            set { _obj = value; }
        }

        /// <summary>
        /// Create do banco de dados
        /// </summary>
        private csBancoTask()
        {
            //string sStringConexao = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Dados.mdf;Integrated Security=True;Connect Timeout=30";
            //string connection = "Data 
            //Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=dani)(PORT=1521)))
            //(CONNECT_DATA=(SERVICE_NAME=xe))); User Id=system; Password=dani";
            if (_strStringConexao == "")
                _strStringConexao = csConstantes.strStringConexaoTASK;
            _conexao = new OracleConnection(_strStringConexao);
            _comando = new OracleCommand();
            _comando.Connection = _conexao;
            _bControlaConxao = true;
            _Transacao = null;
        }

        /// <summary>
        /// Instancia do banco
        /// </summary>
        public static csBancoTask Instance
        {
            get
            {
                if (instance == null)
                    instance = new csBancoTask();

                return instance;
            }
        }

        /// <summary>
        /// Conecta no banco de dados
        /// </summary>
        /// <returns></returns>
        public bool ConectaBanco()
        {
            try
            {
                _conexao.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Desconecta do banco de dados
        /// </summary>
        /// <returns></returns>
        public bool DesconectaBanco()
        {
            try
            {
                _conexao.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Inicia transação
        /// </summary>
        /// <returns></returns>
        public bool BeginTransaction()
        {
            try
            {
                if (ConectaBanco())
                {
                    _bControlaConxao = false;
                    transacao = _conexao.BeginTransaction();
                    return true;
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// Efetiva transação
        /// </summary>
        /// <returns></returns>
        public bool CommitTransaction()
        {
            try
            {
                if ((_conexao != null) && (transacao != null) && (_conexao.State == System.Data.ConnectionState.Open))
                {
                    transacao.Commit();
                    transacao = null;
                    _bControlaConxao = true;
                    DesconectaBanco();
                    return true;
                }
            }
            catch { }

            DesconectaBanco();
            return true;
        }

        /// <summary>
        /// Desfaz as alterações
        /// </summary>
        /// <returns></returns>
        public bool RollbackTransaction()
        {
            try
            {
                if ((_conexao != null) && (transacao != null) && (_conexao.State == System.Data.ConnectionState.Open))
                {
                    transacao.Rollback();
                    transacao = null;
                    _bControlaConxao = true;
                    DesconectaBanco();
                    return true;
                }
            }
            catch { }

            DesconectaBanco();
            return false;
        }

        /// <summary>
        /// Gera o código do próximo registro para determinada tabela
        /// </summary>
        /// <returns></returns>
        public int GerarCodigo()
        {
            DataTable dtDados = new DataTable();

            if (_bControlaConxao)
                ConectaBanco();

            if (_conexao.State == System.Data.ConnectionState.Open)
            {
                _comando.CommandText = "SELECT NVL(MAX(" + _strCampoChave + "), 0) + 1 FROM " + _strTabela;

                if (_strCampoChaveFK != "")
                    _comando.CommandText += " Where " + _strCampoChaveFK + "='" + _strValorCampoChaveFK + "'"; 

                dtDados.Load(_comando.ExecuteReader());

                if (_bControlaConxao)
                    DesconectaBanco();
            }

            return Convert.ToInt32(dtDados.Rows[0][0].ToString());
        }

        /// <summary>
        /// Método para fazer select default com parametros dinâmicos
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataTable Select()
        {
            string strSql = "";
            string strProjecao = "";
            string strParametros = "";

            Type type = _obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                string name = property.Name;
                object temp = _obj.GetType().GetProperty(name).GetValue(obj, null);

                if (property.Name.Substring(0, 3).Equals("CC_"))
                    strProjecao += "'' as " + name + ",";
                else
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) || (temp is float) ||
                        (temp is decimal) || (temp is DateTime) || (temp is char) || (temp is bool))
                        strProjecao += name + ",";

                    if (_strFiltro == "")
                    {
                        if (temp is string)
                        {
                            if (temp.ToString() != "")
                                strParametros += name.ToString() + "='" + temp.ToString() + "' AND ";
                        }
                        else
                            if (temp is char)
                            {
                                if (Convert.ToChar(temp.ToString()) != ' ')
                                    strParametros += name.ToString() + "='" + temp.ToString() + "' AND ";
                            }
                            else
                                if (temp is int)
                                {
                                    if (Convert.ToInt32(temp.ToString()) != 0)
                                        strParametros += name.ToString() + "=" + temp.ToString() + " AND ";
                                }
                                else
                                    if (temp is Int64)
                                    {
                                        if (Convert.ToInt64(temp.ToString()) != 0)
                                            strParametros += name.ToString() + "=" + temp.ToString() + " AND ";
                                    }
                                    else
                                        if ((temp is float) || (temp is decimal))
                                        {
                                            if (Convert.ToDecimal(temp.ToString()) != 0)
                                                strParametros += name.ToString() + "=" + temp.ToString() + " AND ";
                                        }
                                        else
                                            if (temp is DateTime)
                                            {
                                                if (Convert.ToDateTime(temp.ToString()) != null)
                                                    strParametros += name.ToString() + "='" + temp.ToString().Substring(0, 2) +
                                                                                                "-" + temp.ToString().Substring(3, 2) +
                                                                                                "-" + temp.ToString().Substring(6, 4) + "' AND ";
                                            }
                                            else
                                                if (temp is bool)
                                                {
                                                    if (Convert.ToBoolean(temp.ToString()))
                                                        strParametros += name.ToString() + "= 1 AND ";
                                                    else
                                                        strParametros += name.ToString() + "= 0 AND ";
                                                }
                    }
                }
            }

            strSql = "Select " + strProjecao.Substring(0, strProjecao.Length - 1).ToString() +
                     "  from " + _strTabela;

            if (_strFiltro != "")
                strSql += _strFiltro;
            else
                if (strParametros != "")
                    strSql += " where " + strParametros.Substring(0, strParametros.Length - 4).ToString();


            return RetornaDT(strSql);
        }

        /// <summary>
        /// Método para fazer a inserção montando dinâmicamente
        /// </summary>
        /// <returns></returns>
        public bool Inserir()
        {
            string strSql = "";
            string strAtributos = "";
            string strValores = "";

            Type type = _obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                string name = property.Name;
                object temp = _obj.GetType().GetProperty(property.Name).GetValue(obj, null);

                if (!property.Name.Substring(0, 3).Equals("CC_"))
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) || (temp is float) ||
                        (temp is decimal) || (temp is DateTime) || (temp is char) || (temp is bool))
                    {
                        if ((!_bGerarChave) || (property.Name.ToString() != _strCampoChave && _bGerarChave))
                        {
                            strAtributos += property.Name.ToString() + ",";

                            if ((temp is string) || (temp is DateTime) || (temp is char))
                                strValores += "'" + temp.ToString() + "',";
                            else
                                strValores += temp.ToString() + ",";
                        }
                    }
                }
            }

            if (_bGerarChave)
            {
                _cdChave = GerarCodigo();

                strSql = "Insert Into " + _strTabela + " (" + _strCampoChave + "," + strAtributos.Substring(0, strAtributos.Length - 1) + ") " +
                         " Values(" + _cdChave.ToString() + "," + strValores.Substring(0, strValores.Length - 1) + ")";
            }
            else
                strSql = "Insert Into " + _strTabela + " (" + strAtributos.Substring(0, strAtributos.Length - 1) + ") " +
                         " Values(" + strValores.Substring(0, strValores.Length - 1) + ")";

            return ExecutarSQL(strSql);
        }

        /// <summary>
        /// Método para fazer o update dos dados montando dinâmicamente
        /// </summary>
        /// <returns></returns>
        public bool Alterar()
        {
            string strSql = "";
            string strAtualizacoes = "";
            string strCondicao = "";

            Type type = _obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                string name = property.Name;
                object temp = _obj.GetType().GetProperty(property.Name).GetValue(obj, null);

                if (!property.Name.Substring(0, 3).Equals("CC_"))
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) ||
                        (temp is float) || (temp is decimal) || (temp is DateTime) ||
                        (temp is char) || (temp is bool) || (temp is byte[]))
                    {

                        if (property.Name.ToString() != _strCampoChave)
                        {
                            strAtualizacoes += property.Name.ToString() + " = ";

                            if ((temp is string) || (temp is DateTime) || (temp is char))
                                strAtualizacoes += "'" + temp.ToString() + "',";
                            else
                                strAtualizacoes += temp.ToString() + ",";
                        }
                        else
                            strCondicao = " Where " + _strCampoChave + " = " + temp.ToString();
                    }
                }
            }

            strSql = "Update " + _strTabela + " Set " + strAtualizacoes.Substring(0, strAtualizacoes.Length - 1) + strCondicao;

            return ExecutarSQL(strSql);
        }

        /// <summary>
        /// Excluir registro de maneira dinâmica
        /// </summary>
        /// <returns></returns>
        public bool Excluir()
        {
            string strSql = "";
            string strCondicao = "";

            Type type = _obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                string name = property.Name;
                object temp = _obj.GetType().GetProperty(property.Name).GetValue(obj, null);
                if (!property.Name.Substring(0, 3).Equals("CC_"))
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) || (temp is float) ||
                        (temp is decimal) || (temp is DateTime) || (temp is char) || (temp is bool))
                    {
                        if (property.Name.ToString() == _strCampoChave)
                            strCondicao = " Where " + _strCampoChave + " = " + temp.ToString();
                    }
                }
            }

            strSql = "Delete From " + _strTabela + strCondicao;

            return ExecutarSQL(strSql);
        }

        /// <summary>
        /// Retorna DataTable com o select passado por parâmetro
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public DataTable RetornaDT(string sSQL)
        {
            DataTable dtDados = new DataTable();
            if (ConectaBanco())
            {
                _comando.CommandText = sSQL;
                dtDados.Load(_comando.ExecuteReader());
                DesconectaBanco();
            }
            return dtDados;
        }

        /// <summary>
        /// Retorna DataSet com select passado por parâmetro
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public DataSet RetornaDS(string sSQL)
        {
            OracleDataAdapter DataAdapter = new OracleDataAdapter();
            DataSet dsDados = new DataSet();

            if (ConectaBanco())
            {
                _comando.CommandText = sSQL;
                DataAdapter.SelectCommand = _comando;
                DataAdapter.Fill(dsDados);
                DesconectaBanco();
            }
            return dsDados;
        }

        /// <summary>
        /// Executa o sql passado por parâmetro e retorna a qtd de linhas afetadas
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public bool ExecutarSQL(string sSQL)
        {
            int iLinhas = 0;

            try
            {
                if (_bControlaConxao)
                    ConectaBanco();

                if (_conexao.State == System.Data.ConnectionState.Open)
                {
                    _comando.Transaction = _Transacao;
                    _comando.CommandText = sSQL;
                    iLinhas = _comando.ExecuteNonQuery();

                    if (_bControlaConxao)
                        DesconectaBanco();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Retorna true para caso o campo passado por parâmetro necessite usar aspas para utilização no banco de dados
        /// </summary>
        /// <param name="nmTabela"></param>
        /// <param name="nmCampo"></param>
        /// <returns></returns>
        public bool UsarAspas(string nmTabela, string nmCampo)
        {
            if (!nmCampo.Contains("CC_"))
            {
                DataTable dtCampo = new DataTable();
                string[] vstrTipoUsaAspas = new string[] { "VARCHAR", "VARCHAR2", "CHAR", "DATE" };

                dtCampo = RetornaDT("SELECT DATA_TYPE AS TIPO FROM USER_TAB_COLUMNS" +
                                    " WHERE UPPER(TABLE_NAME) = UPPER('" + nmTabela + "')" +
                                    "   AND UPPER(COLUMN_NAME) = UPPER('" + nmCampo + "')");

                foreach (string TipoCampo in vstrTipoUsaAspas)
                {
                    if (dtCampo.Rows[0][0].ToString().ToUpper() == TipoCampo)
                        return true;
                }
            }

            return false;
        }
    }
}