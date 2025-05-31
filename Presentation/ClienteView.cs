using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeOficina.Controllers;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class ClienteView
    {
        private IClienteService _clienteService;
        private ClienteController _clienteController;
        ConsoleColor ColorAux = Console.ForegroundColor;

        public ClienteView(IClienteService clienteService)
        {
            _clienteService = clienteService;
            _clienteController = new ClienteController(_clienteService);

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
            _clienteController.CadastrarCliente(nomeCliente, documentoCliente, emailCliente);
            if (_clienteController.ClienteCadastrado == true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Cliente cadastrado com sucesso!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
            }
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
            _clienteController.BuscarPorDocumento(documento);
        }
    }
}
