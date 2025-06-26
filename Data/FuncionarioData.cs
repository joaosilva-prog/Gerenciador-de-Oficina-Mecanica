using System;
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
            try
            {
                Funcionarios.Add(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar funcionário no repositório.", ex);
            }

        }
        public void RemoverFuncionario(Funcionario funcionario)
        {
            try
            {
                Funcionarios.Remove(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover funcionário do repositório.", ex);
            }
        }
        public bool VerificarFuncionario(string documento)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar funcionário no repositório.", ex);
            }
            
        }

        public Funcionario ObterFuncionarioPorDocumento(string documento)
        {
            try
            {
                Funcionario funcionario = Funcionarios.FirstOrDefault(x => x.Documento == documento);
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter funcionário por documento no repositório.", ex);
            }
        }
    }
}
