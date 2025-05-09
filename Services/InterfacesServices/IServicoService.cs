using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Services.InterfacesServices
{
    interface IServicoService 
    {
        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status);
    }
}
