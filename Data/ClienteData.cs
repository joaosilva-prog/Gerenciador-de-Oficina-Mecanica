using System;
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
            try
            {
                Clientes.Add(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar cliente no repositório.", ex);
            }
        }

        public void RemoverCliente(Cliente cliente)
        {
            try
            {
                Clientes.Remove(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover cliente do repositório.", ex);
            }

        }

        public Cliente BuscarPorDocumento(string documento)
        {
            try
            {
                Cliente cliente = Clientes.FirstOrDefault(x => x.Documento == documento);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar cliente por documento no repositório.", ex);
            }
        }

        public bool VerificarCliente(string documento)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar cliente no repositório.", ex);
            }

        }

        public Cliente ObterClientePorDocumento(string documento)
        {
            try
            {
                Cliente cliente = Clientes.FirstOrDefault(x => x.Documento == documento);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter cliente por documento no repositório.", ex);
            }
        }
    }
}
