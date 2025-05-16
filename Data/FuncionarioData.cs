using System;
using GerenciamentoDeOficina.Services.OficinaExceptions;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Data
{
    class FuncionarioData : IFuncionarioData
    {
        public List<Funcionario> Funcionarios { get; private set; } = new List<Funcionario>();

        public FuncionarioData()
        {
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
            Console.WriteLine("Funcionário Criado com Sucesso!");
        }
        public void RemoverFuncionario(Funcionario funcionario)
        {
            Funcionarios.Remove(funcionario);
            Console.WriteLine("Funcionário Removido com Sucesso!");
        }
    }
}
