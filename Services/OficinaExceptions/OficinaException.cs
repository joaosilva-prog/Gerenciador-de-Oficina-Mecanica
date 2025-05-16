using System;

namespace GerenciamentoDeOficina.Services.OficinaExceptions
{
    class OficinaException : ApplicationException
    {
        public OficinaException(string message) : base(message)
        { }
    }
}
