using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Services
{
    class ServicoService : IServicoService
    {
        private IServicoData _servicoData;
        ConsoleColor ColorAux = Console.ForegroundColor;
        public ServicoService(IServicoData servicoData)
        {
            _servicoData = servicoData;
        }
        public bool CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            if(_servicoData.ChecarServico(veiculo.Placa) == true)
            {
                
                return false;
            }
            Servico servico = new Servico(cliente, descricao, valor, veiculo, funcionario, status);
            _servicoData.CriarServico(servico);
            return true;
        }

        public List<Servico> ObterServicosPorCliente(string documento)
        {
            return _servicoData.ObterServicosPorCliente(documento);
        }
        public Servico ObterServicoPorDocumento(string documento)
        {
            return _servicoData.ObterServicoPorDocumento(documento);
        }

        public bool AlterarStatus(Servico servico, Status status)
        {
            _servicoData.AlterarStatus(servico, status);
            return true;
        }
    }
}
