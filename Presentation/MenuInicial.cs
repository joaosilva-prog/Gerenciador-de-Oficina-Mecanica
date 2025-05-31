using System;
using System.Globalization;
using GerenciamentoDeOficina.Data;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Services.OficinaExceptions;
using GerenciamentoDeOficina.Controllers;

namespace GerenciamentoDeOficina.Presentation
{
    class MenuInicial
    {
        private bool _sair = false;
        private VeiculoController _veiculoController;
        private ServicoController _servicoController;
        private FuncionarioController _funcionarioController;
        private ClienteController _clienteController;
        private ClienteView _clienteView;
        ConsoleColor ColorAux = Console.ForegroundColor;

        public MenuInicial(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService, IVeiculoService veiculoService)
        {
            _clienteController = new ClienteController(clienteService);
            _funcionarioController = new FuncionarioController(funcionarioService);
            _veiculoController = new VeiculoController(veiculoService);
            _servicoController = new ServicoController(servicoService, clienteService, _veiculoController, _funcionarioController, _clienteController);
            _clienteView = new ClienteView(clienteService);
        }

        public void IniciarMenu()
        {
            while (_sair != true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GERENCIAMENTO DE OFICINA ===");
                Console.WriteLine();
                Console.WriteLine("[1] Cadastrar Novo Cliente");
                Console.WriteLine("[2] Cadastrar Novo Funcionário");
                Console.WriteLine("[3] Cadastrar Novo Serviço");
                Console.WriteLine("[4] Alterar Status de um Serviço");
                Console.WriteLine("[5] Buscar Cliente por Documento");
                Console.WriteLine("[6] Sair");
                Console.Write("Digite a Opção Desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _clienteView.CadastrarCliente();
                        break;

                    case "2":
                        _funcionarioController.CadastrarFuncionario();
                        break;

                    case "3":
                        _servicoController.CriarServico();
                        break;

                    case "4":
                        _servicoController.AlterarStatus();
                        break;

                    case "5":
                        _clienteController.BuscarPorDocumento();
                        break;

                    case "6":
                        Sair();
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ATENÇÃO: Tipo de Serviço não Identificado!");
                        Console.ForegroundColor = ColorAux;
                        Console.WriteLine("Selecione um Tipo de Serviço Válido para prosseguir.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void Sair()
        {
            Console.WriteLine();
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Encerrando o sistema...");
            Console.ForegroundColor = aux2;
            Console.WriteLine("Obrigado por utilizar o Gerenciador de Oficina!");
            _sair = true;
        }
    }
}
