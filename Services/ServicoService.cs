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

        public ServicoService(IServicoData servicoData)
        {
            _servicoData = servicoData;
        }
        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            _servicoData.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
        }
        public Servico ObterServicoPorDocumento(string documento)
        {
            return _servicoData.ObterServicoPorDocumento(documento);
        }

        public void AlterarStatus(Servico servico, Status status)
        {
            _servicoData.AlterarStatus(servico, status);
        }
    }
}
