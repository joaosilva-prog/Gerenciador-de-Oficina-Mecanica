using System;
using GerenciamentoDeOficina.Entities;


namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IClienteService
    {
        public void CadastrarCliente(Cliente cliente);
        public void RemoverCliente(Cliente cliente);
        public void BuscarPorDocumento(string documento);
        public bool VerificarCliente(string documento);
    }
}
