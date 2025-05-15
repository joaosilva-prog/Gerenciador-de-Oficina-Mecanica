using System;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Data;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Services
{
    class Oficina
    {
        private IClienteService _clienteService;
        private IFuncionarioService _funcionarioService;
        private IServicoService _servicoService;

        public Oficina(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService)
        {
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
            _servicoService = servicoService;
        }
        public void CadastrarCliente(Cliente cliente)
        {
            _clienteService.CadastrarCliente(cliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            _clienteService.RemoverCliente(cliente);
        }

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            _funcionarioService.CadastrarFuncionario(funcionario);
        }

        public void BuscarPorDocumento(string documento)
        {
            _clienteService.BuscarPorDocumento(documento);
        }

        public void CriarServico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            _servicoService.CriarServico(cliente, descricao, valor, veiculo, funcionario, status);
        }

        /*
        public void CriarServico(Cliente cliente, Veiculo veiculo, Funcionario funcionario, string descricao, double valor)
        {
            Servico s = new Servico(cliente, descricao, valor, veiculo, funcionario, Status.Pendente);
            Servicos.Add(s);
            cliente.AdicionarServico(s);
        }

        public void AlterarStatus(Servico s, Status status)
        {
            s.Status = status;
        }

        public void ExibirServicos(Cliente c)
        {
            foreach (Servico s in Servicos)
            {
                if (s.Cliente.Nome == c.Nome)
                {
                    Console.WriteLine(s);
                }
            }
        }
    
        public void ExibirServicos(Funcionario f)
        {
            foreach (Servico s in Servicos)
            {
                if (s.Funcionario.Nome == f.Nome)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public void ExibirServicos(DateTime data)
        {
            foreach (Servico s in Servicos)
            {
                if (s.Data.Day == data.Day)
                {
                    Console.WriteLine(s);
                }
            }
        } */
    }
}
