using System;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Entities
{
    class Funcionario : Pessoa
    {
        public Cargo Cargo { get; set; }

        public Funcionario(string nome, string documento, string email, Cargo cargo) : base(nome, documento, email)
        {
            Cargo = cargo;
        }
    }
}
