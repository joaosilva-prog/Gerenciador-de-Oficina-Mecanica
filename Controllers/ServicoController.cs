using System;
using System.Globalization;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class ServicoController
    {
        private IServicoService _servicoService;
        private IClienteService _clienteService;
        private VeiculoController _veiculoController;
        private FuncionarioController _funcionarioController;
        private ClienteController _clienteController;
        ConsoleColor ColorAux = Console.ForegroundColor;
        public ServicoController(IServicoService servicoService, IClienteService clienteService, VeiculoController veiculoController, FuncionarioController funcionarioController, ClienteController clienteController)
        {
            _servicoService = servicoService;
            _clienteService = clienteService;
            _veiculoController = veiculoController;
            _funcionarioController = funcionarioController;
            _clienteController = clienteController;
        }

        public void CriarServico()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== CRIAÇÃO DE NOVO SERVIÇO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("CPF do Cliente: ");
            string documento = Console.ReadLine();

            if (_clienteService.VerificarCliente(documento) == true)
            {
                Veiculo veiculo;
                veiculo = _veiculoController.CadastrarVeiculo();
                if (veiculo == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Erro ao cadastrar veículo. Operação cancelada.");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Descrição do Serviço: ");
                string descricao = Console.ReadLine();
                Console.Write("Valor (R$): ");
                double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("CPF do Funcionário responsável: ");
                string documentoFuncionario = Console.ReadLine();
                if (_funcionarioController.VerificarFuncionario(documentoFuncionario) == true)
                {
                    Status status = Status.Pendente;
                    Cliente cliente = _clienteController.ObterClientePorDocumento(documento);
                    Funcionario funcionario = _funcionarioController.ObterFuncionarioPorDocumento(documentoFuncionario);
                    _servicoService.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
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
                    return;
                }

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
                return;
            }
        }

        public Servico ObterServicoPorDocumento(string documento)
        {
            return _servicoService.ObterServicoPorDocumento(documento);
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
            Servico servico = ObterServicoPorDocumento(documento);
            if (servico == null) return;
            Console.WriteLine(servico);
            Console.ReadLine();
            Console.WriteLine("Novo status: ");
            Console.WriteLine("[1] Em Andamento");
            Console.WriteLine("[2] Finalizado");
            Console.Write("Escolha a nova opção: ");
            string resp = Console.ReadLine();
            if (resp == "1")
            {
                novoStatus = Status.EmExcecucao;
                _servicoService.AlterarStatus(servico, novoStatus);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Serviço cadastrado com sucesso!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            else if (resp == "2")
            {
                novoStatus = Status.Finalizado;
                _servicoService.AlterarStatus(servico, novoStatus);
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
                Console.WriteLine("ATENÇÃO: Status selecionado não Identificado ou não Cadastrado!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Selecione um Status Válido para prosseguir.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();

            }
        }
    }

}
