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
        
        public Paciente()
        {

        }
        public Paciente(string nombres, string apePat, string apeMat, DateTime fechaNacimiento, string dni, Sexo sexo, string direccion, string celular, string correo)
        {
            this.Nombres = nombres;
            this.ApellidoPaterno = apePat;
            this.ApellidoMaterno = apeMat;
            this.FechaNacimiento = fechaNacimiento;
            this.Dni = dni;
            this.Sexo = sexo;
            this.Direccion = direccion;
            this.Celular = celular;
            this.Correo = correo;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombres: {Nombres}, Apellido Paterno: {ApellidoPaterno}, Apellido Materno: {ApellidoMaterno}, Fecha de nacimiento : {FechaNacimiento}" +
                $", Sexo: {Sexo}, Celular: {Celular}, Correo: {Correo}";
        }

    }
}
