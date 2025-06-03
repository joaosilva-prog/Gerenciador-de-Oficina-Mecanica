using System;
using GerenciamentoDeOficina.Controllers;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class FuncionarioView
    {
        private IFuncionarioService _funcionarioService;
        private FuncionarioController _funcionarioController;
        ConsoleColor ColorAux = Console.ForegroundColor;

        public FuncionarioView(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
            _funcionarioController = new FuncionarioController(_funcionarioService);

        }

        public void CadastrarFuncionario()
        {
            Cargo cargo;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== CADASTRO DE NOVO FUNCIONÁRIO ===");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine();
            Console.Write("Nome Completo: ");
            string nomeFuncionario = Console.ReadLine() ?? "";
            Console.Write("CPF: ");
            string documentoFuncionario = Console.ReadLine() ?? "";
            Console.Write("E-mail: ");
            string emailFuncionario = Console.ReadLine() ?? "";
            Console.WriteLine("Cargo:");
            Console.WriteLine("[1] Atendente");
            Console.WriteLine("[2] Gerente");
            Console.WriteLine("[3] Mecânico");
            Console.WriteLine("[4] Supervisor");
            Console.Write("Digite a Opção Desejada: ");
            bool cargoOK = int.TryParse(Console.ReadLine(), out int cargoInt);
            if (cargoOK == true)
            {
                switch (cargoInt)
                {
                    case 1:
                        cargo = Cargo.Atendente;
                        _funcionarioController.CadastrarFuncionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
                        break;
                    case 2:
                        cargo = Cargo.Gerente;
                        _funcionarioController.CadastrarFuncionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
                        break;
                    case 3:
                        cargo = Cargo.Mecânico;
                        _funcionarioController.CadastrarFuncionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
                        break;
                    case 4:
                        cargo = Cargo.Supervisor;
                        _funcionarioController.CadastrarFuncionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
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
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada de dados inválida.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Selecione uma das opções enumeradas.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            if (_funcionarioController.FuncionarioCadastrado == true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("> Funcionário cadastrado com sucesso!");
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
