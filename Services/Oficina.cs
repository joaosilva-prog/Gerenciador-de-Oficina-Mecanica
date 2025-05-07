using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Services
{
    class Oficina
    {
        public List<Funcionario> Funcionarios { get; private set; } = new List<Funcionario>();
        public List<Cliente> Clientes { get; private set; } = new List<Cliente>();
        public void CadastrarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
        }

        public void CriarServico (Cliente cliente, Veiculo veiculo, Funcionario funcionario, string descricao, double valor)
        {
            Servico s = new Servico(cliente, descricao, valor, veiculo, funcionario, Status.Pendente);
            cliente.AdicionarServico(s);
        }

        public void AlterarStatus(Servico s, Status status)
        {
            s.Status = status;
        }

    }
}
