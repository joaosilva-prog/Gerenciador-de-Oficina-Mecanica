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

        public Cliente BuscarPorDocumento(string documento)
        {
            Cliente cliente = Clientes.FirstOrDefault(x => x.Documento == documento);
            return cliente;
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

        public Cliente ObterClientePorDocumento(string documento)
        {
            Cliente cliente = Clientes.FirstOrDefault(x => x.Documento == documento);
            return cliente;
        }
    }
}
