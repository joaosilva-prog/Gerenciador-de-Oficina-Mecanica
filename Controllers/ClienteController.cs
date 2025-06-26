using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class ClienteController
    {
        private IClienteService _clienteService;
        public bool ClienteCadastrado { get; private set; }
        public bool ClienteEncontrado { get; private set; }
        public bool ClienteVerificado { get; private set; }
        public bool CamposOK { get; private set; }
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void CadastrarCliente(string nomeCliente, string documentoCliente, string emailCliente)
        {
            if (string.IsNullOrWhiteSpace(nomeCliente) ||
               string.IsNullOrWhiteSpace(documentoCliente) ||
               string.IsNullOrWhiteSpace(emailCliente))
            {
                CamposOK = false;
                return;
            }
            CamposOK = true;
            Cliente cliente = new Cliente(nomeCliente, documentoCliente, emailCliente);
            ClienteCadastrado = _clienteService.CadastrarCliente(cliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            _clienteService.RemoverCliente(cliente);
        }

        public Cliente BuscarPorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                CamposOK =  false;
                return null;
            }
            CamposOK = true;
            Cliente cliente = _clienteService.BuscarPorDocumento(documento);
            ClienteEncontrado = _clienteService.ClienteEncontrado;
            return cliente;
        }

        public bool VerificarCliente(string documento)
        {
            ClienteVerificado = _clienteService.VerificarCliente(documento);
            return ClienteVerificado;
        }

        public Cliente ObterClientePorDocumento(string documento)
        {
            return _clienteService.ObterClientePorDocumento(documento);
        }
    }
}
