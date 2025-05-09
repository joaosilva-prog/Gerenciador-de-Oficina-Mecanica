using System;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Data
{
    class ServicoData
    {
        public List<Servico> Servicos { get; private set; }

        public ServicoData() 
        {
            Servicos = new List<Servico>();
        }

        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            Servico servico = new Servico(cliente, descricao, valor, veiculo, funcionario, status);
            Servicos.Add(servico);
            Console.WriteLine("Serviço Criado com Sucesso!");
        }
    }
}
