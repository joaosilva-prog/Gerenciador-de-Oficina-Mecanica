using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class ClienteController
    {
        private IClienteService _clienteService;
        ConsoleColor ColorAux = Console.ForegroundColor;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void CadastrarCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== CADASTRO DE NOVO CLIENTE ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("Nome Completo: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("CPF: ");
            string documentoCliente = Console.ReadLine();
            Console.Write("E-mail: ");
            string emailCliente = Console.ReadLine();
            Cliente cliente = new Cliente(nomeCliente, documentoCliente, emailCliente);
            _clienteService.CadastrarCliente(cliente);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("> Cliente cadastrado com sucesso!");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void RemoverCliente(Cliente cliente)
        {
            _clienteService.RemoverCliente(cliente);
        }

        public void BuscarPorDocumento()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== BUSCAR CLIENTE POR DOCUMENTO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("CPF do Cliente: ");
            string documento = Console.ReadLine();

            if (_clienteService.VerificarCliente(documento) == true)
            {
                _clienteService.BuscarPorDocumento(documento);
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Cliente não Identificado ou não Cadastrado!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
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
