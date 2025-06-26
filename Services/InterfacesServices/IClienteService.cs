using System;
using GerenciamentoDeOficina.Entities;


namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IClienteService
    {
        public bool ClienteEncontrado { get; }
        public bool CadastrarCliente(Cliente cliente);
        public bool RemoverCliente(Cliente cliente);
        public Cliente BuscarPorDocumento(string documento);
        public bool VerificarCliente(string documento);
        public Cliente ObterClientePorDocumento(string documento);
    }
}
