using System;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Data
{
    class VeiculoData : IVeiculoData
    {
        public List<Veiculo> Veiculos { get; private set; } = new List<Veiculo>();
        public VeiculoData()
        {
        }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            Veiculos.Remove(veiculo);
        }

        public List<Veiculo> BuscarVeiculosPorDocumento(string documentoCliente)
        {
            return Veiculos.Where(v => v.DocumentoCliente == documentoCliente).ToList();
        }
    }
}
