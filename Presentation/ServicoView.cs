using System;
using System.Globalization;
using GerenciamentoDeOficina.Controllers;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class ServicoView
    {
        private ServicoController _servicoController;
        private ClienteController _clienteController;
        private FuncionarioController _funcionarioController;
        private VeiculoController _veiculoController;
        private VeiculoView _veiculoView;
        ConsoleColor ColorAux = Console.ForegroundColor;

        public ServicoView(ServicoController servicoController, ClienteController clienteController, FuncionarioController funcionarioController, VeiculoController veiculoController, VeiculoView veiculoView)
        {
            _servicoController = servicoController;
            _clienteController = clienteController;
            _funcionarioController = funcionarioController;
            _veiculoController = veiculoController;
            _veiculoView = veiculoView;
        }

        public void CriarServico()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=== CRIAÇÃO DE NOVO SERVIÇO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("CPF do Cliente: ");
            string documento = Console.ReadLine() ?? "";
            Console.Write("Descrição do Serviço: ");
            string descricao = Console.ReadLine() ?? "";
            Console.Write("Valor (R$): ");
            bool valorOk = double.TryParse(Console.ReadLine(), out double valor);
            if (valorOk == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.Write("CPF do Funcionário responsável: ");
                string documentoFuncionario = Console.ReadLine() ?? "";
                Veiculo veiculo = _veiculoController.ObterVeiculoPorDocumento(documento);
                _servicoController.CriarServico(documento, descricao, valor, documentoFuncionario);
                if (_servicoController.CamposOk == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Todos os campos são obrigatórios!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    if (_servicoController.ClienteEncontrado == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ATENÇÃO: Cliente não Identificado ou não Cadastrado!");
                        Console.ForegroundColor = ColorAux;
                        Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                    }
                    else
                    {
                        if (_servicoController.FuncionarioEncontrado == false)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ATENÇÃO: Funcionário não Identificado ou não Cadastrado!");
                            Console.ForegroundColor = ColorAux;
                            Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            if (_servicoController.VeiculoEncontrado == false)
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ATENÇÃO: Cliente não possui veículo Cadastrado!");
                                Console.ForegroundColor = ColorAux;
                                _veiculoView.CadastrarVeiculo();
                                Console.ReadLine();
                            }
                            else
                            {
                                if (_servicoController.ServicoCadastrado == false)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("ATENÇÃO: Cliente já possui um Serviço para este mesmo veículo.");
                                    Console.ForegroundColor = ColorAux;
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("> Serviço cadastrado com sucesso!");
                                    Console.ForegroundColor = ColorAux;
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                }
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
            string documento = Console.ReadLine() ?? "";
            Console.WriteLine("Serviços encontrados:");
            Servico servico = _servicoController.ObterServicoPorDocumento(documento);
            if (servico is null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Não foram Cadastrados Serviços para este Cliente.");
                Console.ResetColor();
                Console.WriteLine("Cadastre um Novo Serviço para prosseguir ou verifique o documento informado.");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine(servico);
                Console.ReadLine();
                Console.WriteLine("Novo status: ");
                Console.WriteLine("[1] Em Andamento");
                Console.WriteLine("[2] Finalizado");
                Console.Write("Escolha a nova opção: ");
                bool statusOK = int.TryParse(Console.ReadLine(), out int statusInt);
                if (statusOK == true)
                {
                    switch (statusInt)
                    {
                        case 1:
                            novoStatus = Status.EmExcecucao;
                            _servicoController.AlterarStatus(servico, novoStatus);
                            break;
                        case 2:
                            novoStatus = Status.Finalizado;
                            _servicoController.AlterarStatus(servico, novoStatus);
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
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada de dados inválida.");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Selecione uma das opções enumeradas.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    return;
                }
                if (_servicoController.StatusAlterado == true)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("> Status alterado com sucesso!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
                else
                {
                }
            }
        }
    }
}


