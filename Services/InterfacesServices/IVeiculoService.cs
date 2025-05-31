using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IVeiculoService
    {
        public void CadastrarVeiculo(Veiculo veiculo);
        public void RemoverVeiculo(Veiculo veiculo);
        public List<Veiculo> BuscarVeiculosPorDocumento(string documentoCliente);
    }
}
