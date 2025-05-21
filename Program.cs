using System;
using System.Globalization;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.Services.OficinaExceptions; 
using GerenciamentoDeOficina.Presentation;
using GerenciamentoDeOficina.Services;
using GerenciamentoDeOficina.Data;

namespace GerenciamentoDeOficina
{
    class Program
    {
        static void Main(string[] args)
        {
            var ClienteData = new ClienteData();
            var ClienteService = new ClienteService(ClienteData);
            var FuncionarioData = new FuncionarioData();
            var FuncionarioService = new FuncionarioService(FuncionarioData);
            var ServicoData = new ServicoData();
            var ServicoService = new ServicoService(ServicoData);
            var VeiculoData = new VeiculoData();
            var VeiculoService = new VeiculoService(VeiculoData);

            MenuInicial menu = new MenuInicial(ClienteService, FuncionarioService, ServicoService, VeiculoService);
            menu.IniciarMenu();
        }
    }
}
