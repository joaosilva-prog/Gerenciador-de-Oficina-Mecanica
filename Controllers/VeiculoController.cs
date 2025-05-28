using System;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.InterfacesServices;

namespace GerenciamentoDeOficina.Controllers
{
    class VeiculoController
    {
        private IVeiculoService _veiculoService;
        ConsoleColor ColorAux = Console.ForegroundColor;
        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        public Veiculo CadastrarVeiculo()
        {
            Console.WriteLine("Tipo do Veículo:");
            Console.WriteLine("[1] Carro");
            Console.WriteLine("[2] Moto");
            Console.WriteLine("[3] Caminhão");
            Console.Write("Digite a Opção Desejada: ");
            string tipoVeiculo = Console.ReadLine();
            Tipo tipo = new Tipo();
            switch (tipoVeiculo)
            {
                case "1":
                    tipo = Tipo.Carro;
                    break;

                case "2":
                    tipo = Tipo.Moto;
                    break;

                case "3":
                    tipo = Tipo.Caminhão;
                    break;

                default:
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Tipo de Veículo não Identificado ou não Cadastrado!");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Cadastre Veículo de Tipo Válido para prosseguir.");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    return null;
            }
            Console.Write("Placa do Veículo: ");
            string placa = Console.ReadLine();
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            Veiculo veiculo = new Veiculo(tipo, modelo, placa, ano);
            _veiculoService.CadastrarVeiculo(veiculo);
            return veiculo;
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _veiculoService.RemoverVeiculo(veiculo);
        }
    }
}
