using PrySistemaBiblioteca.Modelos;

namespace PrySistemaBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();

            // Registrar libros
            biblioteca.AgregarLibro(new Libro("El Principito", "Antoine de Saint-Exupéry", "ISBN001"));
            biblioteca.AgregarLibro(new Libro("Cien años de soledad", "Gabriel García Márquez", "ISBN002"));

            // Registrar usuarios
            biblioteca.RegistrarUsuario(new Usuario("Ana Pérez", "U001"));
            biblioteca.RegistrarUsuario(new Usuario("Luis Gómez", "U002"));

            // Mostrar libros disponibles
            Console.WriteLine("Libros disponibles:");
            biblioteca.ListarLibrosDisponibles();

            // Prestar un libro
            biblioteca.PrestarLibro("ISBN001", "U001");

            // Mostrar libros disponibles después del préstamo
            Console.WriteLine("\nLibros disponibles después del préstamo:");
            biblioteca.ListarLibrosDisponibles();

            Console.ReadKey();
        }
    }
}
