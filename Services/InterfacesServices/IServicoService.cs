using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IServicoService 
    {
        public bool CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status);
        public List<Servico> ObterServicosPorCliente(string documento);
        public Servico ObterServicoPorDocumento(string documento);
        public bool AlterarStatus(Servico servico, Status status);
    }
}
