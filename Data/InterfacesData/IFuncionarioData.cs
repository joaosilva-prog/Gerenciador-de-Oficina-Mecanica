using System;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data.InterfacesData
{
    interface IFuncionarioData
    {
        public void CadastrarFuncionario(Funcionario funcionario);
        public void RemoverFuncionario(Funcionario funcionario);
    }
}
