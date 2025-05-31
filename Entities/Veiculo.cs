using System;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Entities
{
    class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public Tipo Tipo { get; set; }
        public string DocumentoCliente { get; set; }

        public Veiculo(Tipo tipo, string modelo, string placa, int ano, string documentoCliente)
        {
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            Tipo = tipo;
            DocumentoCliente = documentoCliente;
        }

        public override string ToString()
        {
            return Modelo + " - " + "Placa: " + Placa;
        }
    }
}
