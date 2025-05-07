using System;

namespace GerenciamentoDeOficina.Entities
{
    class Cliente : Pessoa
    {
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<Servico> Servicos { get; set; } = new List<Servico>();
        public Cliente(string nome, string documento, string email) : base(nome, documento, email)
        {
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            Veiculos.Add(veiculo);
        }

        public void AdicionarServico(Servico servico)
        {
            Servicos.Add(servico);
        }

        public override string ToString()
        {
            return Nome + " - " + Documento;
        }
    }
}
