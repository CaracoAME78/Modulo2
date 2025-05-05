using PrySistemaLaboratorio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.UI
{
    internal class ConsoleUI
    {
        private IPacienteService _pacienteService;
        private bool _isRuning = true;

        public ConsoleUI(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE PACIENTES Y LABORATORIO ===");

            while (_isRuning) 
            {
                DispalMenuPrincipal();

                var opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        GestionPacientes();
                        break;
                    case "2":
                        GestionLaboratorio();
                        break;

                    case "3":
                        _isRuning = false;
                        Console.WriteLine("Gracias por usar el sistema de laboratorio.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intentelo nuevamente.");
                        break;
                }

            }
        }

        private void GestionPacientes()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PACIENTES ===");
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Modificar paciente");
                Console.WriteLine("3. Eliminar paciente");
                Console.WriteLine("4. Listar todos los pacientes");
                Console.WriteLine("5. Buscar paciente por ID");
                Console.WriteLine("6. Buscar paciente por DNI");
                Console.WriteLine("7. Buscar paciente por Email");
                Console.WriteLine("8. Buscar paciente por Numero de Celular");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarPaciente(gestor);
                        break;
                    case "2":
                        ModificarPaciente(gestor);
                        break;
                    case "3":
                        ActivarDesactivarPaciente(gestor, true);
                        break;
                    case "4":
                        ActivarDesactivarPaciente(gestor, false);
                        break;
                    case "5":
                        ListarPacientes(gestor);
                        break;
                    case "0":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DispalMenuPrincipal()
        {
            Console.WriteLine("1. Gestión de Pacientes");
            Console.WriteLine("2. Gestión de Laboratorio (por implementar)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}
