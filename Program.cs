using System;
using System.Globalization;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services;

namespace GerenciamentoDeOficina
{
    class Program
    {
        static void Main(string[] args)
        {
            Oficina of = new Oficina();

            string nome = "Joao Silva";
            string documento = "145.773.766-36";
            string email = "joao@gmail.com";
            Cliente c1 = new Cliente(nome, documento, email);
            of.CadastrarCliente(c1); //cadastrando um novo cliente a lista de clientes da Oficina;

            string placa = "WRET32";
            string modelo = "Astra";
            int ano = 2002;
            Tipo tipo = Tipo.Carro;
            Veiculo v1 = new Veiculo(placa, modelo, ano, tipo);
            c1.AdicionarVeiculo(v1); //adicionando novo carro ao cliente que já pertence a lista de clientes da Oficina;

            string nomeF1 = "Marcos Pereira";
            string docF1 = "129.345.213-00";
            string emailF1 = "marcos@gmail.com";
            Cargo cargo = Cargo.Atendente;
            double salario = 2300.0;
            Funcionario f1 = new Funcionario(nomeF1, docF1, emailF1, cargo, salario);
            of.CadastrarFuncionario(f1); //cadastrando um novo funcionário a lista de funcionários da Oficina;

            of.CriarServico(c1, v1, f1, "Troca de Pneu", 300.0); //criando novo serviço para a lista de serviços da Oficina;

            foreach (Servico s in c1.Servicos)
            {
                Console.WriteLine(s);
            }

        }
    }
}
