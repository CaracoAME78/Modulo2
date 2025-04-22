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
                String opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            GestionEmpleados(sistema);
                            break;
                        case "2":
                            GestionProductos(sistema);
                            break;
                        case "3":
                            MovimientosStock(sistema);
                            break;
                        case "4":
                            MostrarReportes(sistema);
                            break;
                        case "0":
                            Console.WriteLine("Opción Invalida");
                            break;
                    }

                }
                catch (Exception ex) //throw on error
                {

                    Console.Writeline(ex.Message);
                }



            }

        }
    }
}
