using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Interfaces
{
    internal interface IGestorPaciente
    {
        void Agregar(Paciente paciente);
        void Modificar(string id, Paciente paciente);
        void Desactivar(string id);
        void Activar(string id);
        List<Paciente> Listar();
        Paciente BuscarPorId(string id);
    }
}
