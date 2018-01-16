using System;
using System.Runtime.Serialization;

namespace Bussines
{
    [Serializable]
    public class ViolacaoRegraDeNegocio : Exception
    {
        public ViolacaoRegraDeNegocio(string mensagem)
        {            
        }
    }
}