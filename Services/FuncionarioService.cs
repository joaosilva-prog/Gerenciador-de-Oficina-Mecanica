using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;

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
                return false;
            }
            _funcionarioData.CadastrarFuncionario(funcionario);
            return true;
        }

        public bool RemoverFuncionario(Funcionario funcionario)
        {
            if (_funcionarioData.VerificarFuncionario(funcionario.Documento) == false)
            {
                return false;
            }
            _funcionarioData.RemoverFuncionario(funcionario);
            return true;
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
