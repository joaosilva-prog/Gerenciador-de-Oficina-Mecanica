using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IVeiculoService
    {
        public bool CadastrarVeiculo(Veiculo veiculo);
        public bool RemoverVeiculo(Veiculo veiculo);
        public Veiculo ObterVeiculoPorDocumento(string documentoCliente);
        public List<Veiculo> BuscarVeiculosPorDocumento(string documentoCliente);
        public bool VerificarVeiculo(string documento);
    }
}
