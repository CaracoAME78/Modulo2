using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaBiblioteca.Modelos
{
    internal class Usuario
    {
        public string Nombre { get; set; }
        public string IdUsuario { get; set; }

        public Usuario(string nombre, string idUsuario)
        {
            Nombre = nombre;
            IdUsuario = idUsuario;
        }
    }
}
