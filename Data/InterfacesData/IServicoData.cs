using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Data.InterfacesData
{
    interface IServicoData
    {
        public void CriarServico(Servico servico);
        public List<Servico> ObterServicosPorCliente(string documento);
        public Servico ObterServicoPorDocumento(string documento);
        public bool ChecarServico(string placa);
        public void AlterarStatus(Servico servico, Status status);
    }
}
