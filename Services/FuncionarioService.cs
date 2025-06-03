using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;
using GerenciamentoDeOficina.Data;

namespace GerenciamentoDeOficina.Services
{
    class FuncionarioService : IFuncionarioService
    {
        ConsoleColor ColorAux = Console.ForegroundColor;
        private IFuncionarioData _funcionarioData;

        public FuncionarioService(IFuncionarioData funcionarioData)
        {
            _funcionarioData = funcionarioData;
        }
        public bool CadastrarFuncionario(Funcionario funcionario)
        {
            if (_funcionarioData.VerificarFuncionario(funcionario.Documento) == true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Cliente já existente.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return false;
            }
            _funcionarioData.CadastrarFuncionario(funcionario);
            return true;
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            _funcionarioData.RemoverFuncionario(funcionario);
        }

        public bool VerificarFuncionario(string documento)
        {
            return _funcionarioData.VerificarFuncionario(documento);
        }

        public Funcionario ObterFuncionarioPorDocumento(string documento)
        {
            return _funcionarioData.ObterFuncionarioPorDocumento(documento);
        }
    }
}
