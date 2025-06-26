using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Presentation;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class ServicoController
    {
        private IServicoService _servicoService;
        private IClienteService _clienteService;
        private IVeiculoService _veiculoService;
        private IFuncionarioService _funcionarioService;
        public bool ServicoCadastrado { get; private set; }
        public bool StatusAlterado { get; private set; }
        public bool ClienteEncontrado { get; private set; }
        public bool FuncionarioEncontrado { get; private set; }
        public bool VeiculoEncontrado { get; private set; }
        public bool CamposOk { get; private set; }
        public ServicoController(IServicoService servicoService, IClienteService clienteService, IVeiculoService veiculoService, IFuncionarioService funcionarioService)
        {
            _servicoService = servicoService;
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
            _veiculoService = veiculoService;
        }

        public void CriarServico(string documentoCliente, string descricao, double valor, string documentoFuncionario)
        {
            Cliente cliente;
            Funcionario funcionario;
            Veiculo veiculo;

            if (string.IsNullOrWhiteSpace(documentoCliente) ||
               string.IsNullOrWhiteSpace(descricao) ||
               valor == 0 ||
               string.IsNullOrWhiteSpace(documentoFuncionario))
            {
                CamposOk = false;
                return;
            }
            CamposOk = true;
            if (_clienteService.VerificarCliente(documentoCliente) == true)
            {
                ClienteEncontrado = true;
                cliente = _clienteService.ObterClientePorDocumento(documentoCliente);
            }
            else
            {
                ClienteEncontrado = false;
                return;
            }
            if (_funcionarioService.VerificarFuncionario(documentoFuncionario) == true)
            {
                FuncionarioEncontrado = true;
                funcionario = _funcionarioService.ObterFuncionarioPorDocumento(documentoFuncionario);
            }
            else
            {
                FuncionarioEncontrado = false;
                return;
            }
            if (_veiculoService.VerificarVeiculo(documentoCliente) == true)
            {
                VeiculoEncontrado = true;
                veiculo = _veiculoService.ObterVeiculoPorDocumento(documentoCliente);
            }
            else
            {
                VeiculoEncontrado = false;
                return;
            }
            Status status = Status.Pendente;
            ServicoCadastrado = _servicoService.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
        }

        public List<Servico> ObterServicosDoCliente(string documentoCliente)
        {
            return _servicoService.ObterServicosPorCliente(documentoCliente);
        }

        public Servico ObterServicoPorDocumento(string documento)
        {
            return _servicoService.ObterServicoPorDocumento(documento);
        }

        public void AlterarStatus(Servico servico, Status novoStatus)
        {
            StatusAlterado = _servicoService.AlterarStatus(servico, novoStatus);
        }
    }
}
