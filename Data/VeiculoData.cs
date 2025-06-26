using System;
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
            try
            {
                Veiculos.Add(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar veículo no repositório.", ex);
            }
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            try
            {
                Veiculos.Remove(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover veículo do repositório.", ex);
            }
        }

        public List<Veiculo> BuscarVeiculosPorDocumento(string documentoCliente)
        {
            try
            {
                return Veiculos.Where(v => v.DocumentoCliente == documentoCliente).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar veículos por documento no repositório.", ex);
            }
        }

        public Veiculo ObterVeiculoPorDocumento(string documentoCliente)
        {
            try
            {
                Veiculo veiculo = Veiculos.FirstOrDefault(v => v.DocumentoCliente == documentoCliente);
                return veiculo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter veículo por documento no repositório.", ex);
            }
        }

        public bool VerificarVeiculo(string documento)
        {
            try
            {
                var x = Veiculos.Where(x => x.DocumentoCliente == documento).ToList();
                if (x.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar veículo no repositório.", ex);
            }
        }
    }
}
