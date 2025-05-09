using System;
using GerenciamentoDeOficina.Data;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Services
{
    class FuncionarioService : IFuncionarioService
    {
        private FuncionarioData FuncionarioData = new FuncionarioData();
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            FuncionarioData.CadastrarFuncionario(funcionario);
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            FuncionarioData.RemoverFuncionario(funcionario);
        }
    }
}
