using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.OficinaExceptions;

namespace GerenciamentoDeOficina.Services
{
    class Oficina
    {
        public void CadastrarCliente(Cliente cliente)
        {
            
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            
        }
        /*
        public void CriarServico(Cliente cliente, Veiculo veiculo, Funcionario funcionario, string descricao, double valor)
        {
            Servico s = new Servico(cliente, descricao, valor, veiculo, funcionario, Status.Pendente);
            Servicos.Add(s);
            cliente.AdicionarServico(s);
        }

        public void AlterarStatus(Servico s, Status status)
        {
            s.Status = status;
        }

        public void ExibirServicos(Cliente c)
        {
            foreach (Servico s in Servicos)
            {
                if (s.Cliente.Nome == c.Nome)
                {
                    Console.WriteLine(s);
                }
            }
        }
    
        public void ExibirServicos(Funcionario f)
        {
            foreach (Servico s in Servicos)
            {
                if (s.Funcionario.Nome == f.Nome)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public void ExibirServicos(DateTime data)
        {
            foreach (Servico s in Servicos)
            {
                if (s.Data.Day == data.Day)
                {
                    Console.WriteLine(s);
                }
            }
        } */
    }
}
