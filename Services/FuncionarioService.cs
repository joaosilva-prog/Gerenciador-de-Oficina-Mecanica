﻿using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;
using GerenciamentoDeOficina.Data;

namespace GerenciamentoDeOficina.Services
{
    class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioData _funcionarioData;

        public FuncionarioService(IFuncionarioData funcionarioData)
        {
            _funcionarioData = funcionarioData;
        }
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            _funcionarioData.CadastrarFuncionario(funcionario);
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
