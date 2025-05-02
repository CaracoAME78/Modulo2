using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaBiblioteca.Modelos
{
    internal class Prestamo
    {
        public Libro LibroPrestado { get; set; }
        public Usuario UsuarioPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public Prestamo(Libro libro, Usuario usuario)
        {
            LibroPrestado = libro;
            UsuarioPrestamo = usuario;
            FechaPrestamo = DateTime.Now;
        }
    }
}
