using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Modelos
{
    public class Empleado
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public string Nombres { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
        public EstadoEmpleado Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Edad { get; set; }
        public Genero Genero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public Empleado()
        {
            Id = _nextId++;
        }
    }
}
