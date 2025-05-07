using System;

namespace GerenciamentoDeOficina.Entities
{
    abstract class Pessoa
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        protected Pessoa(string nome, string documento, string email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
        }
    }
}
