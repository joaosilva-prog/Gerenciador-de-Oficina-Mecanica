using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Services
{
    class ClienteService : IClienteService
    {
        private IClienteData _clienteData;
        public bool ClienteEncontrado { get; private set; } 

        public ClienteService(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }
        public bool CadastrarCliente(Cliente cliente)
        {
            if (_clienteData.VerificarCliente(cliente.Documento) == true)
            {
                return false;
            }
            _clienteData.CadastrarCliente(cliente);
            return true;
        }
        public bool RemoverCliente(Cliente cliente)
        {
            if (_clienteData.VerificarCliente(cliente.Documento) == false)
            {
                return false;
            }
            _clienteData.RemoverCliente(cliente);
            return true;
        }
        public Cliente BuscarPorDocumento(string documento)
        {
            if (_clienteData.VerificarCliente(documento) == false)
            {
                ClienteEncontrado = false;
                return null;
            }
            Cliente cliente = _clienteData.BuscarPorDocumento(documento);
            ClienteEncontrado = true;
            return cliente;
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
