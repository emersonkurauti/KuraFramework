using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KuraFrameWork
{
    static class csMensagem
    {
        /// <summary>
        /// Informativo
        /// </summary>
        public const string msgNomeSistema = "SansERP";

        /// <summary>
        /// Erros
        /// </summary>
        public const string msgErroValorInvalido = "Valor inválido para consulta. Por favor, verifique.";
        public const string msgErroConsultar = "Erro ao consultar registro.";

        /// <summary>
        /// Confirmação
        /// </summary>
        public const string msgRegistroEmEdicao = "O registro está em edição, deseja cancelar?";
        public const string msgConfirmaRemocao = "Deseja realmente excluir o registro?";
    }
}
