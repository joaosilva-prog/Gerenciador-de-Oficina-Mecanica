using System;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data.InterfacesData
{
    interface IClienteData
    {
        public void CadastrarCliente(Cliente cliente);
        public void RemoverCliente(Cliente cliente);
        public Cliente BuscarPorDocumento(string documento);
        public bool VerificarCliente(string documento);
        public Cliente ObterClientePorDocumento(string documento);
    }
}
