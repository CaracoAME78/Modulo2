using PrySistemaLaboratorio.Interfaces;
using PrySistemaLaboratorio.Models;
using PrySistemaLaboratorio.Services;
using System.Globalization;

namespace PrySistemaLaboratorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IGestorPaciente gestorPaciente = new PacienteManager();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE PACIENTES Y LABORATORIO ===");
                Console.WriteLine("1. Gestión de Pacientes");
                Console.WriteLine("2. Gestión de Laboratorio (por implementar)");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuGestionPacientes(gestorPaciente);
                        break;
                    case "2":
                        Console.WriteLine("Funcionalidad en desarrollo...");
                        Console.ReadKey();
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MenuGestionPacientes(IGestorPaciente gestor)
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PACIENTES ===");
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Modificar paciente");
                Console.WriteLine("3. Activar paciente");
                Console.WriteLine("4. Desactivar paciente");
                Console.WriteLine("5. Listar pacientes");
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

        static void AgregarPaciente(IGestorPaciente gestor)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR PACIENTE ===");

            Console.Write("Nombres: ");
            string nombres = Console.ReadLine();

            Console.Write("Apellido Paterno: ");
            string apePat = Console.ReadLine();

            Console.Write("Apellido Materno: ");
            string apeMat = Console.ReadLine();

            Console.Write("Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento);

            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Sexo (Masculino/Femenino): ");
            Sexo sexo = Enum.TryParse<Sexo>(Console.ReadLine(), out Sexo s) ? s : Sexo.Masculino;

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            Console.Write("Celular: ");
            string celular = Console.ReadLine();

            Console.Write("Correo Electrónico: ");
            string correo = Console.ReadLine();

            Paciente _paciente = new Paciente(nombres, apePat, apeMat, fechaNacimiento, dni, sexo, direccion, celular, correo);
            gestor.Agregar(_paciente);

            Console.WriteLine("Paciente agregado exitosamente.");
            Console.ReadKey();
        }

        static void ModificarPaciente(IGestorPaciente gestor)
        {
            Console.Clear();
            Console.Write("Ingrese ID del paciente a modificar: ");
            string id = Console.ReadLine();

            Paciente paciente= gestor.BuscarPorId(id);
            if (paciente == null)
            {
                Console.WriteLine("Paciente no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Nombres ({paciente.Nombres}): ");
            string nombres = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombres)) paciente.Nombres = nombres;

            Console.Write($"Apellido Paterno ({paciente.ApellidoPaterno}): ");
            string apePat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apePat)) paciente.ApellidoPaterno = apePat;

            Console.Write($"Apellido Materno ({paciente.ApellidoMaterno}): ");
            string apeMat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apeMat)) paciente.ApellidoMaterno = apeMat;

            Console.Write($"Dirección ({paciente.Direccion}): ");
            string direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion)) paciente.Direccion = direccion;

            Console.Write($"Celular ({paciente.Celular}): ");
            string celular = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(celular)) paciente.Celular = celular;

            Console.Write($"Correo ({paciente.Correo}): ");
            string correo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(correo)) paciente.Correo = correo;

            gestor.Modificar(id,paciente);
            Console.WriteLine("Paciente modificado correctamente.");
            Console.ReadKey();
        }

        static void ActivarDesactivarPaciente(IGestorPaciente gestor, bool activar)
        {
            Console.Clear();
            Console.Write($"Ingrese ID del paciente a {(activar ? "activar" : "desactivar")}: ");
            string id = Console.ReadLine();

            var paciente = gestor.BuscarPorId(id);
            if (paciente == null)
            {
                Console.WriteLine("Paciente no encontrado.");
                Console.ReadKey();
                return;
            }

            if (activar) gestor.Activar(id);
            else gestor.Desactivar(id);

            Console.WriteLine($"Paciente {(activar ? "activado" : "desactivado")} correctamente.");
            Console.ReadKey();
        }

        static void ListarPacientes(IGestorPaciente gestor)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE PACIENTES ===");

            var pacientes = gestor.Listar();
            foreach (var p in pacientes)
            {
                Console.WriteLine($"{p.Id} - {p.Nombres} {p.ApellidoPaterno} {p.ApellidoMaterno} - Estado: {(p.Activo ? "Activo" : "Inactivo")}");
            }

            Console.ReadKey();
        }

    }
}
