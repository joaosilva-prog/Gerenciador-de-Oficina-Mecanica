using System;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data
{
    class FuncionarioData
    {
        public List<Funcionario> Funcionarios { get; private set; }

        public FuncionarioData()
        {
            Funcionarios = new List<Funcionario>();
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
