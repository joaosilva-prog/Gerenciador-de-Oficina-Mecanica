using System;
using GerenciamentoDeOficina.Services;

namespace GerenciamentoDeOficina.Entities
{
    class Cliente : Pessoa
    {
        public Cliente(string nome, string documento, string email) : base(nome, documento, email)
        {
        }
        public override string ToString()
        {
            return "DADOS CLIENTE: Nome: " + Nome + "; Documento: " + Documento + "; Email: " + Email + ".";
        }
    }
}
