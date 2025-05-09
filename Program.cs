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
            
            MenuInicial menu = new MenuInicial();
            menu.IniciarMenu();
        }
    }
}
