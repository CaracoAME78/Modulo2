using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaBiblioteca.Modelos
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public bool EstaPrestado { get; set; }

        public Libro(string titulo, string autor, string isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            EstaPrestado = false;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Título: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, Prestado: {(EstaPrestado ? "Sí" : "No")}");
        }
    }
}
