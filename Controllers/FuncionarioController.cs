using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class FuncionarioController
    {
        private IFuncionarioService _funcionarioService;
        public bool FuncionarioCadastrado { get; private set; }
        ConsoleColor ColorAux = Console.ForegroundColor;
        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public Funcionario ObterFuncionarioPorDocumento(string documento)
        {
            return _funcionarioService.ObterFuncionarioPorDocumento(documento);
        }

        public void CadastrarFuncionario(string nomeFuncionario, string documentoFuncionario, string emailFuncionario, Cargo cargo)
        {
            if (string.IsNullOrWhiteSpace(nomeFuncionario) ||
               string.IsNullOrWhiteSpace(documentoFuncionario) ||
               string.IsNullOrWhiteSpace(emailFuncionario))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Todos os campos são obrigatórios!");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
            FuncionarioCadastrado = _funcionarioService.CadastrarFuncionario(funcionario);
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
