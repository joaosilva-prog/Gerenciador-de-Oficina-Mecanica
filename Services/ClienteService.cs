using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Services
{
    class ClienteService : IClienteService
    {
        private IClienteData _clienteData;

        public ClienteService(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }
        public void CadastrarCliente(Cliente cliente)
        {
            _clienteData.CadastrarCliente(cliente);
        }
        public void RemoverCliente(Cliente cliente)
        {
            _clienteData.RemoverCliente(cliente);
        }
        public void BuscarPorDocumento(string documento)
        {
            _clienteData.BuscarPorDocumento(documento);
        }
        public bool VerificarCliente(string documento)
        {
           return _clienteData.VerificarCliente(documento);
        }
        public Cliente ObterClientePorDocumento(string documento)
        {
            return _clienteData.ObterClientePorDocumento(documento);
        }
    }
}
