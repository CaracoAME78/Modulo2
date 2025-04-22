using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Modelos
{
    public class Empleado
    {
        public static int _nextId = 1;

        public int Id { get; private set; }
        public string Nombre { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
        public EstadoEmpleado Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Genero Genero { get; set; }

        public Empleado()
        {
            Id = _nextId++;
        }

    }
}
