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
        ConsoleColor ColorAux = Console.ForegroundColor;
        private IClienteService _clienteService;

        public VeiculoService(IVeiculoData veiculoData)
        {
            _veiculoData = veiculoData;
        }
        public bool CadastrarVeiculo(Veiculo veiculo)
        {
            if (_veiculoData.VerificarVeiculo(veiculo.Placa) == true)
            {
                return false;
            }
            _veiculoData.CadastrarVeiculo(veiculo);
            return true;
        }

        public Veiculo ObterVeiculoPorDocumento(string documentoCliente)
        {
            return _veiculoData.ObterVeiculoPorDocumento(documentoCliente);
        }

        public bool RemoverVeiculo(Veiculo veiculo)
        {
            if (_veiculoData.VerificarVeiculo(veiculo.DocumentoCliente) == false)
            {
                return false;
            }
            _veiculoData.RemoverVeiculo(veiculo);
            return true;
        }

        public bool VerificarVeiculo(string documento)
        {
            return _veiculoData.VerificarVeiculo(documento);
        }

        public List<Veiculo> BuscarVeiculosPorDocumento(string documentoCliente)
        {
            return _veiculoData.BuscarVeiculosPorDocumento(documentoCliente);
        }
    }
}
