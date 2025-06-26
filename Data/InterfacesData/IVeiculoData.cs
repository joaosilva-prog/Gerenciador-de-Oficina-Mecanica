using System;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data.InterfacesData
{
    interface IVeiculoData
    {
        public void CadastrarVeiculo(Veiculo veiculo);
        public void RemoverVeiculo(Veiculo veiculo);
        public List<Veiculo> BuscarVeiculosPorDocumento(string documentoCliente);
        public Veiculo ObterVeiculoPorDocumento(string documentoCliente);
        public bool VerificarVeiculo(string documento);
    }
}
