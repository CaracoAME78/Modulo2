using PrySistemaLaboratorio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Models
{
    internal class Paciente : Persona
    {
        public bool Activo { get; set; }

        public Paciente(string nombres, string apePat, string apeMat, DateTime fechaNacimiento, string dni, Sexo sexo, string direccion, string celular, string correo)
        {
            this.Id = GeneradorIdPaciente.GenerarId();
            this.Nombres = nombres;
            this.ApellidoPaterno = apePat;
            this.ApellidoMaterno = apeMat;
            this.FechaNacimiento = fechaNacimiento;
            this.Dni = dni;
            this.Sexo = sexo;
            this.Direccion = direccion;
            this.Celular = celular;
            this.Correo = correo;
            this.Activo = true;
        }
    }
}
