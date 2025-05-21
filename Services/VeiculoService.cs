using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;
using GerenciamentoDeOficina.Data;

namespace GerenciamentoDeOficina.Services
{
    class VeiculoService : IVeiculoService
    {
        private IVeiculoData _veiculoData;

        public VeiculoService(IVeiculoData veiculoData)
        {
            _veiculoData = veiculoData;
        }
        public void CadastrarVeiculo(Veiculo veiculo)
        {
            _veiculoData.CadastrarVeiculo(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _veiculoData.RemoverVeiculo(veiculo);
        }
    }
}
