using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;

namespace GerenciamentoDeOficina.Data.InterfacesData
{
    interface IServicoData
    {
        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status);
        public Servico ObterServicoPorDocumento(string documento);
        public void AlterarStatus(Servico servico, Status status);
    }
}
