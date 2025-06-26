using System;
using GerenciamentoDeOficina.Controllers;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class ClienteView
    {
        private ClienteController _clienteController;
        private VeiculoView _veiculoView;
        private ServicoController _servicoController;
        ConsoleColor ColorAux = Console.ForegroundColor;

        public ClienteView(ClienteController clienteController, VeiculoView veiculoView, ServicoController servicoController)
        {
            _clienteController = clienteController;
            _veiculoView = veiculoView;
            _servicoController = servicoController;

        }
        public void CadastrarCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== CADASTRO DE NOVO CLIENTE ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("Nome Completo: ");
            string nomeCliente = Console.ReadLine() ?? "";
            Console.Write("CPF: ");
            string documentoCliente = Console.ReadLine() ?? "";
            Console.Write("E-mail: ");
            string emailCliente = Console.ReadLine() ?? "";
            _clienteController.CadastrarCliente(nomeCliente, documentoCliente, emailCliente);
            if (_clienteController.CamposOK == false)
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
                if (_clienteController.ClienteCadastrado == true)
                {
                    Console.WriteLine("Deseja cadastrar um novo Veículo para este cliente agora?");
                    Console.WriteLine("[1] Sim");
                    Console.WriteLine("[2] Não");
                    Console.Write("Digite a Opção Desejada: ");
                    bool respOk = int.TryParse(Console.ReadLine(), out int resp);
                    if (respOk == false || resp < 1 || resp > 2)
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
                    else
                    {
                        switch (resp)
                        {
                            case 1:
                                Console.Clear();
                                _veiculoView.CadastrarVeiculo();
                                break;
                            case 2:
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("> Cliente cadastrado com sucesso!");
                                Console.ForegroundColor = ColorAux;
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Cliente já existente.");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
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
            string documento = Console.ReadLine() ?? "";
            Cliente cliente = _clienteController.BuscarPorDocumento(documento);
            if (_clienteController.CamposOK == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: O documento é obrigatório!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            else
            {
                bool buscaOk = _clienteController.ClienteEncontrado;
                if (buscaOk == false)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Cliente não encontrado/cadastrado.");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine(cliente);
                    Console.WriteLine();
                    var servicos = _servicoController.ObterServicosDoCliente(cliente.Documento);
                    if (servicos is null || servicos.Count == 0)
                    {
                        Console.WriteLine("Cliente ainda não possui serviços cadastrados.");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        foreach (var servico in servicos)
                        {
                            Console.WriteLine(servico);
                        }
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        return;
                    }
                }
            }
        }
    }
}
