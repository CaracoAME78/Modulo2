using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaBiblioteca.Modelos
{
    internal class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Prestamo> prestamos = new List<Prestamo>();

        public void AgregarLibro(Libro libro) => libros.Add(libro);

        public void RegistrarUsuario(Usuario usuario) => usuarios.Add(usuario);

        public void PrestarLibro(string isbn, string idUsuario)
        {
            Libro libro = libros.FirstOrDefault(l => l.ISBN == isbn && !l.EstaPrestado);
            Usuario usuario = usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (libro != null && usuario != null)
            {
                libro.EstaPrestado = true;
                prestamos.Add(new Prestamo(libro, usuario));
                Console.WriteLine($"Libro '{libro.Titulo}' prestado a {usuario.Nombre}.");
            }
            else
            {
                Console.WriteLine("No se puede realizar el préstamo.");
            }
        }

        public void ListarLibrosDisponibles()
        {
            foreach (var libro in libros.Where(l => !l.EstaPrestado))
            {
                libro.MostrarInfo();
            }
        }

    }
}
