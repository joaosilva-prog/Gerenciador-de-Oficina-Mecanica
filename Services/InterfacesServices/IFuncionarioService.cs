using System;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IFuncionarioService
    {
        public void CadastrarFuncionario(Funcionario funcionario);

        public void RemoverFuncionario(Funcionario funcionario);
    }
}
