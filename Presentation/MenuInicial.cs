using System;
using GerenciamentoDeOficina.Data;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
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
        private IVeiculoService _veiculoService;
        ConsoleColor aux = Console.ForegroundColor;

        public MenuInicial(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService, IVeiculoService veiculoService)
        {
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
            _servicoService = servicoService;
            _veiculoService = veiculoService;
            _oficina = new Oficina(_clienteService, _funcionarioService, _servicoService, _veiculoService);
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
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("=== CADASTRO DE NOVO FUNCIONÁRIO ===");
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
                        Console.Write("Digite a Opção Desejada: ");
                        string resp = Console.ReadLine();

                        switch (resp)
                        {
                            case "1":
                                Cargo cargo = Cargo.Atendente;
                                Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
                                _oficina.CadastrarFuncionario(funcionario);
                                Console.WriteLine();
                                break;
                            case "2":
                                Cargo cargo2 = Cargo.Gerente;
                                funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo2);
                                _oficina.CadastrarFuncionario(funcionario);
                                Console.WriteLine();
                                break;
                            case "3":
                                Cargo cargo3 = Cargo.Mecânico;
                                funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo3);
                                _oficina.CadastrarFuncionario(funcionario);
                                Console.WriteLine();
                                break;
                            case "4":
                                Cargo cargo4 = Cargo.Supervisor;
                                funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo4);
                                _oficina.CadastrarFuncionario(funcionario);
                                Console.WriteLine();
                                break;
                        }
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("> Funcionário cadastrado com sucesso!");
                        Console.ForegroundColor = aux;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("=== CRIAÇÃO DE NOVO SERVIÇO ===");
                        Console.ForegroundColor = aux;
                        Console.WriteLine();
                        Console.Write("CPF do Cliente:");
                        string documento = Console.ReadLine();
                        if (_oficina.VerificarCliente(documento) == true)
                        {
                            Console.Write("Tipo do Veículo:");
                            Console.WriteLine("[1] Carro");
                            Console.WriteLine("[2] Moto");
                            Console.WriteLine("[3] Caminhão");
                            Console.Write("Digite a Opção Desejada: ");
                            string tipoVeiculo = Console.ReadLine();

                            switch (tipoVeiculo)
                            {
                                case "1":
                                    Tipo tipo = Tipo.Carro;
                                    Console.Write($"Placa do {0}: ", tipo);
                                    string placa = Console.ReadLine();
                                    Console.Write("Modelo: ");
                                    string modelo = Console.ReadLine();
                                    Console.Write("Ano: ");
                                    int ano = int.Parse(Console.ReadLine());
                                    Veiculo carro = new Veiculo(tipo, modelo, placa, ano);
                                    _oficina.CadastrarVeiculo(carro);
                                    break;

                                case "2":
                                    tipo = Tipo.Moto;
                                    Console.Write($"Placa da {0}: ", tipo);
                                    placa = Console.ReadLine();
                                    Console.Write("Modelo: ");
                                    modelo = Console.ReadLine();
                                    Console.Write("Ano: ");
                                    ano = int.Parse(Console.ReadLine());
                                    Veiculo moto = new Veiculo(tipo, modelo, placa, ano);
                                    _oficina.CadastrarVeiculo(moto);
                                    break;

                                case "3":
                                    tipo = Tipo.Caminhão;
                                    Console.Write($"Placa do {0}: ", tipo);
                                    placa = Console.ReadLine();
                                    Console.Write("Modelo: ");
                                    modelo = Console.ReadLine();
                                    Console.Write("Ano: ");
                                    ano = int.Parse(Console.ReadLine());
                                    Veiculo caminhao = new Veiculo(tipo, modelo, placa, ano);
                                    _oficina.CadastrarVeiculo(caminhao);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("ATENÇÃO: Cliente não Identificado ou não Cadastrado!");
                            Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
                        }

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
