using System;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Entities;

namespace GerenciamentoDeOficina.Data
{
    class ClienteData
    {
        public List<Cliente> Clientes { get; private set; }

        public ClienteData()
        {
            Clientes = new List<Cliente>();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
            Console.WriteLine("Cliente Cadastrado com Sucesso!");
        }

        public void RemoverCliente(Cliente cliente)
        {
           Clientes.Remove(cliente);
            Console.WriteLine("Cliente Removido com Sucesso!");
        }

        public void BuscarPorDocumento(string documento)
        {
            try
            {
                var x = Clientes.Where(x => x.Documento == documento).ToList();
                {
                    if (x.Count == 0)
                    {
                        throw new OficinaException("Desculpe, Documento de Cliente Inválido ou Não Identificado.");

                    }
                    Console.WriteLine("Sucesso! Resultados com base na Busca:");
                    foreach (Cliente cliente in x)
                    {
                        Console.WriteLine(cliente);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
