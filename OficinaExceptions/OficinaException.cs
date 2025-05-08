using System;

namespace GerenciamentoDeOficina.OficinaExceptions
{
    class OficinaException : ApplicationException
    {
        public OficinaException(string message) : base(message) 
        { }
    }
}
