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
        private readonly IPacienteService _pacienteService;
        private readonly IMedicoService _medicoService;
        private readonly IOrdenLaboratorioService _ordenLaboratorioService;
       
        private bool _isRuning = true;

        public ConsoleUI(IPacienteService pacienteService, IMedicoService medicoService, IOrdenLaboratorioService ordenLaboratorioService )
        {
            _pacienteService = pacienteService;
            _medicoService = medicoService;
            _ordenLaboratorioService = ordenLaboratorioService; 
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
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE LABORATORIO ===");
                Console.WriteLine("1. Registrar Orden de Laboratorio");
                Console.WriteLine("2. Buscar Orden por Id");
                Console.WriteLine("3. Listar Ordenes por Area y Fecha");
                Console.WriteLine("4. Listar Ordenes por Servicio y Fecha");
                Console.WriteLine("5. Listar Ordenes por Medico");
                Console.WriteLine("6. Listar Ordenes por Paciente");
                Console.WriteLine("7. Listar Ordenes por Fecha");
                Console.WriteLine("0. Volver");
                Console.Write("Seleccione una opción: ");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarOrdenLaboratorio();
                        break;
                    case "2":
                        BuscarOrdenPorId();
                        break;
                    case "3":
                        ListarOrdenesPorAreaFecha();
                        break;
                    case "4":
                        ListarOrdenesPorServicioFecha();
                        break;
                    case "5":
                        ListarOrdenesPorMedico();
                        break;
                    case "6":
                        ListarOrdenesPorPaciente();
                        break;
                    case "7":
                        ListarOrdenesPorFecha();
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

        private void ListarOrdenesPorFecha()
        {
            Console.Clear();
            Console.WriteLine("Listar Ordenes por Fecha");
            Console.WriteLine("========================");
            Console.WriteLine("");
           
            Console.Write("Ingrese la fecha (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            var _ordenes = _ordenLaboratorioService.GetOrdenLaboratorioByFecha( fecha);
            if (_ordenes != null)
            {
                Console.Clear();
                Console.WriteLine("Lista de Ordenes por Fecha");
                Console.WriteLine("==========================");
                ImprimirTitulosOrden();
                foreach (var orden in _ordenes)
                {
                    Console.WriteLine(orden);
                }
            }
            else
            {
                Console.Write("Las Ordenes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();

        }

        private void ListarOrdenesPorPaciente()
        {
            Console.Clear();
            Console.WriteLine("Listar Ordenes por Paciente");
            Console.WriteLine("===========================");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el ID del Paciente:");
            string idpaciente = Console.ReadLine();


            var _ordenes = _ordenLaboratorioService.GetOrdenLaboratorioByIdPaciente(idpaciente);
            if (_ordenes != null)
            {
                Console.Clear();
                Console.WriteLine("Lista de Ordenes por Paciente");
                Console.WriteLine("=============================");
                ImprimirTitulosOrden();
                foreach (var orden in _ordenes)
                {
                    Console.WriteLine(orden);
                }
            }
            else
            {
                Console.Write("Las Ordenes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void ListarOrdenesPorMedico()
        {
            Console.Clear();
            Console.WriteLine("Listar Ordenes por Medico");
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el ID del Medico:");
            string idmedico = Console.ReadLine();


            var _ordenes = _ordenLaboratorioService.GetOrdenLaboratorioByIdMedico(idmedico);
            if (_ordenes != null)
            {
                Console.Clear();
                Console.WriteLine("Lista de Ordenes por Medico");
                Console.WriteLine("===========================");
                ImprimirTitulosOrden();
                foreach (var orden in _ordenes)
                {
                    Console.WriteLine(orden);
                }
            }
            else
            {
                Console.Write("Las Ordenes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void ListarOrdenesPorServicioFecha()
        {
            Console.Clear();
            Console.WriteLine("Listar Ordenes por Servicio y Fecha");
            Console.WriteLine("===================================");
            Console.WriteLine("");
            Console.WriteLine("Seleccione el Servicio:");
            foreach (var servicio in Enum.GetValues(typeof(Servicio)))
            {
                Console.WriteLine($"{(int)servicio}. {servicio}");
            }

            if (!int.TryParse(Console.ReadLine(), out int servicioSeleccionado) || !Enum.IsDefined(typeof(Servicio), servicioSeleccionado))
            {
                Console.WriteLine("Servicio no válido.");
                return;
            }

            Servicio _servicio = (Servicio)servicioSeleccionado;

            Console.Write("Ingrese la fecha (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            var _ordenes = _ordenLaboratorioService.GetOrdenLaboratorioByServicio(_servicio, fecha);
            if (_ordenes != null)
            {
                Console.Clear();
                Console.WriteLine("Lista de Ordenes por Servicio y Fecha");
                Console.WriteLine("=====================================");
                ImprimirTitulosOrden();
                foreach (var orden in _ordenes)
                {
                    Console.WriteLine(orden);
                }
            }
            else
            {
                Console.Write("Las Ordenes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();

        }

        private void ImprimirTitulosOrden()
        {
            Console.WriteLine();
            Console.WriteLine("================================================================================================================");
            Console.WriteLine("   ID Orden     ID Paciente   Fecha Programada    Area     Servicio     ID Medico     Observación");
            Console.WriteLine("================================================================================================================");

        }

        private void ListarOrdenesPorAreaFecha()
        {
            Console.Clear();
            Console.WriteLine("Listar Ordenes por Area y Fecha");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("Seleccione el área:");
            foreach (var area in Enum.GetValues(typeof(Area)))
            {
                Console.WriteLine($"{(int)area}. {area}");
            }

            if (!int.TryParse(Console.ReadLine(), out int areaSeleccionada) || !Enum.IsDefined(typeof(Area), areaSeleccionada))
            {
                Console.WriteLine("Área no válida.");
                return;
            }

            Area _area = (Area)areaSeleccionada;

            Console.Write("Ingrese la fecha (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            var _ordenes = _ordenLaboratorioService.GetOrdenLaboratorioByArea(_area, fecha);
            if (_ordenes != null)
            {
                Console.Clear();
                Console.WriteLine("Lista de Ordenes por Area y Fecha");
                Console.WriteLine("=================================");
                ImprimirTitulosOrden();
                foreach (var orden in _ordenes)
                {
                    Console.WriteLine(orden);
                }
            }
            else
            {
                Console.Write("Las Ordenes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();

        }

        private void BuscarOrdenPorId()
        {
            Console.Clear();
            Console.WriteLine("Buscar Orden por ID");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.Write("Ingrese ID de la Orden a listar: ");
            string id = Console.ReadLine();
            OrdenLaboratorio _ordenLaboratorio = _ordenLaboratorioService.GetOrdenLaboratorioById(id);
            if (_ordenLaboratorio != null)
            {
                ImprimirTitulosOrden();
                Console.Write(_ordenLaboratorio.ToString());
            }
            else
            {
                Console.Write("La Orden no se encontro bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void AgregarOrdenLaboratorio()
        {
            Console.WriteLine("=== Registro de Orden de Laboratorio ===");
            Console.WriteLine();
            Console.WriteLine("Fecha de Registro : " + DateTime.Today.ToString());
            Console.Write("Ingrese DNI del paciente: ");
            string dni = Console.ReadLine();
            var paciente = _pacienteService.GetPacienteByDni(dni);

            if (paciente == null)
            {
                Console.WriteLine("Paciente no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione el área:");
            foreach (var area in Enum.GetValues(typeof(Area)))
                Console.WriteLine($"{(int)area}. {area}");

            Area areaSeleccionada = (Area)int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el servicio:");
            foreach (var serv in Enum.GetValues(typeof(Servicio)))
                Console.WriteLine($"{(int)serv}. {serv}");

            Servicio servicioSeleccionado = (Servicio)int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione un médico (Registre el Código Completo):");
            var medicos = _medicoService.GetMedicos();
            foreach (var med in medicos)
                Console.WriteLine($"{med.Id}. {med.Nombres} {med.ApellidoPaterno} {med.ApellidoMaterno}");

            String idMedico = Console.ReadLine();
            var medicoSeleccionado = medicos.FirstOrDefault(x => x.Id == idMedico);

            Console.Write("Ingrese la fecha de programación (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime fechaProgramada);

            Console.WriteLine("Seleccione exámenes (separados por coma):");
            foreach (var ex in Enum.GetValues(typeof(Examen)))
                Console.WriteLine($"{(int)ex}. {ex}");

            var examenesInput = Console.ReadLine().Split(',');
            var examenesSeleccionados = examenesInput.Select(e => (Examen)int.Parse(e)).ToList();

            Console.Write("Observación: ");
            string observacion = Console.ReadLine();

            Console.WriteLine(medicoSeleccionado.Id);
           
            var orden = new OrdenLaboratorio ()
            {
                IdPaciente = paciente.Id,
                FechaProgramada = fechaProgramada,
                Area = areaSeleccionada,
                Servicio = servicioSeleccionado,
                IdMedico = medicoSeleccionado.Id,
                Examenes = examenesSeleccionados,
                Observacion = observacion
            };
            

            var confirmation = _ordenLaboratorioService.CrearOrden(orden);

            if (confirmation)
            {
                Console.WriteLine($"Paciente fue creado satisfactoriamente!  ID: {orden.IdOrden}");
            }
            else
            {
                Console.WriteLine("Paciente no fue creado - Ocurrio un Error.");
            }


            MostrarResumenOrden(orden);

        }

        private void MostrarResumenOrden(OrdenLaboratorio orden)
        {
            Console.WriteLine("\n--- RESUMEN DE LA ORDEN ---");
            Console.WriteLine($"Número de Orden: {orden.IdOrden}");
            Console.WriteLine($"Fecha Programada: {orden.FechaProgramada:yyyy-MM-dd}");
            Console.WriteLine($"ID Paciente: {orden.IdPaciente}");
            Console.WriteLine($"Área: {orden.Area}");
            Console.WriteLine($"Servicio: {orden.Servicio}");
            Console.WriteLine($"ID Médico: {orden.IdMedico}");
            Console.WriteLine("Exámenes:");
            orden.Examenes.ForEach(e => Console.WriteLine($"- {e}"));
            Console.WriteLine($"Observación: {orden.Observacion}\n");
            Console.ReadKey();
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
            Console.WriteLine("Lista Paciente por Celular");
            Console.WriteLine("==========================");
            Console.WriteLine("");
            Console.Write("Ingrese el Celular del paciente a listar: ");
            string celular = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteByPhoneNumber(celular);
            if (_paciente != null)
            {
                ImprimirTitulos();
                Console.Write(_paciente.ToString());
            }
            else
            {
                Console.Write("El paciente no se encontro bajo este criterio.");
            }
            Console.ReadKey();
        }

        private void BuscarPacientePorEmail()
        {
            Console.Clear();
            Console.WriteLine("Lista Paciente por Correo");
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.Write("Ingrese el Correo del paciente a listar: ");
            string correo = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteByEmail(correo);
            if (_paciente != null)
            {
                ImprimirTitulos();
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
            Console.WriteLine("Lista Paciente por DNI");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.Write("Ingrese el DNI del paciente a listar: ");
            string dni = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteByDni(dni);
            if (_paciente != null)
            {
                ImprimirTitulos();
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
            Console.WriteLine("Lista Paciente por ID");
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.Write("Ingrese ID del paciente a listar: ");
            string id = Console.ReadLine();
            Paciente _paciente = _pacienteService.GetPacienteById(id);
            if (_paciente != null)
            {
                ImprimirTitulos();
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
                Console.Clear();
                Console.WriteLine("Lista de Pacientes");
                Console.WriteLine("==================");
                ImprimirTitulos();
                foreach (var paciente in _pacientes)
                {
                    Console.WriteLine(paciente);
                }
            }
            else
            {
                Console.Write("Los pacientes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();

            var _medicos = _medicoService.GetMedicos();
            if (_medicos != null)
            {
                Console.Clear();
                Console.WriteLine("Lista de Pacientes");
                Console.WriteLine("==================");
                ImprimirTitulos();
                foreach (var medico in _medicos)
                {
                    Console.WriteLine(medico);
                }
            }
            else
            {
                Console.Write("Los pacientes no se encontraron bajo este criterio.");
            }
            Console.ReadKey();



        }

        private void ImprimirTitulos()
        {
            Console.WriteLine();
            Console.WriteLine("================================================================================================================");
            Console.WriteLine("   ID     Nombres     Apel.Paterno    Apel. Materno     Fecha Nacimiento     DNI     Sexo     Celular     Correo");
            Console.WriteLine("================================================================================================================");
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
