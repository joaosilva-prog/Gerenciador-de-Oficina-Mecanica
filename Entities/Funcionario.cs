using System;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Entities
{
    class Funcionario : Pessoa
    {
        public Cargo Cargo { get; set; }
        public double Salario { get; set; }

        public Funcionario(string nome, string documento, string email, Cargo cargo, double salario) : base(nome, documento, email)
        {
            Cargo = cargo;
            Salario = salario;
        }
    }
}
