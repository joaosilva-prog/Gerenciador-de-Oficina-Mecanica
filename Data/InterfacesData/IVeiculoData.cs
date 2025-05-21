using System;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data.InterfacesData
{
    interface IVeiculoData
    {
        public void CadastrarVeiculo(Veiculo veiculo);
        public void RemoverVeiculo(Veiculo veiculo);
    }
}
