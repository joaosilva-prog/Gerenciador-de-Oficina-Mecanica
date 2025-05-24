using System;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.OficinaExceptions;
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
        }

        public Servico ObterServicoPorDocumento(string documento)
        {
            Servico servico = Servicos.FirstOrDefault(x => x.Cliente.Documento == documento);
            if (servico == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Não foram Cadastrados Serviços para este Cliente.");
                Console.ResetColor();
                Console.WriteLine("Cadastre um Novo Serviço para prosseguir ou verifique o documento informado.");
            }
            return servico;
        }

        public void AlterarStatus(Servico servico, Status status)
        {
            if (Servicos.Contains(servico))
            {
                servico.Status = status;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Não foram encontrados Serviços para este Cliente.");
                Console.ResetColor();
                Console.WriteLine("Cadastre um Novo Serviço para prosseguir ou verifique o documento informado.");
            }
        }
    }
}
