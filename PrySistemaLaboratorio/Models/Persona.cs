using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Models
{
    internal abstract class Persona
    {
        public string Id { get;  set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }
        public Sexo Sexo { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
    }
}
