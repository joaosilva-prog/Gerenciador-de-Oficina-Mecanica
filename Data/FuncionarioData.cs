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
        }
        public void RemoverFuncionario(Funcionario funcionario)
        {
            Funcionarios.Remove(funcionario);
        }
        public bool VerificarFuncionario(string documento)
        {
            var x = Funcionarios.Where(x => x.Documento == documento).ToList();
            if (x.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Funcionario ObterFuncionarioPorDocumento(string documento)
        {
            Funcionario funcionario = Funcionarios.FirstOrDefault(x => x.Documento == documento);
            return funcionario;
        }
    }
}
