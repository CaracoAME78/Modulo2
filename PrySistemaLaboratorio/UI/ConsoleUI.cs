using PrySistemaLaboratorio.Models;
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
                        AgregarPaciente();
                        break;
                    case "2":
                        ModificarPaciente();
                        break;
                    case "3":
                        EliminarPaciente();
                        break;
                    case "4":
                        ListarPacientes();
                        break;
                    case "5":
                        BuscarPacientePorId();
                        break;
                    case "6":
                        BuscarPacientePorDNI();
                        break;
                    case "7":
                        BuscarPacientePorEmail();
                        break;
                    case "8":
                        BuscarPacientePorCelular();
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

        private void AgregarPaciente()
        {
            bool sexoValido = false;
            String sexo;
            Paciente _paciente = new Paciente();


            Console.Clear();
            Console.WriteLine("=== AGREGAR PACIENTE ===");

            Console.Write("Nombres: ");
            _paciente.Nombres = Console.ReadLine();


            Console.Write("Apellido Paterno: ");
            _paciente.ApellidoPaterno = Console.ReadLine();

            Console.Write("Apellido Materno: ");
            _paciente.ApellidoMaterno = Console.ReadLine();

            Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento);
            _paciente.FechaNacimiento = fechaNacimiento;

            Console.Write("DNI: ");
            _paciente.Dni = Console.ReadLine();

            do
            {
                Console.Write("Sexo (0: Masculino, 1: Femenino, 2: Otro): ");
                sexo = Console.ReadLine();

                if (int.TryParse(sexo, out int valor) && Enum.IsDefined(typeof(Sexo), valor))
                {
                    sexoValido = true;
                    switch (sexo)
                    {

                        case "0":
                            _paciente.Sexo = Sexo.Masculino;
                            break;
                        case "1":
                            _paciente.Sexo = Sexo.Femenino;
                            break;
                        case "2":
                            _paciente.Sexo = Sexo.Otro;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Ingrese 0, 1 o 2.");
                }

            } while (!sexoValido);

            Console.Write("Dirección: ");
            _paciente.Direccion = Console.ReadLine();

            Console.Write("Celular: ");
            _paciente.Celular = Console.ReadLine();

            Console.Write("Correo Electrónico: ");
            _paciente.Correo = Console.ReadLine();

            var confirmation = _pacienteService.CrearPaciente(_paciente);

            if (confirmation)
            {
                Console.WriteLine($"Paciente fue creado satisfactoriamente!  ID: {_paciente.Id}");
            }
            else
            {
                Console.WriteLine("Paciente no fue creado - Ocurrio un Error.");
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
