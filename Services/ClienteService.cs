using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Services.InterfacesServices;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Services
{
    class ClienteService : IClienteService
    {
        ConsoleColor ColorAux = Console.ForegroundColor;
        private IClienteData _clienteData;

        public ClienteService(IClienteData clienteData)
        {
            _clienteData = clienteData;
        }
        public bool CadastrarCliente(Cliente cliente)
        {
            if (_clienteData.VerificarCliente(cliente.Documento) == true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Cliente já existente.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return false;
            }
            _clienteData.CadastrarCliente(cliente);
            return true;
        }
        public void RemoverCliente(Cliente cliente)
        {
            if (_clienteData.VerificarCliente(cliente.Documento) == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Cliente não encontrado para ser removido.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            _clienteData.RemoverCliente(cliente);
        }
        public void BuscarPorDocumento(string documento)
        {
            if (_clienteData.VerificarCliente(documento) == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ATENÇÃO: Cliente não encontrado/cadastrado.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Cadastre um Novo Cliente para prosseguir ou verifique o documento informado.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            _clienteData.BuscarPorDocumento(documento);
        }
        public bool VerificarCliente(string documento)
        {
           return _clienteData.VerificarCliente(documento);
        }
        public Cliente ObterClientePorDocumento(string documento)
        {
            return _clienteData.ObterClientePorDocumento(documento);
        }
    }
}
