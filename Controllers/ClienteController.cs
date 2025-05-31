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

            //Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.WriteLine("=== CADASTRO DE NOVO CLIENTE ===");
            //Console.ForegroundColor = ColorAux;
            //Console.WriteLine();
            //Console.Write("Nome Completo: ");
            //string nomeCliente = Console.ReadLine();
            //Console.Write("CPF: ");
            //string documentoCliente = Console.ReadLine();
            //Console.Write("E-mail: ");
            //string emailCliente = Console.ReadLine();
            //Cliente cliente = new Cliente(nomeCliente, documentoCliente, emailCliente);
            //_clienteService.CadastrarCliente(cliente);
            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("> Cliente cadastrado com sucesso!");
            //Console.ForegroundColor = ColorAux;
            //Console.WriteLine("Pressione qualquer tecla para continuar...");
            //Console.ReadLine();
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

            //if (_clienteService.VerificarCliente(documento) == true)
            //{
            //    _clienteService.BuscarPorDocumento(documento);
            //    Console.WriteLine();
            //    Console.WriteLine("Veículos do(a) Cliente:");
            //    //_veiculoService.(documento);
            //    Console.WriteLine();
            //    Console.WriteLine("Pressione qualquer tecla para continuar...");
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine();
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("ATENÇÃO: Cliente não Identificado ou não Cadastrado!");
            //    Console.ForegroundColor = ColorAux;
            //    Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
            //    Console.WriteLine("Pressione qualquer tecla para continuar...");
            //    Console.ReadLine();
            //}
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
