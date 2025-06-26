using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class FuncionarioController
    {
        private IFuncionarioService _funcionarioService;
        public bool FuncionarioCadastrado { get; private set; }
        public bool FuncionarioEncontrado { get; private set; }
        public bool FuncionarioVerificado { get; private set; }
        public bool CamposOK { get; private set; }
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
                CamposOK = false;
                return;
            }
            CamposOK = true;
            Funcionario funcionario = new Funcionario(nomeFuncionario, documentoFuncionario, emailFuncionario, cargo);
            FuncionarioCadastrado = _funcionarioService.CadastrarFuncionario(funcionario);
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            _funcionarioService.RemoverFuncionario(funcionario);
        }

        public bool VerificarFuncionario(string documento)
        {
            FuncionarioVerificado = _funcionarioService.VerificarFuncionario(documento);
            return FuncionarioVerificado;
        }
    }
}
