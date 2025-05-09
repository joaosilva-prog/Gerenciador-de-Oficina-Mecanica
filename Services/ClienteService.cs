using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data;


namespace GerenciamentoDeOficina.Services
{
    class ClienteService : IClienteService
    {
        private ClienteData ClienteData = new ClienteData();
        public void CadastrarCliente(Cliente cliente)
        {
            ClienteData.CadastrarCliente(cliente);
        }
        public void RemoverCliente(Cliente cliente)
        {
            ClienteData.RemoverCliente(cliente);
        }
        public void BuscarPorDocumento(string documento)
        {
            ClienteData.BuscarPorDocumento(documento);
        }

    }
}
