using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class VeiculoController
    {
        private IVeiculoService _veiculoService;
        public bool VeiculoCadastrado { get; private set; }
        public bool VeiculoVerificado { get; private set; }
        public bool CamposOK { get; private set; }
        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }
        public void CadastrarVeiculo(Tipo tipo, string modelo, string placa, int ano, string documentoCliente)
        {
            if (string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(placa) || ano <= 0 || string.IsNullOrWhiteSpace(documentoCliente))
            {
                CamposOK = false;
                return;
            }
            CamposOK = true;
            Veiculo veiculo = new Veiculo(tipo, modelo, placa, ano, documentoCliente);
            VeiculoCadastrado = _veiculoService.CadastrarVeiculo(veiculo);
        }

        public Veiculo ObterVeiculoPorDocumento(string documentoCliente)
        {
            return _veiculoService.ObterVeiculoPorDocumento(documentoCliente);
        }

        public bool VerificarVeiculo(string documento)
        {
            VeiculoVerificado = _veiculoService.VerificarVeiculo(documento);
            return VeiculoVerificado;
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _veiculoService.RemoverVeiculo(veiculo);
        }
    }


}
