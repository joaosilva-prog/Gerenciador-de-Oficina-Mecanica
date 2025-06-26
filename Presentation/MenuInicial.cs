using System;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Controllers;

namespace GerenciamentoDeOficina.Presentation
{
    class MenuInicial
    {
        private bool _sair = false;
        private VeiculoController _veiculoController;
        private FuncionarioController _funcionarioController;
        private ClienteController _clienteController;
        private ServicoController _servicoController;
        private ClienteView _clienteView;
        private FuncionarioView _funcionarioView;
        private ServicoView _servicoView;
        private VeiculoView _veiculoView;
        ConsoleColor ColorAux = Console.ForegroundColor;

        public MenuInicial(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService, IVeiculoService veiculoService)
        {
            _clienteController = new ClienteController(clienteService);
            _funcionarioController = new FuncionarioController(funcionarioService);
            _veiculoController = new VeiculoController(veiculoService);
            _servicoController = new ServicoController(servicoService, clienteService, veiculoService, funcionarioService);

            _funcionarioView = new FuncionarioView(_funcionarioController);
            _veiculoView = new VeiculoView(_veiculoController);
            _clienteView = new ClienteView(_clienteController, _veiculoView, _servicoController);
            _servicoView = new ServicoView(_servicoController, _clienteController, _funcionarioController, _veiculoController, _veiculoView);
        }

        public void IniciarMenu()
        {
            while (_sair != true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== SISTEMA DE GERENCIAMENTO DE OFICINA ===");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine();
                Console.WriteLine("[1] Cadastrar Novo Cliente");
                Console.WriteLine("[2] Cadastrar Novo Funcionário");
                Console.WriteLine("[3] Cadastrar Novo Serviço");
                Console.WriteLine("[4] Alterar Status de um Serviço");
                Console.WriteLine("[5] Buscar Cliente por Documento");
                Console.WriteLine("[6] Sair");
                Console.Write("Digite a Opção Desejada: ");
                bool opcaoOK = int.TryParse(Console.ReadLine(), out int opcao);
                if (opcaoOK == true)
                {
                    switch (opcao)
                    {
                        case 1:
                            _clienteView.CadastrarCliente();
                            break;
                        case 2:
                            _funcionarioView.CadastrarFuncionario();
                            break;
                        case 3:
                            _servicoView.CriarServico();
                            break;
                        case 4:
                            _servicoView.AlterarStatus();
                            break;
                        case 5:
                            _clienteView.BuscarPorDocumento();
                            break;
                        case 6:
                            Sair();
                            break;
                        default:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Escolha de Cargo inválida.");
                            Console.ForegroundColor = ColorAux;
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrada de dados inválida.");
                        Console.ForegroundColor = ColorAux;
                        Console.WriteLine("Selecione uma das opções enumeradas.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    }
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
