using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KuraFrameWork.ClasseBase
{
    public class csControllerBase
    {
        protected static string _strMensagemErro;
        public string strMensagemErro
        {
            get { return _strMensagemErro; }
            set { _strMensagemErro = value; }
        }

        //protected DataTable _dtDados;

        protected static DataTable _dtDados;
        public DataTable dtDados
        {
            get { return _dtDados; }
            set { _dtDados = value; }
        }
    }
}
