using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class FuncionarioController
    {
        private IFuncionarioService _funcionarioService;
        ConsoleColor ColorAux = Console.ForegroundColor;
        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public Funcionario ObterFuncionarioPorDocumento(string documento)
        {
            return _funcionarioService.ObterFuncionarioPorDocumento(documento);
        }

        public void CadastrarFuncionario()
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
            Cargo cargo;

            if (resp == "1")
            {
                cargo = Cargo.Atendente;
            }
            else if (resp == "2")
            {
                cargo = Cargo.Gerente;
            }
            else if (resp == "3")
            {
                cargo = Cargo.Mecânico;
            }
            else if (resp == "4")
            {
                cargo = Cargo.Supervisor;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Escolha de Cargo inválida.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
            _funcionarioService.CadastrarFuncionario(funcionario);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("> Funcionário cadastrado com sucesso!");
            Console.ForegroundColor = ColorAux;
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadLine();
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            _funcionarioService.RemoverFuncionario(funcionario);
        }

        public bool VerificarFuncionario(string documento)
        {
            return _funcionarioService.VerificarFuncionario(documento);
        }
    }
}
