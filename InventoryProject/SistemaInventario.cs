using InventoryProject.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject
{
    internal class SistemaInventario
    {
        private List<TipoEmpleado> _tiposEmpleados =  new List<TipoEmpleado> ();
        private List<Empleado> _empleados = new List<Empleado> () ;
        private List<Producto> _productos = new List<Producto>();
        private List<MovimientoStock> _movimientos = new List<MovimientoStock> () ;
        
        // Metodo para agregar un tipo de empleado
        public void AgregarTipoEmpleado (TipoEmpleado tipoEmpleado)
        {
            _tiposEmpleados.Add (tipoEmpleado);
        }

        // Metodo para listar todos los tipos de empleados
        public List<TipoEmpleado> ObtenerTipoEmpleados()
        {
            return _tiposEmpleados.ToList ();
        }

        // Metodo para obtener un solo empleado y quiero que sea por ID
        public TipoEmpleado ObtenerTipoEmpleadoPorId(int id)
        {
            return _tiposEmpleados.FirstOrDefault(t=> t.Id = id);
        }

    }
}
