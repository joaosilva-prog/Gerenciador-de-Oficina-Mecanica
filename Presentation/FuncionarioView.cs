using System;
using GerenciamentoDeOficina.Controllers;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class FuncionarioView
    {
        private FuncionarioController _funcionarioController;
        public bool FuncionarioExistente { get; private set; }
        ConsoleColor ColorAux = Console.ForegroundColor;

        public FuncionarioView(FuncionarioController funcionarioController)
        {
            _funcionarioController = funcionarioController;
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
            if (cargoOK == false || cargoInt < 1 || cargoInt > 4)
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
                cargo = cargoInt switch
                {
                    1 => Cargo.Atendente,
                    2 => Cargo.Gerente,
                    3 => Cargo.Mecânico,
                    4 => Cargo.Supervisor,
                };
                _funcionarioController.CadastrarFuncionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
            }
            if (_funcionarioController.CamposOK == false)
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
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Funcionário já existente.");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
