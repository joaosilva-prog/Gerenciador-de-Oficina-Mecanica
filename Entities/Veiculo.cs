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

        public Veiculo(string placa, string modelo, int ano, Tipo tipo)
        {
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return Modelo + " - " + "Placa: " + Placa;
        }
    }
}
