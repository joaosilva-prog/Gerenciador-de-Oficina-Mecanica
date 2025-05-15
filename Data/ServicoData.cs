using System;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Data
{
    class ServicoData : IServicoData
    {
        public List<Servico> Servicos { get; private set; } = new List<Servico>();

        public ServicoData() 
        {
        }

        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            Servico servico = new Servico(cliente, descricao, valor, veiculo, funcionario, status);
            Servicos.Add(servico);
            Console.WriteLine("Serviço Criado com Sucesso!");
        }
    }
}
