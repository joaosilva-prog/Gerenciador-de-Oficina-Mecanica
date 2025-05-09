using System;
using GerenciamentoDeOficina.Data;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Services
{
    class ServicoService : IServicoService
    {
        private ServicoData ServicoData = new ServicoData();
        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            ServicoData.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
        }
    }
}
