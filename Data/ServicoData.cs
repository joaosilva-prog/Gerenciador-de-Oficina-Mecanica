using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Data.InterfacesData;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data
{
    class ServicoData : IServicoData
    {
        public List<Servico> Servicos { get; private set; } = new List<Servico>();

        public ServicoData()
        {
        }

        public void CriarServico(Servico servico)
        {
            try
            {
                Servicos.Add(servico);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar serviço no repositório.", ex);
            }
        }

        public List<Servico> ObterServicosPorCliente(string documento)
        {
            try
            {
                List<Servico> servicos = Servicos.Where(x => x.Cliente.Documento == documento).ToList();
                if (servicos.Count == 0)
                {
                    return null;
                }
                return servicos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter serviços por cliente no repositório.", ex);
            }
        }

        public Servico ObterServicoPorDocumento(string documento)
        {
            try
            {
                Servico servico = Servicos.FirstOrDefault(x => x.Cliente.Documento == documento);
                if (servico == null)
                {
                    return null;
                }
                return servico;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter serviço por documento no repositório.", ex);
            }
        }

        public bool ChecarServico(string placa)
        {
            try
            {
                var servico = Servicos.FirstOrDefault(v => v.Veiculo.Placa == placa);
                if (servico is not null)
                {
                    if (servico.Status == Status.EmExcecucao || servico.Status == Status.Pendente)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao checar serviço no repositório.", ex);
            }
        }
        public void AlterarStatus(Servico servico, Status status)
        {
            try
            {
                servico.Status = status;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar status do serviço.", ex);
            }
        }
    }
}
