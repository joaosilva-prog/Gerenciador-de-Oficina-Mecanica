using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Presentation
{
    class MenuInicial
    {
        private bool _sair;
        private Oficina _oficina;
        private IClienteService _clienteService;
        private IFuncionarioService _funcionarioService;
        private IServicoService _servicoService;

        public MenuInicial(IClienteService clienteService, IFuncionarioService funcionarioService, IServicoService servicoService  )
        {
            _clienteService = clienteService;
            _funcionarioService = funcionarioService;
            _servicoService = servicoService;
            _oficina = new Oficina(_clienteService, _funcionarioService, _servicoService);
        }

        public void IniciarMenu()
        {
            
            Console.WriteLine("Olá! Seja Bem-Vindo(a) ao Gerenciador de Oficina!");
            Console.WriteLine("Selecione abaixo uma das opções para iniciar:");
            Console.WriteLine("1] Cadastrar Novo Serviço");
            Console.WriteLine("2] Alterar Status de um Serviço");
            Console.WriteLine("3] Cadastrar Novo Veículo de um Cliente");
            Console.WriteLine("4] Sair");
            Console.Write("Digite a Opção Desejada: ");
            string opcao = Console.ReadLine();

            Cliente cliente = new Cliente("Joao", "12345", "joaoemail");
            _oficina.CadastrarCliente(cliente);
            _oficina.BuscarPorDocumento("12345");



        }
    }
}
