using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Services
{
    class ClienteService : IClienteService
    {
        private IClienteData _clienteData;
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

    }
}
