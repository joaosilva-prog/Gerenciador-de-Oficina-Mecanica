using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.OficinaExceptions;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Services
{
    class Oficina
    {
        private IClienteService _clienteService;
        private IFuncionarioService _funcionarioService;
        private IServicoService _servicoService;
        private IVeiculoService _veiculoService;

        public Oficina(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService, IVeiculoService veiculoService)
        {
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
            _servicoService = servicoService;
            _veiculoService = veiculoService;
        }
        public void CadastrarCliente(Cliente cliente)
        {
            _clienteService.CadastrarCliente(cliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            _clienteService.RemoverCliente(cliente);
        }

        public void BuscarPorDocumento(string documento)
        {
            _clienteService.BuscarPorDocumento(documento);
        }

        public bool VerificarCliente(string documento)
        {
            return _clienteService.VerificarCliente(documento);
        }

        public Cliente ObterClientePorDocumento(string documento)
        {
            return _clienteService.ObterClientePorDocumento(documento);
        }

        public Funcionario ObterFuncionarioPorDocumento(string documento)
        {
            return _funcionarioService.ObterFuncionarioPorDocumento(documento);
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            _funcionarioService.CadastrarFuncionario(funcionario);
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            _funcionarioService.RemoverFuncionario(funcionario);
        }

        public bool VerificarFuncionario(string documento)
        {
            return _funcionarioService.VerificarFuncionario(documento);
        }

        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            _servicoService.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
        }

        public Servico ObterServicoPorDocumento(string documento)
        {
            return _servicoService.ObterServicoPorDocumento(documento);
        }

        public void AlterarStatus(Servico servico, Status status)
        {
            _servicoService.AlterarStatus(servico, status);
        }
        public void CadastrarVeiculo(Veiculo veiculo)
        {
            _veiculoService.CadastrarVeiculo(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _veiculoService.RemoverVeiculo(veiculo);
        }
    }
}
