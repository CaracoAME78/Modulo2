
using PrySistemaLaboratorio.Models;
using PrySistemaLaboratorio.Reposotories;
using PrySistemaLaboratorio.Services;
using PrySistemaLaboratorio.UI;
using System.Globalization;

namespace PrySistemaLaboratorio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Inicializar el sistema
            // Las interfaces no tienen la capacidad de crear instancias
            var pacienteService = new PacienteService(new PacienteRepositorio());
            
            // Inicializar nuestra UI (Consola)
            var ui = new ConsoleUI(pacienteService);

            // Inicializar nuestra aplicacion
            ui.Run();


        }


    }
}
