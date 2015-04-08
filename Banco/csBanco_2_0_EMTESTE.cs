using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using System.Reflection;
using System.Text;

namespace KuraFrameWork.Banco
{
    public class csBanco_2_0_EMTESTE
    {
        private static volatile csBanco_2_0_EMTESTE instance;

        /// <summary>
        /// String de conexão
        /// </summary>
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
        /// Filtro avançado
        /// </summary>
        private string _strFiltro;
        public string strFiltro
        {
            get { return _strFiltro; }
            set { _strFiltro = value; }
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
        /// Variável que armazena a transação
        /// </summary>
        private OracleTransaction _Transacao;
        public OracleTransaction transacao
        {
            get { return _Transacao; }
            set { _Transacao = value; }
        }

        /// <summary>
        /// Define se a conexão está em transação
        /// </summary>
        private bool _bEmTransacao = false;
        public bool bEmTransacao
        {
            get { return _bEmTransacao; }
            set { _bEmTransacao = value; }
        }

        /// <summary>
        /// Variável de conexão com o SGBD
        /// </summary>
        private OracleConnection _conexao;

        /// <summary>
        /// Variável de comando do sql
        /// </summary>
        private OracleCommand _comando;

        /// <summary>
        /// Type do ObjCO
        /// </summary>
        private Type _tobjCO;

        /// <summary>
        /// Propriedados do ObjCO
        /// </summary>
        private PropertyInfo[] _pobjCO;

        /// <summary>
        /// Type do ObjCA
        /// </summary>
        private Type _tobjCA;
        public Type tobjCA
        {
            get { return _tobjCA; }
            set { _tobjCA = value; }
        }

        /// <summary>
        /// Objeto a ser manipulado pelo banco
        /// </summary>
        private object _objCO;
        public object objCO
        {
            get { return _objCO; }
            set { 
                _objCO = value;
                _tobjCO = _objCO.GetType();
                _pobjCO = _tobjCO.GetProperties();
            }
        }

        /// <summary>
        /// Create do banco de dados
        /// </summary>
        private csBanco_2_0_EMTESTE()
        {
            _strStringConexao = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = XE))); User Id=SansERP; Password=SansERP";
            _conexao = new OracleConnection(_strStringConexao);
            _comando = new OracleCommand();
            _comando.Connection = _conexao;
            _Transacao = null;
        }

        /// <summary>
        /// Instancia do banco
        /// </summary>
        public static csBanco_2_0_EMTESTE Instance
        {
            get
            {
                if (instance == null)
                    instance = new csBanco_2_0_EMTESTE();

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
                if (_conexao.State == ConnectionState.Closed)
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
                    _bEmTransacao = true;
                    transacao = _conexao.BeginTransaction();
                    return true;
                }
            }
            catch { }

            _bEmTransacao = true;
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
                    _bEmTransacao = false;
                    DesconectaBanco();
                    return true;
                }
            }
            catch { }

            _bEmTransacao = false;
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
                    DesconectaBanco();
                    return true;
                }
            }
            catch { }

            DesconectaBanco();
            return false;
        }

        /// <summary>
        /// Retorna a condição com a chave composta
        /// </summary>
        /// <returns></returns>
        private string RetornaCondicaoChaveComposta()
        {
            string strCondicao = "";
            if (_tobjCA.GetProperty("deChaveComposta").GetValue(_tobjCA, null).ToString() != "" && _tobjCA.GetProperty("deChaveComposta").GetValue(_tobjCA, null).ToString() != "[ChComposta]")
            {
                strCondicao = " WHERE ";
                string[] strSeparador = new string[] { ";" };
                string[] strChaveComposta = _tobjCA.GetProperty("deChaveComposta").GetValue(_tobjCA, null).ToString().Split(strSeparador, StringSplitOptions.RemoveEmptyEntries);

                foreach (string strCampo in strChaveComposta)
                {
                    strCondicao += " strCampo = " + _tobjCA.GetProperty(strCampo).GetValue(_tobjCA, null).ToString() + " AND ";
                }

                strCondicao = strCondicao.Substring(0, strCondicao.Length - 5);
            }

            return strCondicao;
        }

        /// <summary>
        /// Gera o código do próximo registro para determinada tabela
        /// </summary>
        /// <returns></returns>
        public int GerarCodigo()
        {
            DataTable dtDados = new DataTable();

            if (Convert.ToBoolean(_tobjCA.GetProperty("_bGeraChave").GetValue(_tobjCA, null).ToString()))
                ConectaBanco();

             if (_conexao.State == System.Data.ConnectionState.Open)
             {
                 _comando.CommandText = "SELECT NVL(MAX(" + _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString() + "), 0) + 1 " +
                                        "  FROM " + _tobjCA.GetProperty("nmTabela").GetValue(_tobjCA, null).ToString();
                 _comando.CommandText += RetornaCondicaoChaveComposta();
                 dtDados.Load(_comando.ExecuteReader());

                 if (Convert.ToBoolean(_tobjCA.GetProperty("_bControlaTransacao").GetValue(_tobjCA, null).ToString()))
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

            foreach (var property in _pobjCO)
            {
                string name = property.Name;
                object temp = _objCO.GetType().GetProperty(name).GetValue(objCO, null);

                if (property.Name != "strFiltro")
                {
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
                                                    if (Convert.ToDateTime(temp.ToString()).Year != 1)
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
            }

            strSql = "Select " + strProjecao.Substring(0, strProjecao.Length - 1).ToString() +
                     "  from " + _tobjCA.GetProperty("nmTabela").GetValue(_tobjCA, null).ToString();

            if (_strFiltro != "")
                strSql += _strFiltro;
            else
                if (strParametros != "")
                    strSql += " where " + strParametros.Substring(0, strParametros.Length - 4).ToString();


            return RetornaDT(strSql);
        }

        //
        //FAZER UM SELECT QUE CONSIDERE AS CHAVES ESTRANGEIRAS E REALIZE O RETORNO EM UM DATA SET
        //

        /// <summary>
        /// Método para fazer a inserção montando dinâmicamente
        /// </summary>
        /// <returns></returns>
        public bool Inserir()
        {
            string strSql = "";
            string strAtributos = "";
            string strValores = "";

            foreach (var property in _pobjCO)
            {
                string name = property.Name;
                object temp = _objCO.GetType().GetProperty(property.Name).GetValue(objCO, null);

                if (!property.Name.Substring(0, 3).Equals("CC_") && !property.Name.Equals("strFiltro"))
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) || (temp is float) ||
                        (temp is decimal) || (temp is DateTime) || (temp is char) || (temp is bool))
                    {
                        if ((!Convert.ToBoolean(_tobjCA.GetProperty("_bGeraChave").GetValue(_tobjCA, null).ToString())) ||
                            (property.Name.ToString() != _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString() &&
                             Convert.ToBoolean(_tobjCA.GetProperty("_bGeraChave").GetValue(_tobjCA, null).ToString())))
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

            if (Convert.ToBoolean(_tobjCA.GetProperty("_bGeraChave").GetValue(_tobjCA, null).ToString()))
            {
                _cdChave = GerarCodigo();

                strSql = "Insert Into " + _tobjCA.GetProperty("nmTabela").GetValue(_tobjCA, null).ToString() + " (" + _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString() + "," + strAtributos.Substring(0, strAtributos.Length - 1) + ") " +
                         " Values(" + _cdChave.ToString() + "," + strValores.Substring(0, strValores.Length - 1) + ")";
            }
            else
                strSql = "Insert Into " + _tobjCA.GetProperty("nmTabela").GetValue(_tobjCA, null).ToString() + " (" + strAtributos.Substring(0, strAtributos.Length - 1) + ") " +
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
            string strCondicaoChaveComposta = "";

            foreach (var property in _pobjCO)
            {
                string name = property.Name;
                object temp = _objCO.GetType().GetProperty(property.Name).GetValue(objCO, null);

                if (!property.Name.Substring(0, 3).Equals("CC_") && !property.Name.Equals("strFiltro"))
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) || 
                        (temp is float) || (temp is decimal) || (temp is DateTime) || 
                        (temp is char) || (temp is bool) || (temp is byte[]))
                    {

                        if (property.Name.ToString() != _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString())
                        {
                            strAtualizacoes += property.Name.ToString() + " = ";

                            if ((temp is string) || (temp is DateTime) || (temp is char))
                                strAtualizacoes += "'" + temp.ToString() + "',";
                            else
                                strAtualizacoes += temp.ToString() + ",";
                        }
                        else
                            strCondicao = " Where " + _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString() + " = " + temp.ToString();
                    }
                }
            }

            strCondicaoChaveComposta = RetornaCondicaoChaveComposta();
            if (strCondicaoChaveComposta != "")
                strCondicao += " AND " + RetornaCondicaoChaveComposta();

            strSql = "Update " + _tobjCA.GetProperty("nmTabela").GetValue(_tobjCA, null).ToString() + 
                     "   Set " + strAtualizacoes.Substring(0, strAtualizacoes.Length - 1) + strCondicao;

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
            string strCondicaoChaveComposta = "";

            foreach (var property in _pobjCO)
            {
                string name = property.Name;
                object temp = _objCO.GetType().GetProperty(property.Name).GetValue(objCO, null);
                if (!property.Name.Substring(0, 3).Equals("CC_"))
                {
                    if ((temp is string) || (temp is int) || (temp is Int64) || (temp is float) ||
                        (temp is decimal) || (temp is DateTime) || (temp is char) || (temp is bool))
                    {
                        if (property.Name.ToString() == _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString())
                            strCondicao = " Where " + _tobjCA.GetProperty("nmCampoChave").GetValue(_tobjCA, null).ToString() + " = " + temp.ToString();
                    }
                }
            }

            strCondicaoChaveComposta = RetornaCondicaoChaveComposta();
            if (strCondicaoChaveComposta != "")
                strCondicao += " AND " + RetornaCondicaoChaveComposta();

            strSql = "Delete From " + _tobjCA.GetProperty("nmTabela").GetValue(_tobjCA, null).ToString() + strCondicao;

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

                if (!_bEmTransacao)
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

                if (!_bEmTransacao)
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
                if (ConectaBanco())
                {
                    _comando.Transaction = _Transacao;
                    _comando.CommandText = sSQL;
                    iLinhas = _comando.ExecuteNonQuery();

                    if (Convert.ToBoolean(_tobjCA.GetProperty("_bControlaTransacao").GetValue(_tobjCA, null).ToString()))
                        DesconectaBanco();
                }
            }
            catch
            {
                if (Convert.ToBoolean(_tobjCA.GetProperty("_bControlaTransacao").GetValue(_tobjCA, null).ToString()))
                    DesconectaBanco();
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