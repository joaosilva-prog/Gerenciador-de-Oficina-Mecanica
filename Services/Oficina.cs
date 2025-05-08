using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.OficinaExceptions;

namespace GerenciamentoDeOficina.Services
{
    class Oficina
    {
        public List<Servico> Servicos { get; set; } = new List<Servico>();
        public List<Funcionario> Funcionarios { get; private set; } = new List<Funcionario>();
        public List<Cliente> Clientes { get; private set; } = new List<Cliente>();

        public void CadastrarCliente(Cliente cliente)
        {
            if (Clientes.Contains(cliente))
            {
                throw new OficinaException("Este cliente já existe no Banco de Dados da Oficina!");
            }
            Clientes.Add(cliente);
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            if (Funcionarios.Contains(funcionario))
            {
                throw new OficinaException("Este cliente já existe no Banco de Dados da Oficina!");
            }
            Funcionarios.Add(funcionario);
        }

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
        }
    }
}
