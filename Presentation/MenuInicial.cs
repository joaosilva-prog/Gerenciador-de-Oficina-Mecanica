using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services;

namespace GerenciamentoDeOficina.Presentation
{
    class MenuInicial
    {
        private bool _sair;
        Oficina of = new Oficina();
        ClienteService clienteService = new ClienteService();
        public void IniciarMenu()
        {
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
                clienteService.CadastrarCliente(cliente);
                clienteService.BuscarPorDocumento("12345");
               
            }
            
        }
    }
}
