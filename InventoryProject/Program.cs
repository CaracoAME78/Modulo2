using InventoryProject.Modelos;

namespace InventoryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Inventory Management System ===");

            SistemaInventario sistema =  new SistemaInventario();
            CargarDatosIniciales(sistema);  // Va a cargar toos los datos que vamos a nesecitar

            // Menu de entrada

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nMenu Principal:");
                Console.WriteLine("1. Gestión de empleados");
                Console.WriteLine("2. Gestión de Productos");
                Console.WriteLine("3. Movimientos de stock");
                Console.WriteLine("4. Reportes");
                Console.WriteLine("0. Salir");

                Console.WriteLine("\n Seleccione una opción: ");
                
                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            GestionEmpleados(sistema);
                            break;
                        case 2:
                            GestionProductos(sistema);
                            break;
                        case 3:
                            MovimientosStock(sistema);
                            break;
                        case 4:
                            MostrarReportes(sistema);
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción Invalida");
                            break;
                    }

                }
                catch (Exception ex) //throw on error
                {

                    Console.WriteLine(ex.Message);  // IndexOutOfRangeException //in Internet

                }



            }

        }

        static void CargarDatosIniciales (SistemaInventario sistema)
        {
            // Agregar tipos de Empleados
            var tipoAdmin = new TipoEmpleado { Nombre = "Administrador", Descripcion = "Acceso total del sistema" };
            var tipoAlmacen = new TipoEmpleado { Nombre = "Almacenero", Descripcion = "Acceso Gestión del Almacen" };
            var tipoVendedor = new TipoEmpleado { Nombre = "Vendedor", Descripcion = "Acceso Gestión venta" };

            sistema.AgregarTipoEmpleado(tipoAdmin);
            sistema.AgregarTipoEmpleado(tipoAlmacen);
            sistema.AgregarTipoEmpleado(tipoVendedor);

            // Agregar los empleados

            var empleado1 = new TipoEmpleado { 
                Nombres = "Andre Antoni", 
                TipoEmpleado = tipoAdmin, 
                Estado =EstadoEmpleado.ACTIVO, 
                FechaIngreso= new DateTime(1900,1,1),
                Edad =29;

                
            };

        }
}
