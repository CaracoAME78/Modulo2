using PrySistemaLaboratorio.Interfaces;
using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal class PacienteManager : IGestorPaciente
    {
        private List<Paciente> pacientes = new List<Paciente>();

        public void Agregar(Paciente paciente) => pacientes.Add(paciente);

        public void Modificar(string id, Paciente paciente)
        {
            var p = pacientes.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.Nombres = paciente.Nombres;
                p.ApellidoPaterno = paciente.ApellidoPaterno;
                p.ApellidoMaterno = paciente.ApellidoMaterno;
                p.FechaNacimiento = paciente.FechaNacimiento;
                p.Dni = paciente.Dni;
                p.Sexo = paciente.Sexo;
                p.Direccion = paciente.Direccion;
                p.Celular = paciente.Celular;
                p.Correo = paciente.Correo;
            }
        }

        public void Desactivar(string id)
        {
            var p = pacientes.FirstOrDefault(x => x.Id == id);
            if (p != null) p.Activo = false;
        }

        public void Activar(string id)
        {
            var p = pacientes.FirstOrDefault(x => x.Id == id);
            if (p != null) p.Activo = true;
        }

        public List<Paciente> Listar() => pacientes;

        public Paciente BuscarPorId(string id)
        {
            return pacientes.Find(x => x.Id == id);
        }
    }
}
