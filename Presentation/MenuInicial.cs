using System;
using System.Globalization;
using GerenciamentoDeOficina.Data;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Services.OficinaExceptions;

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
        ConsoleColor ColorAux = Console.ForegroundColor;

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
                        CadastrarCliente();
                        break;

                    case "2":
                        CadstrarFuncionario();
                        break;

                    case "3":
                        CadastrarServico();
                        break;

                    case "4":
                        AlterarStatus();
                        break;

                    case "5":
                        BuscarClientePorDocumento();
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
            _oficina.CadastrarCliente(cliente);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("> Cliente cadastrado com sucesso!");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void CadstrarFuncionario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== CADASTRO DE NOVO FUNCIONÁRIO ===");
            Console.ForegroundColor = ColorAux;
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

            if (resp == "1")
            {
                Cargo cargo = Cargo.Atendente;
                Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
                _oficina.CadastrarFuncionario(funcionario);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Funcionário cadastrado com sucesso!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else if (resp == "2")
            {
                Cargo cargo2 = Cargo.Gerente;
                Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo2);
                _oficina.CadastrarFuncionario(funcionario);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Funcionário cadastrado com sucesso!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else if (resp == "3")
            {
                Cargo cargo3 = Cargo.Mecânico;
                Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo3);
                _oficina.CadastrarFuncionario(funcionario);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Funcionário cadastrado com sucesso!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else if (resp == "4")
            {
                Cargo cargo4 = Cargo.Supervisor;
                Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo4);
                _oficina.CadastrarFuncionario(funcionario);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Funcionário cadastrado com sucesso!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escolha de Cargo inválida.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
        }

        public void CadastrarServico()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== CRIAÇÃO DE NOVO SERVIÇO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("CPF do Cliente: ");
            string documento = Console.ReadLine();
            Veiculo veiculo;
            Tipo tipo;

            if (_oficina.VerificarCliente(documento) == true)
            {
                Console.WriteLine("Tipo do Veículo:");
                Console.WriteLine("[1] Carro");
                Console.WriteLine("[2] Moto");
                Console.WriteLine("[3] Caminhão");
                Console.Write("Digite a Opção Desejada: ");
                string tipoVeiculo = Console.ReadLine();

                switch (tipoVeiculo)
                {
                    case "1":
                        tipo = Tipo.Carro;
                        break;

                    case "2":
                        tipo = Tipo.Moto;
                        break;

                    case "3":
                        tipo = Tipo.Caminhão;
                        break;

                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ATENÇÃO: Tipo de Veículo não Identificado ou não Cadastrado!");
                        Console.ForegroundColor = ColorAux;
                        Console.WriteLine("Cadastre Veículo de Tipo Válido para prosseguir.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        return;
                }
                Console.Write("Placa do Veículo: ");
                string placa = Console.ReadLine();
                Console.Write("Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Ano: ");
                int ano = int.Parse(Console.ReadLine());
                veiculo = new Veiculo(tipo, modelo, placa, ano);
                _oficina.CadastrarVeiculo(veiculo);
                Console.Write("Descrição do Serviço: ");
                string descricao = Console.ReadLine();
                Console.Write("Valor (R$): ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("CPF do Funcionário responsável: ");
                string documentoFuncionario = Console.ReadLine();
                if (_oficina.VerificarFuncionario(documentoFuncionario) == true)
                {
                    Status status = Status.Pendente;
                    Cliente cliente = _clienteService.ObterClientePorDocumento(documento);
                    Funcionario funcionario = _funcionarioService.ObterFuncionarioPorDocumento(documentoFuncionario);
                    _oficina.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
                    Console.WriteLine("Status inicial: " + status);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("> Serviço cadastrado com sucesso!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Funcionário não Identificado ou não Cadastrado!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Cadastre um Novo Funcionário para prosseguir ou verifique o documento informado.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
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

        public void AlterarStatus()
        {
            Status novoStatus;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== ALTERAR STATUS DE UM SERVIÇO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("CPF do Cliente: ");
            string documento = Console.ReadLine();

            Console.WriteLine("Serviços encontrados:");
            _oficina.ObterServicoPorDocumento(documento);
            Console.ReadLine();
            Console.WriteLine("Novo status: ");
            Console.WriteLine("[1] Em Andamento");
            Console.WriteLine("[2] Finalizado");
            Console.Write("Escolha a nova opção: ");
            string resp = Console.ReadLine();

            switch (resp)
            {
                case "1":
                    novoStatus = Status.EmExcecucao;
                    Servico servico = _oficina.ObterServicoPorDocumento(documento);
                    _oficina.AlterarStatus(servico, novoStatus);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("> Serviço cadastrado com sucesso!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;

                case "2":
                    novoStatus = Status.Finalizado;
                    servico = _oficina.ObterServicoPorDocumento(documento);
                    _oficina.AlterarStatus(servico, novoStatus);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("> Serviço cadastrado com sucesso!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Status selecionado não Identificado ou não Cadastrado!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Selecione um Status Válido para prosseguir.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    break;
            }

        }

        public void BuscarClientePorDocumento()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== BUSCAR CLIENTE POR DOCUMENTO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("CPF do Cliente: ");
            string documento = Console.ReadLine();

            if (_oficina.VerificarCliente(documento) == true)
            {
                _oficina.BuscarPorDocumento(documento);
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
