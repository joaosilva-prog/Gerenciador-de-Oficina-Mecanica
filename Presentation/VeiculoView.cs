using System;
using GerenciamentoDeOficina.Controllers;
using GerenciamentoDeOficina.Enums;

namespace GerenciamentoDeOficina.Presentation
{
    class VeiculoView
    {
        private VeiculoController _veiculoController;
        public bool VeiculoExistente { get; set; }
        ConsoleColor ColorAux = Console.ForegroundColor;

        public VeiculoView(VeiculoController veiculoController)
        {
            _veiculoController = veiculoController;

        }
        public void CadastrarVeiculo()
        {
            Tipo tipo = new Tipo();
            Console.WriteLine("Tipo do Veículo:");
            Console.WriteLine("[1] Carro");
            Console.WriteLine("[2] Moto");
            Console.WriteLine("[3] Caminhão");
            Console.Write("Digite a Opção Desejada: ");
            bool veiculoOK = int.TryParse(Console.ReadLine(), out int tipoVeiculo);
            if (veiculoOK == false || tipoVeiculo < 1 || tipoVeiculo > 3)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada de dados inválida.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Selecione uma das opções enumeradas.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            else
            {
                tipo = tipoVeiculo switch
                {
                    1 => Tipo.Carro,
                    2 => Tipo.Moto,
                    3 => Tipo.Caminhão 
                };
            }
            Console.Write("Placa do Veículo: ");
            string placa = Console.ReadLine() ?? "";
            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? "";
            Console.Write("Ano: ");
            bool anoOK = int.TryParse(Console.ReadLine(), out int ano);
            if (anoOK == false)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada de dados inválida.");
                Console.ForegroundColor = ColorAux;
                Console.WriteLine("Selecione uma das opções enumeradas.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.Write("Documento do Cliente deste Veículo: ");
                string documentoCliente = Console.ReadLine() ?? "";
                _veiculoController.CadastrarVeiculo(tipo, modelo, placa, ano, documentoCliente);
                if (_veiculoController.CamposOK == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ATENÇÃO: Dados inválidos, ou não preenchidos.");
                    Console.ForegroundColor = ColorAux;
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    if (_veiculoController.VeiculoCadastrado == true)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("> Veículo cadastrado com sucesso!");
                        Console.ForegroundColor = ColorAux;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ATENÇÃO: Veículo com esta placa já existente.");
                        Console.ForegroundColor = ColorAux;
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        return;
                    }
                }
            }
        }
    }
}
