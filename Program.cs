using System;
using System.Globalization;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Services;

namespace GerenciamentoDeOficina
{
    class Program
    {
        static void Main(string[] args)
        {
            Oficina of = new Oficina();

            try
            {
                Console.Write("Entre com o Nome do Funcionário do Atendimento: ");
                string nomeF = Console.ReadLine();
                Console.Write("Entre com o Documento do Funcionário do Atendimento: ");
                string documentoF = Console.ReadLine();
                Console.Write("Entre com o Email do Funcionário do Atendimento: ");
                string emailF = Console.ReadLine();
                Console.WriteLine("Entre com o Cargo do Funcionário do Atendimento: ");
                Console.WriteLine("1) ATENDENTE.");
                Console.WriteLine("2) GERENTE.");
                Console.WriteLine("3) MECÂNICO.");
                Console.WriteLine("3) SUPERVISOR.");
                Console.Write("Selecione uma das opções: ");
                int cargoF = int.Parse(Console.ReadLine());
                Cargo cargo = new Cargo();
                if (cargoF == 1)
                {
                    cargo = Cargo.Atendente;
                }
                else if (cargoF == 2)
                {
                    cargo = Cargo.Gerente;
                }
                else if (cargoF == 3)
                {
                    cargo = Cargo.Mecânico;
                }
                else if(cargoF == 4)
                {
                    cargo = Cargo.Supervisor;
                }
                else
                {
                    throw new OficinaException("Cargo não identificado.");
                }
                Funcionario f = new Funcionario(nomeF, documentoF, emailF, cargo);
                of.CadastrarFuncionario(f);

                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                Console.Write("Entre com o Nome do Cliente: ");
                string nome = Console.ReadLine();
                Console.Write("Entre com o Documento do Cliente: ");
                string documento = Console.ReadLine();
                Console.Write("Entre com o Email do Cliente: ");
                string email = Console.ReadLine();
                Cliente c1 = new Cliente(nome, documento, email);
                of.CadastrarCliente(c1);

                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Entre com o Tipo do Veículo do Cliente " + c1.Nome + ":");
                Console.WriteLine("1) CARRO.");
                Console.WriteLine("2) MOTO.");
                Console.WriteLine("3) CAMINHÃO.");
                Console.Write("Selecione uma das opções: ");
                int resp = int.Parse(Console.ReadLine());
                Tipo tipo = new Tipo();
                if (resp == 1)
                {
                    tipo = Tipo.Carro;
                }
                else if (resp == 2)
                {
                    tipo = Tipo.Moto;
                }
                else if (resp == 3)
                {
                    tipo = Tipo.Caminhao;
                }
                else
                {
                    throw new OficinaException("Tipo não identificado.");
                }
                Console.Write("Entre com o Modelo: ");
                string modelo = Console.ReadLine();
                Console.Write("Entre com a Placa: ");
                string placa = Console.ReadLine();
                Console.Write("Entre com o Ano: ");
                int ano = int.Parse(Console.ReadLine());
                Veiculo v1 = new Veiculo(tipo, modelo, placa, ano);
                c1.AdicionarVeiculo(v1);
                Console.Write("Descreva o serviço a ser feito no Veículo: ");
                string descricao = Console.ReadLine();
                Console.Write("Insira o valor a ser cobrado pelo Serviço: ");
                double valor = double.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();

                of.CriarServico(c1, v1, f, descricao, valor);
                of.ExibirServicos(c1);
            }
            catch (OficinaException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
