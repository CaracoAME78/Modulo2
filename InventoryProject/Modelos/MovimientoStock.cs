using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Modelos
{
    public class MovimientoStock
    {
        private static int _nexID = 1;

        public int Id { get; set; }
        public Producto Producto { get; set; }
        public Empleado Empleado { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }  
    }
}
