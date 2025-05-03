namespace ReservaRestaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our DaftDelicias Resevation System");

            // Inicializar el sistema
            var reservationService = new ReservationService(new ReservationRepository());
            var tableService = new TableService(new TablaReporsitory());
            var cusotmerService = new CustomerService(new CustomerRepository());
            // Inicializar 
            var ui = new ConsoleUI(reservationService, tableService, cusotmerService);

            ui.run();
        }
    }
}
