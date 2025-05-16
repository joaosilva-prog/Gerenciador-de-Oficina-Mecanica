using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class MenuInicial
    {
        private bool _sair = false;
        private Oficina _oficina;
        private IClienteService _clienteService;
        private IFuncionarioService _funcionarioService;
        private IServicoService _servicoService;
        ConsoleColor aux = Console.ForegroundColor;

        public MenuInicial(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService)
        {
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
            _servicoService = servicoService;
            _oficina = new Oficina(_clienteService, _funcionarioService, _servicoService);
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
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("=== CADASTRO DE NOVO CLIENTE ===");
                        Console.ForegroundColor = aux;
                        Console.WriteLine();
                        Console.Write("Nome Completo: ");
                        string nomeCliente = Console.ReadLine();
                        Console.Write("CPF: ");
                        string documentoCliente = Console.ReadLine();
                        Console.Write("E-mail: ");
                        string emailCliente = Console.ReadLine();
                        Cliente cliente = new Cliente(nomeCliente, documentoCliente, emailCliente);
                        _oficina.CadastrarCliente(cliente);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("> Cliente cadastrado com sucesso!");
                        Console.ForegroundColor = aux;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("=== CADASTRO DE NOVO CLIENTE ===");
                        Console.ForegroundColor = aux;
                        Console.WriteLine();
                        Console.Write("Nome Completo: ");
                        string nomeFuncionario = Console.ReadLine();
                        Console.Write("CPF: ");
                        string documentoFuncionario = Console.ReadLine();
                        Console.Write("E-mail: ");
                        string emailFuncionario = Console.ReadLine();
                        Console.WriteLine("Cargo:");
                        Console.WriteLine("[1] Atendente");
                        Console.WriteLine("[2] Gerente");
                        Console.WriteLine("[3] Mecânico");
                        Console.WriteLine("[4] Supervisor");
                        Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario);
                        _oficina.CadastrarFuncionario(funcionario);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("> Cliente cadastrado com sucesso!");
                        Console.ForegroundColor = aux;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine();
                        ConsoleColor aux2 = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Encerrando o sistema...");
                        Console.ForegroundColor = aux2;
                        Console.WriteLine("Obrigado por utilizar o Gerenciador de Oficina!");
                        _sair = true;
                        break;

                }






            }
        }
    }
}
