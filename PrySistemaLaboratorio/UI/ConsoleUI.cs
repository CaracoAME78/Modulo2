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

                    case "0":
                        _isRuning = false;
                        Console.WriteLine("Gracias por usar el sistema de laboratorio.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intentelo nuevamente.");
                        break;
                }

            }
        }

        private void GestionLaboratorio()
        {
            throw new NotImplementedException();
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

        private void BuscarPacientePorCelular()
        {
            Console.Clear();
            Console.Write("Ingrese el Celular del paciente a listar: ");
            string celular = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteByPhoneNumber(celular);
            Console.Write(_paciente.ToString());
            Console.ReadKey();
        }

        private void BuscarPacientePorEmail()
        {
            Console.Clear();
            Console.Write("Ingrese el Correo del paciente a listar: ");
            string correo = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteByEmail(correo);
            if (_paciente != null)
            {
                Console.Write(_paciente.ToString());
            }
            else
            {
                Console.Write("El paciente no se encontro bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void BuscarPacientePorDNI()
        {
            Console.Clear();
            Console.Write("Ingrese el DNI del paciente a listar: ");
            string dni = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteByDni(dni);
            if (_paciente != null)
            {
                Console.Write(_paciente.ToString());
            }
            else
            {
                Console.Write("El paciente no se encontro bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void BuscarPacientePorId()
        {
            Console.Clear();
            Console.Write("Ingrese ID del paciente a listar: ");
            string id = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteById(id);
            if (_paciente != null)
            {
                Console.Write(_paciente.ToString());
            }
            else
            {
                Console.Write("El paciente no se encontro bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void ListarPacientes()
        {
            var _pacientes = _pacienteService.GetPacientes();
            if (_pacientes != null)
            {
                Console.WriteLine("Lista de Pacientes");
                Console.WriteLine("==================");

                foreach (var paciente in _pacientes)
                {
                    Console.WriteLine(paciente);
                }
            }
            else
            {
                Console.Write("El paciente no se encontro bajo este criterio.");
            }
            Console.ReadKey();

            

        }

        private void EliminarPaciente()
        {
            Console.Clear();
            Console.Write("Ingrese ID del paciente a eliminar: ");
            string id = Console.ReadLine();

            Paciente _paciente = _pacienteService.GetPacienteById(id);

            if (_paciente == null)
            {
                Console.WriteLine("Paciente no encontrado.");
                return; 
            }
            else
            {
                
                var confirmation = _pacienteService.EliminarPaciente(_paciente);

                if (confirmation)
                {
                    Console.WriteLine("Paciente fue Eliminado satisfactoriamente!");
                }
                else
                {
                    Console.WriteLine("Paciente no fue Eliminado - Ocurrio un Error.");
                }
                
            }
            Console.ReadKey();


        }

        private void ModificarPaciente()
        {
            Console.Clear();
            Console.Write("Ingrese ID del paciente a modificar: ");
            string id = Console.ReadLine();

            Paciente _paciente = _pacienteService.GetPacienteById(id);
            if (_paciente == null)
            {
                Console.WriteLine("Paciente no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Nombres ({_paciente.Nombres}): ");
            string nombres = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombres)) _paciente.Nombres = nombres;

            Console.Write($"Apellido Paterno ({_paciente.ApellidoPaterno}): ");
            string apePat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apePat)) _paciente.ApellidoPaterno = apePat;

            Console.Write($"Apellido Materno ({_paciente.ApellidoMaterno}): ");
            string apeMat = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apeMat)) _paciente.ApellidoMaterno = apeMat;

            Console.Write($"Fecha de Nacimiento ({_paciente.FechaNacimiento}): ");
            string entradaFecha = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entradaFecha) && DateTime.TryParse(entradaFecha, out DateTime nuevaFecha))
            {
                _paciente.FechaNacimiento = nuevaFecha;
            }

            Console.Write($"Dirección ({_paciente.Direccion}): ");
            string direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion)) _paciente.Direccion = direccion;

            Console.Write($"Celular ({_paciente.Celular}): ");
            string celular = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(celular)) _paciente.Celular = celular;

            Console.Write($"Correo ({_paciente.Correo}): ");
            string correo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(correo)) _paciente.Correo = correo;

            
            var confirmation = _pacienteService.ModificarPaciente(_paciente);

            if (confirmation)
            {
                Console.WriteLine($"Paciente fue modificado satisfactoriamente!  ID: {_paciente.Id}");
            }
            else
            {
                Console.WriteLine("Paciente no fue modificado - Ocurrio un Error.");
            }
             Console.ReadKey();
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
            if (_paciente.Dni == null)
            {
                _paciente.Dni = "";
            }

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
            if (_paciente.Celular == null)
            {
                _paciente.Celular = "";
            }


            Console.Write("Correo Electrónico: ");
            _paciente.Correo = Console.ReadLine();
            if (_paciente.Correo == null)
            {
                _paciente.Correo = "";
            }


            var confirmation = _pacienteService.CrearPaciente(_paciente);

            if (confirmation)
            {
                Console.WriteLine($"Paciente fue creado satisfactoriamente!  ID: {_paciente.Id}");
            }
            else
            {
                Console.WriteLine("Paciente no fue creado - Ocurrio un Error.");
            }
            Console.ReadKey();
        }

        private void DispalMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE PACIENTES Y LABORATORIO ===");
            Console.WriteLine("1. Gestión de Pacientes");
            Console.WriteLine("2. Gestión de Laboratorio (por implementar)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}
