using System;
using GerenciamentoDeOficina.Services.OficinaExceptions;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Data.InterfacesData;

namespace GerenciamentoDeOficina.Data
{
    class ClienteData : IClienteData
    {
        public List<Cliente> Clientes { get; private set; } = new List<Cliente>();

        public ClienteData()
        {
        }

        public void CadastrarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void RemoverCliente(Cliente cliente)
        {
            Clientes.Remove(cliente);
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

        public bool VerificarCliente(string documento)
        {
            var x = Clientes.Where(x => x.Documento == documento).ToList();
            if (x.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
