using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class ClienteController
    {
        private IClienteService _clienteService;
        public bool ClienteCadastrado { get; private set; }
        ConsoleColor ColorAux = Console.ForegroundColor;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Todos os campos são obrigatórios!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            Cliente cliente = new Cliente(nomeCliente, documentoCliente, emailCliente);
            ClienteCadastrado = _clienteService.CadastrarCliente(cliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            _clienteService.RemoverCliente(cliente);
        }

        public void BuscarPorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: O documento é obrigatório!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            _clienteService.BuscarPorDocumento(documento);
        }

        public bool VerificarCliente(string documento)
        {
            return _clienteService.VerificarCliente(documento);
        }

        public Cliente ObterClientePorDocumento(string documento)
        {
            return _clienteService.ObterClientePorDocumento(documento);
        }
    }
}
