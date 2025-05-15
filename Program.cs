using System;
using System.Globalization;
using GerenciamentoDeOficina.Entities;
using GerenciamentoDeOficina.Enums;
using GerenciamentoDeOficina.OficinaExceptions;
using GerenciamentoDeOficina.Presentation;
using GerenciamentoDeOficina.Services;

namespace GerenciamentoDeOficina
{
    class Program
    {
        static void Main(string[] args)
        {
            var ClienteService = new ClienteService();
            var FuncionarioService = new FuncionarioService();
            var ServicoService = new ServicoService();

            MenuInicial menu = new MenuInicial(ClienteService, FuncionarioService, ServicoService);
            menu.IniciarMenu();
        }
    }
}
