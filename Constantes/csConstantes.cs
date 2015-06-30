using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KuraFrameWork
{
    public static class csConstantes
    {
        //Status cadastro
        public const char sInserindo = 'I';
        public const char sAlterando = 'A';
        public const char sExcluindo = 'E';

        //Condições
        public const int nIgual = 1;
        public const int nDiferente = 2;
        public const int nMaior = 3;
        public const int nMenor = 4;
        public const int nMaiorIgual = 5;
        public const int nMenorIgual = 6;
        public const int nBetween = 7;
        public const int nContem = 8;
        public const int nDentre = 9;
        public const int nExceto = 10;

        //Opções Controle
        public const string sTpCarregado = "S";
        public const string sTpInserido = "I";
        public const string sTpAlterado = "A";
        public const string sTpExcluido = "E";

        //Ordenação
        public const string sCrescente = " ASC";
        public const string sDecrescente = " DESC";
    }
}
