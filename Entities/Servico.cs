using System;
using System.Globalization;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Entities
{
    class Servico
    {
        public Cliente Cliente { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public Veiculo Veiculo { get; set; }
        public Funcionario Funcionario { get; set; }
        public Status Status { get; set; }
        
        public Servico(Cliente cliente, string descricao, double valor, Veiculo veiculo, Funcionario funcionario, Status status)
        {
            Cliente = cliente;
            Descricao = descricao;
            Data = DateTime.Now;
            Valor = valor;
            Veiculo = veiculo;
            Funcionario = funcionario;
            Status = status;
        }

        public override string ToString()
        {
            return "-----------------------------------------" +
                "\nCliente: " + Cliente +
                "\nVeículo: " + Veiculo +
                "\nServiço: " + Descricao +
                "\nValor: " + Valor.ToString("F2", CultureInfo.InvariantCulture) +
                "\nData de criação: " + Data +
                "\n----------------------------------------- \n";
        }
    }
}
