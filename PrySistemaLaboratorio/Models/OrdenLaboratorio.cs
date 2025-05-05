using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Models
{
    internal class OrdenLaboratorio
    {
        public string IdOrden { get; set; }
        public string IdPaciente { get; set; }
        public DateTime FechaProgramada { get; set; }
        public Area Area { get; set; }
        public Servicio Servicio { get; set; }
        public string IdMedico { get; set; }
        public List<Examen> Examenes { get; set; } = new List<Examen>();
        public string Observacion { get; set; }

        public override string ToString()
        {
            return $"=> {IdOrden}  {IdPaciente}  {FechaProgramada} {Area} {Servicio}  {IdMedico}  {Observacion}";
        }

    }
}
